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

    public async Task LoadAndAssociateAllMoves(string mapName, string path)
    {
        scoring = new Scoring[4] { null, null, null, null };
        movesInfo = new List<Moves>[4] { null, null, null, null };
        atualRating = new int[4] { 0, 0, 0, 0};

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
            }
        }
    }

    private void Update()
    {
        if (timeManager == null || !timeManager.IsRunning || (float)(timeManager.ElapsedMilliseconds / 1000f) < musicTrack.beats[musicTrack.startBeat] ) { return; }

        for (int i = 0; i < 4; i++)
        {
            if (playerConnected[i])
            {
                if (scoring[i].AddSample(DancerIdentifier.dancers[i].accelermeterData.Value.x, DancerIdentifier.dancers[i].accelermeterData.Value.y, DancerIdentifier.dancers[i].accelermeterData.Value.z, (float)(timeManager.ElapsedMilliseconds / 1000f) - musicTrack.beats[musicTrack.startBeat]))
                {
                    ScoreResult scoreResult = scoring[i].GetLastScore();
                    if (scoreResult.moveNum == atualRating[i])
                    {
                        switch (scoreResult.rating)
                        {
                            case 0:
                                UnityEngine.Debug.LogError("X");
                                break;
                            case 1:
                                UnityEngine.Debug.LogError("OK");
                                break;
                            case 2:
                                UnityEngine.Debug.LogError("GOOD");
                                break;
                            case 3:
                                UnityEngine.Debug.LogError("PERFECT");
                                break;
                            case 4:
                                UnityEngine.Debug.LogError("YEAH");
                                break;
                        }
                        atualRating[i]++;
                    }
                }
            }
        }
    }
}
