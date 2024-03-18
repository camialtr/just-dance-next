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

    int atualLyric = 0;
    bool startOfLine = true; 
    float nextTime = 0f; 
    int atualLine = 0; 
    bool firstLyric = true;
    bool lastLyric = false; 
    bool lyricsEnded = false;
    bool showNext = true;

    public void LoadAllLyrics()
    {
        int linesCount = 0;
        for (int i = 0; i < timeline.lyrics.Count; i++)
        {
            if (timeline.lyrics[i].isLineEnding == 1)
            {
                linesCount++;
            }
        }
        for (int i = 0;i < linesCount; i++)
        {
            lyrics.Add(Instantiate(lyricPrefab).GetComponent<Lyric>());
            lyrics[atualLine].transform.SetParent(gameObject.transform, false);
            lyrics[atualLine].gameObject.SetActive(false);
            atualLine++;
        }
        atualLine = 0;
    }

    private void Update()
    {
        if (timeManager == null || !timeManager.IsRunning) { return; }

        if (firstLyric)
        {
            ProceedLyrics();
        }

        if (!showNext && timeManager.ElapsedMilliseconds / 1000f >= nextTime + musicTrack.beats[musicTrack.startBeat] - 3f)
        {
            lyrics[atualLine - 1].Show();
            showNext = true;
        }

        if (timeManager.ElapsedMilliseconds / 1000f >= nextTime + musicTrack.beats[musicTrack.startBeat] && !lyricsEnded)
        {
            ProceedLyrics();
        }
    }

    void ProceedLyrics()
    {
        if (firstLyric)
        {
            firstLyric = false;
        }
        if (!lastLyric)
        {
            if (atualLine > 0)
            {
                lyrics[atualLine - 1].Release();
            }
            if (atualLine > 1 && lyrics[atualLine - 2].hided == false)
            {
                lyrics[atualLine - 2].Hide();
            }
            if (atualLine > 2)
            {
                lyrics[atualLine - 3].destroy = true;
                lyrics[atualLine - 3] = null;
            }
            for (; atualLyric < timeline.lyrics.Count; atualLyric++)
            {
                if (startOfLine)
                {
                    lyrics[atualLine].gameObject.SetActive(true);
                    lyrics[atualLine].name = null;
                    nextTime = timeline.lyrics[atualLyric].time;
                    lyrics[atualLine].lyricColor = lyricColor;
                    lyrics[atualLine].timeManager = timeManager;
                    lyrics[atualLine].musicTrack = musicTrack;
                    startOfLine = false;
                }

                lyrics[atualLine].name += timeline.lyrics[atualLyric].text;
                lyrics[atualLine].AddContent(timeline.lyrics[atualLyric].text, timeline.lyrics[atualLyric].time, timeline.lyrics[atualLyric].duration);

                if (timeline.lyrics[atualLyric].isLineEnding == 1)
                {
                    if (nextTime + musicTrack.beats[musicTrack.startBeat] > 3f && timeManager.ElapsedMilliseconds / 1000f >= nextTime + musicTrack.beats[musicTrack.startBeat] - 3f)
                    {
                        lyrics[atualLine].Show();
                    }
                    else
                    {
                        showNext = false;
                    }

                    startOfLine = true;
                    if (atualLyric == timeline.lyrics.Count - 1) { lastLyric = true; }
                    atualLyric++; atualLine++;

                    break;
                }
            }
        }
        else
        {
            if (timeManager.ElapsedMilliseconds / 1000f >= nextTime + musicTrack.beats[musicTrack.startBeat] && lastLyric)
            {
                lyrics[atualLine - 1].Release();
                lyricsEnded = true;
            }
        }
    }
}