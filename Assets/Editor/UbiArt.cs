using System.Collections.Generic;

public struct UbiSongDesc
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

public struct UbiMusicTrack
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

public struct UbiKaraokeTape
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

public struct UbiDanceTape
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

public struct UbiMoveSpaceMovement
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