using System.Collections.Generic;

public struct SongJson
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

public struct SongMove
{
    public string name;
    public int time;
    public int duration;
    public int goldMove;
}