using System.Runtime.InteropServices;

public class Scoring
{
    private readonly int scoringID = -1;

    [DllImport("Scoring.dll")]
    private static extern int init();

    public Scoring()
    {
        scoringID = init();
    }

    [DllImport("Scoring.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool loadClassifier(int scoringID, string moveName, [MarshalAs(UnmanagedType.LPArray)] byte[] source, int sourceLength);

    public bool LoadClassifier(string moveName, byte[] source) => loadClassifier(scoringID, moveName, source, source.Length);

    [DllImport("Scoring.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool loadMove(int scoringID, string moveName, int start, int duration, bool isGold, bool isLastOne);

    public bool LoadMove(string moveName, int start, int duration, bool isGold, bool isLastOne) => loadMove(scoringID, moveName, start, duration, isGold, isLastOne);

    [DllImport("Scoring.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool addSample(int scoringID, float t, float x, float y, float z);

    public bool AddSample(float x, float y, float z, float t) => addSample(scoringID, t, x, y, z);

    [DllImport("Scoring.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern ScoreResult getLastScore(int scoringID);

    public ScoreResult GetLastScore() => getLastScore(scoringID);

    [DllImport("Scoring.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool endScore(int scoringID);

    public bool EndScore() => endScore(scoringID);
}

public struct ScoreResult
{
    public int moveNum;
    public float totalCalories;
    public float totalScore;
    public int rating;
    [MarshalAs(UnmanagedType.U1)]
    public bool playerIsOnFire;
    [MarshalAs(UnmanagedType.U1)]
    public bool isGoldMove;
}