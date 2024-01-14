using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

public static class Mapping
{
    [MenuItem("Just Dance/Mapping/From UbiArt")]
    static void FromUbiArt()
    {
        //Opens folder picker
        string path = EditorUtility.OpenFolderPanel("Select Folder", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), null);
        string mapName = Path.GetFileName(path);

        //Checks if map already exists and if you have all the necessary files to proceed
        if (mapName.Equals("")) { }
        else if (Directory.Exists(Path.Combine(Application.dataPath, "Resources", "Maps", mapName)))
        {
            Debug.LogError("This map already exists on maps folder or you has not select any folder. Be sure that everything is right and you're not replacing some ready work!");
        }
        else if (File.Exists(Path.Combine(path, "videoscoach", mapName + ".webm"))
                && File.Exists(Path.Combine(path, "audio", mapName + ".ogg"))
                && Directory.EnumerateFiles(Path.Combine(path, "timeline", "pictos")).Count() > 0
                && Directory.EnumerateFiles(Path.Combine(path, "timeline", "moves", "wiiu")).Count() > 0
                && File.Exists(Path.Combine(path, "audio", mapName + "_musictrack.tpl.ckd"))
                && File.Exists(Path.Combine(path, "timeline", mapName + "_tml_karaoke.ktape.ckd"))
                && File.Exists(Path.Combine(path, "timeline", mapName + "_tml_dance.dtape.ckd"))
                && File.Exists(Path.Combine(path, "songdesc.tpl.ckd")))
        {
            //Creates temporary directories to store the files
            Directory.CreateDirectory(Path.Combine(path, "temp")); Directory.CreateDirectory(Path.Combine(path, "temp", "media"));
            Directory.CreateDirectory(Path.Combine(path, "temp", "pictos")); Directory.CreateDirectory(Path.Combine(path, "temp", "moves"));

            //Copies the media files to temporary directory
            File.Copy(Path.Combine(path, "videoscoach", mapName + ".webm"), Path.Combine(path, "temp", "media", mapName + ".webm"));
            File.Copy(Path.Combine(path, "audio", mapName + ".ogg"), Path.Combine(path, "temp", "media", mapName + ".ogg"));

            //Copies the pictograms files to temporary directory (MUST BE PNG FILES)
            foreach (string file in Directory.EnumerateFiles(Path.Combine(path, "timeline", "pictos"), "*.png"))
            {
                File.Copy(file, Path.Combine(path, "temp", "pictos", Path.GetFileName(file)));
            }

            //Copies the moves files to temporary directory
            foreach (string file in Directory.EnumerateFiles(Path.Combine(path, "timeline", "moves", "wiiu"), "*.msm"))
            {
                File.Copy(file, Path.Combine(path, "temp", "moves", Path.GetFileNameWithoutExtension(file) + ".bytes"));
            }

            //Instantiates SongData, aquires data from songdesc.tpl.ckd and save it as json
            UbiSongDesc ubiSongDesc = JsonConvert.DeserializeObject<UbiSongDesc>(File.ReadAllText(Path.Combine(path, "songdesc.tpl.ckd")));
            SongData songData = new()
            {
                title = ubiSongDesc.COMPONENTS[0].Title,
                artist = ubiSongDesc.COMPONENTS[0].Artist,
                credits = ubiSongDesc.COMPONENTS[0].Credits,
                jdVersion = ubiSongDesc.COMPONENTS[0].OriginalJDVersion.ToString(),
                numCoach = (uint)ubiSongDesc.COMPONENTS[0].NumCoach,
                difficulty = (uint)ubiSongDesc.COMPONENTS[0].Difficulty,
                lyricsColor = new List<float>()
                {
                    (float)ubiSongDesc.COMPONENTS[0].DefaultColors.lyrics[1],
                    (float)ubiSongDesc.COMPONENTS[0].DefaultColors.lyrics[2],
                    (float)ubiSongDesc.COMPONENTS[0].DefaultColors.lyrics[3],
                    1f
                }
            };
            File.WriteAllText(Path.Combine(path, "temp", "songdata.json"), JsonConvert.SerializeObject(songData, Formatting.Indented));

            //Acquires _musictrack.tpl.ckd data, translate it to milliseconds and save it as json
            UbiMusicTrack ubiMusicTrack = JsonConvert.DeserializeObject<UbiMusicTrack>(File.ReadAllText(Path.Combine(path, "audio", mapName + "_musictrack.tpl.ckd")));
            MusicTrack musicTrack = new()
            {
                videoStartTime = Convert.ToSingle(ubiMusicTrack.COMPONENTS[0].trackData.structure.videoStartTime.ToString().Replace("-", "")),
                videoEndTime = 0f,
                startBeat = Convert.ToInt32(ubiMusicTrack.COMPONENTS[0].trackData.structure.startBeat.ToString().Replace("-", "")),
                endBeat = ubiMusicTrack.COMPONENTS[0].trackData.structure.endBeat,
                beats = new()
            };
            for (int i = 0; i < ubiMusicTrack.COMPONENTS[0].trackData.structure.markers.Count; i++)
            {
                if (i == 0)
                {
                    musicTrack.beats.Add(0f);
                }
                else
                {
                    musicTrack.beats.Add(Convert.ToSingle(ubiMusicTrack.COMPONENTS[0].trackData.structure.markers[i]) / 48000f);
                }
            }
            musicTrack.intro = EditorUtility.DisplayDialog("Does the audio includes an intro amb?", "We need to know if that map audio contains the amb intros to proceed correctly, does it have?", "Yes", "No");
            if (musicTrack.intro)
            {
                musicTrack.videoEndTime = musicTrack.beats[^1] + musicTrack.beats[musicTrack.startBeat];
            }
            else
            {
                musicTrack.videoEndTime = musicTrack.beats[^1];
            }
            File.WriteAllText(Path.Combine(path, "temp", "musictrack.json"), JsonConvert.SerializeObject(musicTrack, Formatting.Indented));

            //Acquires _tml_karaoke.ktape.ckd data, translate it to milliseconds and save it as json
            UbiKaraokeTape ubiKaraokeTape = JsonConvert.DeserializeObject<UbiKaraokeTape>(File.ReadAllText(Path.Combine(path, "timeline", mapName + "_tml_karaoke.ktape.ckd")));
            List<Lyrics> lyrics = new();
            for (int i = 0; i < ubiKaraokeTape.Clips.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(ubiKaraokeTape.Clips[i].Lyrics))
                {
                    float time = 0f;
                    if (i >= ubiKaraokeTape.Clips.Count - 15)
                    {
                        time = FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], ubiKaraokeTape.Clips[i].StartTime - 2000, musicTrack.beats.Count - 1 - musicTrack.startBeat);
                        time += FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], 2000, musicTrack.beats.Count - 1 - musicTrack.startBeat);
                    }
                    else
                    {
                        time = FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], ubiKaraokeTape.Clips[i].StartTime, musicTrack.beats.Count - 1 - musicTrack.startBeat);
                    }
                    lyrics.Add(new()
                    {
                        time = time,
                        duration = FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], ubiKaraokeTape.Clips[i].Duration, musicTrack.beats.Count - 1 - musicTrack.startBeat),
                        text = ubiKaraokeTape.Clips[i].Lyrics,
                        isLineEnding = ubiKaraokeTape.Clips[i].IsEndOfLine
                    });
                }
            }

            //Acquires _tml_dance.dtape.ckd data, translate it to milliseconds and save it as separated jsons
            UbiDanceTape ubiDanceTape = JsonConvert.DeserializeObject<UbiDanceTape>(File.ReadAllText(Path.Combine(path, "timeline", mapName + "_tml_dance.dtape.ckd")));
            List<Moves> tempMoves = new();
            for (int i = 0; i < ubiDanceTape.Clips.Count; i++)
            {
                if (ubiDanceTape.Clips[i].__class.Equals("MotionClip"))
                {
                    tempMoves.Add(new()
                    {
                        time = ubiDanceTape.Clips[i].StartTime,
                        duration = ubiDanceTape.Clips[i].Duration,
                        name = Path.GetFileName(Path.GetFileNameWithoutExtension(ubiDanceTape.Clips[i].ClassifierPath)),
                        goldMove = ubiDanceTape.Clips[i].GoldMove,
                        coachID = ubiDanceTape.Clips[i].CoachId
                    });
                }
            }
            List<Moves> moves = new();
            for (int i = 0; i < tempMoves.Count; i++)
            {
                float time = 0f;
                if (i >= tempMoves.Count - 60)
                {
                    time = FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], (int)(tempMoves[i].time - 2000), musicTrack.beats.Count - 1 - musicTrack.startBeat);
                    time += FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], 2000, musicTrack.beats.Count - 1 - musicTrack.startBeat);
                }
                else
                {
                    time = FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], (int)tempMoves[i].time, musicTrack.beats.Count - 1 - musicTrack.startBeat);
                }
                moves.Add(new()
                {
                    time = time,
                    duration = FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], (int)tempMoves[i].duration, musicTrack.endBeat - musicTrack.startBeat),
                    name = tempMoves[i].name,
                    goldMove = tempMoves[i].goldMove,
                    coachID = tempMoves[i].coachID
                });
            }

            List<Pictos> tempPictos = new();
            for (int i = 0; i < ubiDanceTape.Clips.Count; i++)
            {
                if (ubiDanceTape.Clips[i].__class.Equals("PictogramClip"))
                {
                    tempPictos.Add(new()
                    {
                        time = ubiDanceTape.Clips[i].StartTime,
                        name = Path.GetFileName(Path.GetFileNameWithoutExtension(ubiDanceTape.Clips[i].PictoPath))
                    });
                }
            }
            List<Pictos> pictos = new();
            for (int i = 0; i < tempPictos.Count; i++)
            {
                float time = 0f;
                if (i >= tempPictos.Count - 15)
                {
                    time = FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], (int)(tempPictos[i].time - 2000), musicTrack.beats.Count - 1 - musicTrack.startBeat);
                    time += FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], 2000, musicTrack.beats.Count - 1 - musicTrack.startBeat);
                }
                else
                {
                    time = FromUbiArtTime(musicTrack.beats[^1] - musicTrack.beats[musicTrack.startBeat], (int)tempPictos[i].time, musicTrack.beats.Count - 1 - musicTrack.startBeat);
                }
                pictos.Add(new()
                {
                    time = time,
                    name = tempPictos[i].name
                });
            }

            //Instantiates Timeline and organize the content based on it time values
            Timeline timeline = new()
            {
                lyrics = lyrics.OrderBy(x => x.time).ToList(),
                moves = moves.OrderBy(x => x.time).ToList(),
                pictos = pictos.OrderBy(x => x.time).ToList()
            };
            File.WriteAllText(Path.Combine(path, "temp", "timeline.json"), JsonConvert.SerializeObject(timeline, Formatting.Indented));

            Directory.Move(Path.Combine(path, "temp"), Path.Combine(Application.dataPath, "Resources", "Maps", mapName));
            AssetDatabase.Refresh();

            Debug.Log("Success! The map " + mapName + " is now avaliable on Resources/Maps.");
        }
        else
        {
            Debug.LogError("You don't have all the necessary files to proceed with the process, be sure that you're set the folder environment correctly before try to proceed again!");
        }
    }

    [MenuItem("Just Dance/Mapping/From BlueStar")]
    static void FromBlueStar()
    {
        //Opens folder picker
        string path = EditorUtility.OpenFolderPanel("Select Folder", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), null);
        string mapName = Path.GetFileName(path);

        //Checks if map already exists and if you have all the necessary files to proceed
        if (mapName.Equals("")) { }
        else if (Directory.Exists(Path.Combine(Application.persistentDataPath, "Maps", mapName)))
        {
            Debug.LogError("This map already exists on maps folder or you has not select any folder. Be sure that everything is right and you're not replacing some ready work!");
        }
        else if (File.Exists(Path.Combine(path, mapName + ".webm"))
                && File.Exists(Path.Combine(path, mapName + ".ogg"))
                && Directory.EnumerateFiles(Path.Combine(path, "pictos")).Count() > 0
                && Directory.EnumerateFiles(Path.Combine(path, "classifiers_WIIU")).Count() > 0
                && File.Exists(Path.Combine(path, mapName + ".json")))
        {
            //Creates temporary directories to store the files
            Directory.CreateDirectory(Path.Combine(path, "temp")); Directory.CreateDirectory(Path.Combine(path, "temp", "media"));
            Directory.CreateDirectory(Path.Combine(path, "temp", "pictos")); Directory.CreateDirectory(Path.Combine(path, "temp", "moves"));

            //Copies the media files to temporary directory
            File.Copy(Path.Combine(path, mapName + ".webm"), Path.Combine(path, "temp", "media", mapName + ".webm"));
            File.Copy(Path.Combine(path, mapName + ".ogg"), Path.Combine(path, "temp", "media", mapName + ".ogg"));

            //Copies the pictograms files to temporary directory (MUST BE SEPARATED PNG FILES)
            foreach (string file in Directory.EnumerateFiles(Path.Combine(path, "pictos"), "*.png"))
            {
                File.Copy(file, Path.Combine(path, "temp", "pictos", Path.GetFileName(file)));
            }

            //Copies the moves files to temporary directory
            foreach (string file in Directory.EnumerateFiles(Path.Combine(path, "classifiers_WIIU"), "*.msm"))
            {
                File.Copy(file, Path.Combine(path, "temp", "moves", Path.GetFileNameWithoutExtension(file) + ".bytes"));
            }

            //Acquires the Json Song data
            SongJson songJson = JsonConvert.DeserializeObject<SongJson>(File.ReadAllText(Path.Combine(path, mapName + ".json")));

            //Instantiates SongData and aquires data from Song Json / Attaches the musictrack and timeline and get ready to json serialization
            ColorUtility.TryParseHtmlString(songJson.lyricsColor, out Color lyricsColor);
            SongData songData = new()
            {
                title = songJson.Title,
                artist = songJson.Artist,
                credits = songJson.Credits,
                jdVersion = songJson.OriginalJDVersion.ToString(),
                numCoach = (uint)songJson.NumCoach,
                difficulty = (uint)songJson.Difficulty,
                lyricsColor = new List<float>()
                {
                    lyricsColor.r,
                    lyricsColor.g,
                    lyricsColor.b,
                    1f
                }
            };
            File.WriteAllText(Path.Combine(path, "temp", "songdata.json"), JsonConvert.SerializeObject(songData, Formatting.Indented));

            bool hasIntro = EditorUtility.DisplayDialog("Does the audio includes an intro amb?", "We need to know if that map audio contains the amb intros to proceed correctly, does it have?", "Yes", "No");

            //Generates MusicTrack
            MusicTrack musicTrack = new()
            {
                intro = hasIntro,
                videoStartTime = 0f,
                videoEndTime = 0f,
                startBeat = 0,
                endBeat = songJson.beats.Count - 1,
                beats = new()
            };
            for (int i = 0; i < songJson.beats.Count; i++)
            {
                if (hasIntro)
                {
                    musicTrack.beats.Add((float)(songJson.beats[i] - songJson.videoOffset) / 1000f);
                }
                else
                {
                    musicTrack.beats.Add((float)(songJson.beats[i]) / 1000f);
                }
            }
            if (hasIntro)
            {
                musicTrack.videoStartTime = (float)songJson.videoOffset / 1000f;

                for (int i = 0; i < musicTrack.beats.Count; i++)
                {
                    if (musicTrack.beats[i] == musicTrack.videoStartTime)
                    {
                        musicTrack.startBeat = i;
                        break;
                    }
                }
            }
            musicTrack.videoEndTime = musicTrack.beats[musicTrack.endBeat];
            File.WriteAllText(Path.Combine(path, "temp", "musictrack.json"), JsonConvert.SerializeObject(musicTrack, Formatting.Indented));

            //Generates Lyrics
            List<Lyrics> lyrics = new();
            for (int i = 0; i < songJson.lyrics.Count; i++)
            {
                if (hasIntro)
                {
                    lyrics.Add(new() { time = (float)(songJson.lyrics[i].time - songJson.videoOffset) / 1000f, duration = (float)songJson.lyrics[i].duration / 1000f, text = songJson.lyrics[i].text, isLineEnding = songJson.lyrics[i].isLineEnding });
                }
                else
                {
                    lyrics.Add(new() { time = (float)(songJson.lyrics[i].time) / 1000f, duration = (float)songJson.lyrics[i].duration / 1000f, text = songJson.lyrics[i].text, isLineEnding = songJson.lyrics[i].isLineEnding });
                }
            }

            //Generates Pictos
            List<Pictos> pictos = new();
            for (int i = 0; i < songJson.pictos.Count; i++)
            {
                if (hasIntro)
                {
                    pictos.Add(new() { time = (float)(songJson.pictos[i].time - songJson.videoOffset) / 1000f, name = songJson.pictos[i].name });
                }
                else
                {
                    pictos.Add(new() { time = (float)(songJson.pictos[i].time) / 1000f, name = songJson.pictos[i].name });
                }
            }

            //Generates Moves
            List<Moves> moves = new();
            if (songJson.NumCoach >= 1)
            {
                List<SongMove> songMove = JsonConvert.DeserializeObject<List<SongMove>>(File.ReadAllText(Path.Combine(path, "moves", mapName + "_moves0.json")));
                for (int i = 0; i < songMove.Count; i++)
                {
                    if (hasIntro)
                    {
                        moves.Add(new() { time = (float)(songMove[i].time - songJson.videoOffset) / 1000f, duration = (float)(songMove[i].duration) / 1000f, name = songMove[i].name, coachID = 0, goldMove = songMove[i].goldMove });
                    }
                    else
                    {
                        moves.Add(new() { time = (float)(songMove[i].time) / 1000f, duration = (float)(songMove[i].duration) / 1000f, name = songMove[i].name, coachID = 0, goldMove = songMove[i].goldMove });
                    }
                }
            }
            if (songJson.NumCoach >= 2)
            {
                List<SongMove> songMove = JsonConvert.DeserializeObject<List<SongMove>>(File.ReadAllText(Path.Combine(path, "moves", mapName + "_moves1.json")));
                for (int i = 0; i < songMove.Count; i++)
                {
                    if (hasIntro)
                    {
                        moves.Add(new() { time = (float)(songMove[i].time - songJson.videoOffset) / 1000f, duration = (float)(songMove[i].duration) / 1000f, name = songMove[i].name, coachID = 1, goldMove = songMove[i].goldMove });
                    }
                    else
                    {
                        moves.Add(new() { time = (float)(songMove[i].time) / 1000f, duration = (float)(songMove[i].duration) / 1000f, name = songMove[i].name, coachID = 1, goldMove = songMove[i].goldMove });
                    }
                }
            }
            if (songJson.NumCoach >= 3)
            {
                List<SongMove> songMove = JsonConvert.DeserializeObject<List<SongMove>>(File.ReadAllText(Path.Combine(path, "moves", mapName + "_moves2.json")));
                for (int i = 0; i < songMove.Count; i++)
                {
                    if (hasIntro)
                    {
                        moves.Add(new() { time = (float)(songMove[i].time - songJson.videoOffset) / 1000f, duration = (float)(songMove[i].duration) / 1000f, name = songMove[i].name, coachID = 2, goldMove = songMove[i].goldMove });
                    }
                    else
                    {
                        moves.Add(new() { time = (float)(songMove[i].time) / 1000f, duration = (float)(songMove[i].duration) / 1000f, name = songMove[i].name, coachID = 2, goldMove = songMove[i].goldMove });
                    }
                }
            }
            if (songJson.NumCoach == 4)
            {
                List<SongMove> songMove = JsonConvert.DeserializeObject<List<SongMove>>(File.ReadAllText(Path.Combine(path, "moves", mapName + "_moves3.json")));
                for (int i = 0; i < songMove.Count; i++)
                {
                    if (hasIntro)
                    {
                        moves.Add(new() { time = (float)(songMove[i].time - songJson.videoOffset) / 1000f, duration = (float)(songMove[i].duration) / 1000f, name = songMove[i].name, coachID = 3, goldMove = songMove[i].goldMove });
                    }
                    else
                    {
                        moves.Add(new() { time = (float)(songMove[i].time) / 1000f, duration = (float)(songMove[i].duration) / 1000f, name = songMove[i].name, coachID = 3, goldMove = songMove[i].goldMove });
                    }
                }
            }

            //Instantiates Timeline and organize the content based on it time values
            Timeline timeline = new()
            {
                lyrics = lyrics.OrderBy(x => x.time).ToList(),
                moves = moves.OrderBy(x => x.time).ToList(),
                pictos = pictos.OrderBy(x => x.time).ToList()
            };
            File.WriteAllText(Path.Combine(path, "temp", "timeline.json"), JsonConvert.SerializeObject(timeline, Formatting.Indented));

            Directory.Move(Path.Combine(path, "temp"), Path.Combine(Application.dataPath, "Resources", "Maps", mapName));
            AssetDatabase.Refresh();

            Debug.Log("Success! The map " + mapName + " is now avaliable on Resources/Maps.");
        }
        else
        {
            Debug.LogError("You don't have all the necessary files to proceed with the process, be sure that you're set the folder environment correctly before try to proceed again!");
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remover membros privados não utilizados", Justification = "<Pendente>")]
    static UbiMoveSpaceMovement DeserializeMove(string msmFile)
    {
        using BinaryReader reader = new(File.OpenRead(msmFile));

        //Ignores the first 4 bytes
        reader.ReadBytes(4);

        //Instantiates UbiMoveSpaceMovement and acquired main data from binary file (ONLY VERSION 7 MOVES SUPPORTED)
        UbiMoveSpaceMovement move = new()
        {
            version = BitConverter.ToInt32(ReverseEndianess(reader.ReadBytes(4)), 0),
            moveName = Encoding.UTF8.GetString(reader.ReadBytes(0x40)).TrimEnd('\0'),
            mapName = Encoding.UTF8.GetString(reader.ReadBytes(0x40)).TrimEnd('\0'),
            authorName = Encoding.UTF8.GetString(reader.ReadBytes(0x40)).TrimEnd('\0'),
            moveDuration = BitConverter.ToSingle(ReverseEndianess(reader.ReadBytes(4)), 0),
            moveAccurateLowThreshold = BitConverter.ToSingle(ReverseEndianess(reader.ReadBytes(4)), 0),
            moveAccurateHighThreshold = BitConverter.ToSingle(ReverseEndianess(reader.ReadBytes(4)), 0),
            autoCorrelationThreshold = BitConverter.ToSingle(ReverseEndianess(reader.ReadBytes(4)), 0),
            moveDirectionImpactFactor = BitConverter.ToSingle(ReverseEndianess(reader.ReadBytes(4)), 0),
            moveMeasureBitfield = BitConverter.ToInt64(ReverseEndianess(reader.ReadBytes(8)), 0),
            measureValue = BitConverter.ToInt32(ReverseEndianess(reader.ReadBytes(4)), 0),
            measureCount = BitConverter.ToInt32(ReverseEndianess(reader.ReadBytes(4)), 0),
            energyMeasureCount = BitConverter.ToInt32(ReverseEndianess(reader.ReadBytes(4)), 0),
            moveCustomizationFlags = BitConverter.ToInt32(ReverseEndianess(reader.ReadBytes(4)), 0),            
            measures = new List<float>()
        };

        //Acquires measures data from binary file using a loop
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            move.measures.Add(BitConverter.ToSingle(ReverseEndianess(reader.ReadBytes(4)), 0));
        }

        return move;
    }

    static byte[] ReverseEndianess(byte[] data)
    {
        Array.Reverse(data);
        return data;
    }

    static float FromUbiArtTime(float endBeatValue, int actualValue, int endValue)
    {
        return Mathf.Lerp(0, endBeatValue, (actualValue - 0) / ((float)(endValue * 24) - 0));
    }

    //UbiArt

    struct UbiSongDesc
    {
        public List<COMPONENT> COMPONENTS;

        public struct COMPONENT
        {
            public int OriginalJDVersion;
            public string Artist;
            public string Title;
            public string Credits;
            public int NumCoach;
            public int Difficulty;
            public DefaultColors DefaultColors;
        }

        public struct DefaultColors
        {
            public List<double> lyrics;
        }
    }

    struct UbiMusicTrack
    {
        public List<COMPONENT> COMPONENTS;

        public struct COMPONENT
        {
            public TrackData trackData;
        }

        public struct TrackData
        {
            public Structure structure;
        }

        public struct Structure
        {
            public List<int> markers;
            public int startBeat;
            public int endBeat;
            public double videoStartTime;
        }
    }

    struct UbiKaraokeTape
    {
        public List<Clip> Clips;

        public struct Clip
        {
            public int StartTime;
            public int Duration;
            public string Lyrics;
            public int IsEndOfLine;
        }
    }

    struct UbiDanceTape
    {
        public List<Clip> Clips;

        public struct Clip
        {
            public string __class;
            public int StartTime;
            public int Duration;
            public string ClassifierPath;
            public string PictoPath;
            public int GoldMove;
            public int CoachId;
        }
    }

    struct UbiMoveSpaceMovement
    {
        public int version;
        public string moveName;
        public string mapName;
        public string authorName;
        public float moveDuration;
        public float moveAccurateLowThreshold;
        public float moveAccurateHighThreshold;
        public float autoCorrelationThreshold;
        public float moveDirectionImpactFactor;
        public long moveMeasureBitfield;
        public int measureValue;
        public int measureCount;
        public int energyMeasureCount;
        public int moveCustomizationFlags;
        public List<float> measures;
    }

    //BlueStar

    struct SongJson
    {
        public int OriginalJDVersion;
        public string Artist;
        public string Title;
        public string Credits;
        public int NumCoach;
        public int Difficulty;
        public string lyricsColor;
        public int videoOffset;
        public List<int> beats;
        public List<Lyric> lyrics;
        public List<Pictograms> pictos;

        public struct Lyric
        {
            public int time;
            public int duration;
            public string text;
            public int isLineEnding;
        }

        public struct Pictograms
        {
            public int time;
            public string name;
        }
    }

    public class SongMove
    {
        public string name;
        public int time;
        public int duration;
        public int goldMove;
    }
}