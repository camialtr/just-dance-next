using System.Collections.Generic;

public struct SongData
{
    public string title;
    public string artist;
    public string credits;
    public string jdVersion;
    public uint numCoach;
    public uint difficulty;
    public List<float> lyricsColor;
}

public struct MusicTrack
{
    public bool intro;
    public float videoDelayTime;
    public float videoStartTime;
    public float videoEndTime;
    public int startBeat;
    public int endBeat;
    public List<float> beats;
}

public struct Lyrics
{
    public float time;
    public float duration;
    public string text;
    public int isLineEnding;
}

public struct Moves
{
    public float time;
    public float duration;
    public string name;
    public int goldMove;
    public int coachID;
}

public struct Pictos
{
    public float time;
    public string name;
}

public struct Timeline
{
    public List<Lyrics> lyrics;
    public List<Moves> moves;
    public List<Pictos> pictos;
}