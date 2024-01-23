using System.Runtime.InteropServices;

public class ScoringWrapper
{
    private int scoringWrapperID = -1;

    [DllImport("jdScoring.dll")]
    private static extern int init();

    public ScoringWrapper()
    {
        scoringWrapperID = init();
    }

    [DllImport("jdScoring.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool loadClassifier(int scoringWrapperID, string moveName, [MarshalAs(UnmanagedType.LPArray)] byte[] source, int sourceLength);

    public bool LoadClassifier(string moveName, byte[] source) => loadClassifier(scoringWrapperID, moveName, source, source.Length);

    [DllImport("jdScoring.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool loadMove(int scoringWrapperID, string moveName, int start, int duration, bool isGold, bool isLastOne);

    public bool LoadMove(string moveName, int start, int duration, bool isGold, bool isLastOne) => loadMove(scoringWrapperID, moveName, start, duration, isGold, isLastOne);

    [DllImport("jdScoring.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool addSample(int scoringWrapperID, float t, float x, float y, float z);

    public bool AddSample(float x, float y, float z, float t) => addSample(scoringWrapperID, t, x, y, z);

    [DllImport("jdScoring.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern ScoreResult getLastScore(int scoringWrapperID);

    public ScoreResult GetLastScore() => getLastScore(scoringWrapperID);

    [DllImport("jdScoring.dll", CallingConvention = CallingConvention.Cdecl)]
    private static extern bool endScore(int scoringWrapperID);

    public bool EndScore() => endScore(scoringWrapperID);
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
