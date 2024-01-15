using System.Collections.Generic;

public struct SongDesc
{
    public string title;
    public string artist;
    public string credits;
    public string jdVersion;
    public uint numCoach;
    public uint difficulty;
}

public struct MusicTrack
{
    public float videoStartTime;
    public float videoEndTime;
    public int startBeat;
    public int endBeat;
    public List<float> beats;
}

public struct Timeline
{
    public List<float> lyricsColor;
    public List<Lyrics> lyrics;
    public List<Moves> moves;
    public List<Pictos> pictos;
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