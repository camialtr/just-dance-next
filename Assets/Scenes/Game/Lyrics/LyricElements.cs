using UnityEngine;
using System.Diagnostics;
using System.Collections.Generic;

public class LyricElements : MonoBehaviour
{
    [SerializeField] GameObject lyricPrefab;
        
    [HideInInspector] public MusicTrack musicTrack;
    [HideInInspector] public Color lyricColor;
    [HideInInspector] public Timeline timeline;
    [HideInInspector] public Stopwatch timeManager;

    readonly List<Lyric> lyrics = new();

    int actualLyric = 0;
    bool startOfLine = true; 
    float nextTime = 0f; 
    int actualLine = 0; 
    bool lastLyric = false; 
    bool lyricsEnded = false;
    bool showNext = true;

    private void Update()
    {
        if (timeManager == null)
        {
            return;
        }

        if (!showNext && timeManager.ElapsedMilliseconds / 1000f >= nextTime + musicTrack.beats[musicTrack.startBeat] - 3f)
        {
            lyrics[actualLine - 1].Show();
            showNext = true;
        }
        if (timeManager.ElapsedMilliseconds / 1000f >= nextTime + musicTrack.beats[musicTrack.startBeat] && !lyricsEnded)
        {
            if (!lastLyric)
            {
                if (actualLine > 0)
                {
                    lyrics[actualLine - 1].Release();
                }
                if (actualLine > 1 && lyrics[actualLine - 2].hided == false)
                {
                    lyrics[actualLine - 2].Hide();
                }
                if (actualLine > 2)
                {
                    lyrics[actualLine - 3].destroy = true;
                    lyrics[actualLine - 3] = null;
                }
                lyrics.Add(Instantiate(lyricPrefab).GetComponent<Lyric>());
                lyrics[actualLine].transform.SetParent(gameObject.transform, false);
                for (; actualLyric < timeline.lyrics.Count; actualLyric++)
                {
                    if (startOfLine)
                    {
                        lyrics[actualLine].name = null;
                        nextTime = timeline.lyrics[actualLyric].time;
                        lyrics[actualLine].lyricColor = lyricColor;
                        lyrics[actualLine].timeManager = timeManager;
                        lyrics[actualLine].musicTrack = musicTrack;
                        startOfLine = false;
                    }
                    if (timeline.lyrics[actualLyric].isLineEnding == 0)
                    {
                        lyrics[actualLine].name += timeline.lyrics[actualLyric].text;
                        lyrics[actualLine].AddContent(timeline.lyrics[actualLyric].text, timeline.lyrics[actualLyric].time, timeline.lyrics[actualLyric].duration);
                    }
                    else if (timeline.lyrics[actualLyric].isLineEnding == 1)
                    {
                        lyrics[actualLine].name += timeline.lyrics[actualLyric].text;
                        lyrics[actualLine].AddContent(timeline.lyrics[actualLyric].text, timeline.lyrics[actualLyric].time, timeline.lyrics[actualLyric].duration);
                        if (nextTime + musicTrack.beats[musicTrack.startBeat] > 3f && timeManager.ElapsedMilliseconds / 1000f >= nextTime + musicTrack.beats[musicTrack.startBeat] - 3f)
                        {
                            lyrics[actualLine].Show();
                        }
                        else
                        {
                            showNext = false;
                        }
                        startOfLine = true;
                        if (actualLyric == timeline.lyrics.Count - 1) { lastLyric = true; }
                        actualLyric++; actualLine++;
                        break;
                    }
                }
            }
            else
            {
                if (timeManager.ElapsedMilliseconds / 1000f >= nextTime + musicTrack.beats[musicTrack.startBeat] && lastLyric)
                {
                    lyrics[actualLine - 1].Release();
                    lyricsEnded = true;
                }
            }
        }
    }
}