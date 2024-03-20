using Nova;
using System.IO;
using UnityEngine;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

public class MoveElements : MonoBehaviour
{
    [HideInInspector] public SongDesc songDesc;
    [HideInInspector] public MusicTrack musicTrack;
    [HideInInspector] public Timeline timeline;
    [HideInInspector] public Stopwatch timeManager;

    [HideInInspector] public bool[] playerConnected;
    [HideInInspector] public int[] selectedCoach;

    [HideInInspector] public Scoring[] scoring;
    List<Moves>[] movesInfo;
    int[] atualRating;
    public GameObject dancerPrefab;
    public FeedbackElements[] feedbackElements;
    public GameObject[] dancersIndicator;
    public UIBlock2D[] dancersIndicatorUIBlock;
    public StarElements starElement;
    bool[] starRevealed = new bool[7] { false, false, false, false, false, false, false };
    bool[] scoreShowed = new bool[4] { false, false, false, false };

    public async Task<bool> LoadAndAssociateAllMoves(string mapName, string path)
    {
        scoring = new Scoring[4] { null, null, null, null };
        movesInfo = new List<Moves>[4] { null, null, null, null };
        atualRating = new int[4] { 0, 0, 0, 0};
        feedbackElements = new FeedbackElements[4] { null, null, null, null };
        dancersIndicatorUIBlock = new UIBlock2D[4] { null, null, null, null };
        int dancersCount = 0;
        for (int i = 0; i < 4; i++)
        {
            if (playerConnected[i])
            {
                scoring[i] = new();
                movesInfo[i] = new();
                for (int movesCounter = 0; movesCounter < timeline.moves.Count; movesCounter++)
                {
                    if (timeline.moves[movesCounter].coachID == selectedCoach[i] - 1)
                    {
                        movesInfo[i].Add(timeline.moves[movesCounter]);
                    }
                }
                int movesLoaded = 0;
                for (int moveIndex = 0; moveIndex < movesInfo[i].Count; moveIndex++)
                {
                    bool isLastOne = moveIndex == movesInfo[i].Count - 1;                    
                    bool isGoldMove = false;
                    if (movesInfo[i][moveIndex].goldMove == 1) { isGoldMove = true; }
                    scoring[i].LoadClassifier(movesInfo[i][moveIndex].name, await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapName, "moves", movesInfo[i][moveIndex].name + ".msm")));
                    scoring[i].LoadMove(movesInfo[i][moveIndex].name, (int)(movesInfo[i][moveIndex].time * 1000), (int)(movesInfo[i][moveIndex].duration * 1000), isGoldMove, isLastOne);
                    movesLoaded++;
                }
                feedbackElements[i] = Instantiate(dancerPrefab).GetComponent<FeedbackElements>();
                feedbackElements[i].gameObject.transform.SetParent(transform, false);
                feedbackElements[i].DancerID = i;
                feedbackElements[i].SetUpDancer();
                dancersIndicator[i].SetActive(true);
                dancersIndicatorUIBlock[i] = dancersIndicator[i].GetComponent<UIBlock2D>();
                dancersCount++;
            }
        }
        if (dancersCount != 0)
        {
            List<FeedbackElements> tempFeedbackElements = new();
            for (int i = 0; i < 4; i++)
            {
                if (playerConnected[i])
                {
                    tempFeedbackElements.Add(feedbackElements[i]);
                }
            }
            switch (dancersCount)
            {
                case 2:
                    tempFeedbackElements[0].gameObject.GetComponent<UIBlock>().Position.X = -200f;
                    tempFeedbackElements[1].gameObject.GetComponent<UIBlock>().Position.X = 200f;
                    break;
                case 3:
                    tempFeedbackElements[0].gameObject.GetComponent<UIBlock>().Position.X = -300f;
                    tempFeedbackElements[1].gameObject.GetComponent<UIBlock>().Position.X = 0f;
                    tempFeedbackElements[2].gameObject.GetComponent<UIBlock>().Position.X = -300f;
                    break;
                case 4:
                    tempFeedbackElements[0].gameObject.GetComponent<UIBlock>().Position.X = -400f;
                    tempFeedbackElements[1].gameObject.GetComponent<UIBlock>().Position.X = -200f;
                    tempFeedbackElements[2].gameObject.GetComponent<UIBlock>().Position.X = 200f;
                    tempFeedbackElements[3].gameObject.GetComponent<UIBlock>().Position.X = 400f;
                    break;
            }
        }
        return true;
    }

    private void Update()
    {
        if (timeManager == null || !timeManager.IsRunning || (float)(timeManager.ElapsedMilliseconds / 1000f) < musicTrack.beats[musicTrack.startBeat]) { return; }        

        for (int i = 0; i < 4; i++)
        {
            if (playerConnected[i] && DancerIdentifier.dancers[i] != null)
            {
                //UnityEngine.Debug.LogError(DancerIdentifier.dancers[i].pingData);
                if (scoring[i].AddSample(DancerIdentifier.dancers[i].accelermeterData.Value.x, DancerIdentifier.dancers[i].accelermeterData.Value.y, DancerIdentifier.dancers[i].accelermeterData.Value.z, (float)(timeManager.ElapsedMilliseconds / 1000f) - musicTrack.beats[musicTrack.startBeat] - 0.1f))
                {
                    ScoreResult scoreResult = scoring[i].GetLastScore();
                    if (scoreResult.moveNum == atualRating[i])
                    {
                        switch (scoreResult.rating)
                        {
                            case 0:
                                if (scoreResult.isGoldMove)
                                {
                                    feedbackElements[i].TriggerFeedback(Feedbacks.goldmiss);
                                }
                                else
                                {
                                    feedbackElements[i].TriggerFeedback(Feedbacks.miss);
                                }
                                break;
                            case 1:
                                feedbackElements[i].TriggerFeedback(Feedbacks.ok);
                                break;
                            case 2:
                                feedbackElements[i].TriggerFeedback(Feedbacks.good);
                                break;
                            case 3:
                                feedbackElements[i].TriggerFeedback(Feedbacks.perfect);
                                break;
                            case 4:
                                feedbackElements[i].TriggerFeedback(Feedbacks.yeah);
                                break;
                        }
                        float scorePercentage = Mathf.InverseLerp(0f, 12000f, scoreResult.totalScore);
                        dancersIndicatorUIBlock[i].Position.Y = Mathf.Lerp(-300, 300, scorePercentage);

                        if (scoreResult.totalScore >= 2000f)
                        {
                            if (!starRevealed[0])
                            {
                                starRevealed[0] = true;
                                starElement.TriggerStar1();
                            }
                            if (!feedbackElements[i].starRevealed[0])
                            {
                                feedbackElements[i].starRevealed[0] = true;
                                feedbackElements[i].TriggerStar1();
                            }
                        }
                        if (scoreResult.totalScore >= 4000f)
                        {
                            if (!starRevealed[1])
                            {
                                starRevealed[1] = true;
                                starElement.TriggerStar2();
                            }
                            if (!feedbackElements[i].starRevealed[1])
                            {
                                feedbackElements[i].starRevealed[1] = true;
                                feedbackElements[i].TriggerStar2();
                            }
                        }
                        if (scoreResult.totalScore >= 6000f)
                        {
                            if (!starRevealed[2])
                            {
                                starRevealed[2] = true;
                                starElement.TriggerStar3();
                            }
                            if (!feedbackElements[i].starRevealed[2])
                            {
                                feedbackElements[i].starRevealed[2] = true;
                                feedbackElements[i].TriggerStar3();
                            }
                        }
                        if (scoreResult.totalScore >= 8000f)
                        {
                            if (!starRevealed[3])
                            {
                                starRevealed[3] = true;
                                starElement.TriggerStar4();
                            }
                            if (!feedbackElements[i].starRevealed[3])
                            {
                                feedbackElements[i].starRevealed[3] = true;
                                feedbackElements[i].TriggerStar4();
                            }
                        }
                        if (scoreResult.totalScore >= 10000f)
                        {
                            if (!starRevealed[4])
                            {
                                starRevealed[4] = true;
                                starElement.TriggerStar5();
                            }
                            if (!feedbackElements[i].starRevealed[4])
                            {
                                feedbackElements[i].starRevealed[4] = true;
                                feedbackElements[i].TriggerStar5();
                            }
                        }
                        if (scoreResult.totalScore >= 11000f)
                        {
                            if (!starRevealed[5])
                            {
                                starRevealed[5] = true;
                                starElement.TriggerSuperstar();
                            }
                            if (!feedbackElements[i].starRevealed[5])
                            {
                                feedbackElements[i].starRevealed[5] = true;
                                feedbackElements[i].TriggerSuperstar();
                            }
                        }
                        if (scoreResult.totalScore >= 12000f)
                        {
                            if (!starRevealed[6])
                            {
                                starRevealed[6] = true;
                                starElement.TriggerMegastar();
                            }
                            if (!feedbackElements[i].starRevealed[6])
                            {
                                feedbackElements[i].starRevealed[6] = true;
                                feedbackElements[i].TriggerMegastar();
                            }
                        }
                        atualRating[i]++;
                    }
                    if ((float)(timeManager.ElapsedMilliseconds / 1000f) >= musicTrack.videoEndTime && !scoreShowed[i])
                    {
                        scoreShowed[i] = true;
                        UnityEngine.Debug.LogError("Dancer " + i + " | Total Score: " + scoreResult.totalScore + " | Total Calories " + scoreResult.totalCalories);
                    }
                }
            }
        }
    }
}
