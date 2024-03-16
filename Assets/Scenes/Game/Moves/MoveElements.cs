using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System;

public class MoveElements : MonoBehaviour
{
    SongDesc songDesc;
    Timeline timeline;

    bool[] playerConnected;
    int[] selectedCoach;

    public Scoring[] scoring;

    public async Task LoadAndAssociateAllMoves(string mapName, bool[] paramPlayerConnected, int[] paramSelectedCoach, SongDesc paramSongDesc, Timeline paramTimeline)
    {
        string path;
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            path = Application.dataPath;
        }
        else
        {
            path = Path.Combine(Directory.GetCurrentDirectory(), "Build/Just Dance Next_Data");
        }

        timeline = paramTimeline;
        songDesc = paramSongDesc;

        playerConnected = paramPlayerConnected;
        selectedCoach = paramSelectedCoach;

        scoring = new Scoring[4] { null, null, null, null };

        for (int i = 0; i < 4; i++)
        {
            if (playerConnected[i])
            {
                scoring[i] = new();
                List<Moves> movesInfo = new();
                for (int movesCounter = 0; movesCounter < timeline.moves.Count; movesCounter++)
                {
                    if (timeline.moves[movesCounter].coachID == selectedCoach[i] - 1)
                    {
                        movesInfo.Add(timeline.moves[movesCounter]);
                    }
                }
                for (int moveIndex = 0; moveIndex < movesInfo.Count; moveIndex++)
                {
                    bool isLastOne = moveIndex == movesInfo.Count - 1;                    
                    bool isGoldMove = false;
                    if (movesInfo[moveIndex].goldMove == 1) { isGoldMove = true; }
                    Debug.LogError(scoring[i].LoadClassifier(movesInfo[moveIndex].name, await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapName, "moves", movesInfo[moveIndex].name + ".msm"))));
                    Debug.LogError(scoring[i].LoadMove(movesInfo[moveIndex].name, (int)(movesInfo[moveIndex].time * 1000), (int)(movesInfo[moveIndex].duration * 1000), isGoldMove, isLastOne));
                    if (isLastOne) { Debug.LogError("Last One Loaded!"); }
                }
            }
        }
    }
}
