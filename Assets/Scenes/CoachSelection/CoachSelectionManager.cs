using Nova;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class CoachSelectionManager : MonoBehaviour
{
    MapSelectionManager mapSelectionManager;
    [SerializeField] ClipMask coachSelectionClipMask;
    [SerializeField] GameObject[] coachController;
    [SerializeField] AudioSource selectAudio;

    //1-Coach
    [SerializeField] UIBlock2D oneCoachBkg;
    [SerializeField] UIBlock2D oneCoachCoach;

    //2-Coach
    [SerializeField] UIBlock2D[] duoCoachBkg;
    [SerializeField] UIBlock2D[] duoCoachCoach;

    //3-Coach
    [SerializeField] UIBlock2D[] trioCoachBkg;
    [SerializeField] UIBlock2D[] trioCoachCoach;

    //4-Coach
    [SerializeField] UIBlock2D[] quartCoachBkg;
    [SerializeField] UIBlock2D[] quartCoachCoach;

    [SerializeField] UIBlock2D[] dancers;

    bool[] playerConnected;
    int[] selectedCoach;
    bool canInteract = false;

    private async void Start()
    {
        mapSelectionManager = GameObject.Find("UI-MapSelection(Clone)").GetComponent<MapSelectionManager>();
        playerConnected = new bool[4] { false, false, false, false };
        selectedCoach = new int[4] { 1, 1, 1, 1 };

        string path = Application.persistentDataPath;

        if (mapSelectionManager.songDesc.numCoach == 1)
        {
            coachController[0].SetActive(true);

            Texture2D bkg = new(2048, 1024, TextureFormat.RGBA32, false);
            bkg.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "bkg.png")));
            oneCoachBkg.SetImage(bkg);

            Texture2D coach01 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach01.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach01.png")));
            oneCoachCoach.SetImage(coach01);
        }
        else if (mapSelectionManager.songDesc.numCoach == 2)
        {
            coachController[1].SetActive(true);

            Texture2D bkg = new(2048, 1024, TextureFormat.RGBA32, false);
            bkg.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "bkg.png")));
            for (int i = 0; i < 2; i++)
            {
                duoCoachBkg[i].SetImage(bkg);
            }            

            Texture2D coach01 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach01.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach01.png")));
            duoCoachCoach[0].SetImage(coach01);

            Texture2D coach02 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach02.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach02.png")));
            duoCoachCoach[1].SetImage(coach02);
        }
        else if (mapSelectionManager.songDesc.numCoach == 3)
        {
            coachController[2].SetActive(true);

            Texture2D bkg = new(2048, 1024, TextureFormat.RGBA32, false);
            bkg.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "bkg.png")));
            for (int i = 0; i < 3; i++)
            {
                trioCoachBkg[i].SetImage(bkg);
            }

            Texture2D coach01 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach01.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach01.png")));
            trioCoachCoach[0].SetImage(coach01);

            Texture2D coach02 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach02.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach02.png")));
            trioCoachCoach[1].SetImage(coach02);

            Texture2D coach03 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach03.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach03.png")));
            trioCoachCoach[2].SetImage(coach03);
        }
        else if (mapSelectionManager.songDesc.numCoach == 4)
        {
            coachController[3].SetActive(true);

            Texture2D bkg = new(2048, 1024, TextureFormat.RGBA32, false);
            bkg.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "bkg.png")));
            for (int i = 0; i < 4; i++)
            {
                quartCoachBkg[i].SetImage(bkg);
            }

            Texture2D coach01 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach01.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach01.png")));
            quartCoachCoach[0].SetImage(coach01);

            Texture2D coach02 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach02.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach02.png")));
            quartCoachCoach[1].SetImage(coach02);

            Texture2D coach03 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach03.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach03.png")));
            quartCoachCoach[2].SetImage(coach03);

            Texture2D coach04 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach04.LoadImage(await File.ReadAllBytesAsync(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach04.png")));
            quartCoachCoach[3].SetImage(coach04);
        }

        for (int i = 0; i < 4; i++)
        {
            if (!playerConnected[i] && DancerIdentifier.dancers[i] != null)
            {
                dancers[i].gameObject.SetActive(true);
            }
        }

        switch (mapSelectionManager.songDesc.numCoach)
        {
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    dancers[i].Position.X = (dancers[i].Position.X.Value - 200f);
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    dancers[i].Position.X = (dancers[i].Position.X.Value - 400f);
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    dancers[i].Position.X = (dancers[i].Position.X.Value - 600f);
                }
                break;
        }

        await Task.Delay(50);

        LeanTween.value(0f, 1f, 0.5f).setOnUpdate((float value) =>
        {
            coachSelectionClipMask.Tint = new(1f, 1f, 1f, value);
        }).setOnComplete(() =>
        {
            canInteract = true;
        });
    }

    private async void Update()
    {
        if (canInteract)
        {
            if (InputManager.Undo() && InputManager.source == InputManager.controller | InputManager.source == InputSource.Local)
            {
                canInteract = false;

                selectAudio.Play();

                await Task.Delay(50);

                LeanTween.value(1f, 0f, 0.5f).setOnUpdate((float value) =>
                {
                    coachSelectionClipMask.Tint = new(1f, 1f, 1f, value);
                }).setOnComplete(() =>
                {
                    mapSelectionManager.ReactivateFromCoachSelection();
                    Destroy(gameObject);
                });
            }
            else if (InputManager.Select() && InputManager.source == InputManager.controller | InputManager.source == InputSource.Local)
            {
                
            }
            else if (InputManager.Left() && InputManager.source != InputSource.Local)
            {
                switch ((int)InputManager.source)
                {
                    case 1:
                        //dancers[0].Position.X = -30f;
                        break;
                    case 2:
                        //dancers[1].Position.X = -10f;
                        break;
                    case 3:
                        //dancers[2].Position.X = 10f;
                        break;
                    case 4:
                        //dancers[3].Position.X = 30f;
                        break;
                }
                switch (mapSelectionManager.songDesc.numCoach)
                {
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        if (selectedCoach[(int)InputManager.source - 1] == 1)
                        {
                            selectedCoach[(int)InputManager.source - 1] = 4;
                        }
                        else
                        {
                            selectedCoach[(int)InputManager.source - 1]--;
                        }
                        switch (selectedCoach[(int)InputManager.source- 1])
                        {
                            case 1:
                                switch ((int)InputManager.source)
                                {
                                    case 1:
                                        dancers[0].Position.X = -630f;
                                        break;
                                    case 2:
                                        dancers[1].Position.X = -610f;
                                        break;
                                    case 3:
                                        dancers[2].Position.X = -590f;
                                        break;
                                    case 4:
                                        dancers[3].Position.X = -570f;
                                        break;
                                }
                                break;
                            case 2:
                                switch ((int)InputManager.source)
                                {
                                    case 1:
                                        dancers[0].Position.X = -230f;
                                        break;
                                    case 2:
                                        dancers[1].Position.X = -210f;
                                        break;
                                    case 3:
                                        dancers[2].Position.X = -190f;
                                        break;
                                    case 4:
                                        dancers[3].Position.X = -170f;
                                        break;
                                }
                                break;
                            case 3:
                                switch ((int)InputManager.source)
                                {
                                    case 1:
                                        dancers[0].Position.X = 170f;
                                        break;
                                    case 2:
                                        dancers[1].Position.X = 190f;
                                        break;
                                    case 3:
                                        dancers[2].Position.X = 210f;
                                        break;
                                    case 4:
                                        dancers[3].Position.X = 230f;
                                        break;
                                }
                                break;
                            case 4:
                                switch ((int)InputManager.source)
                                {
                                    case 1:
                                        dancers[0].Position.X = 570f;
                                        break;
                                    case 2:
                                        dancers[1].Position.X = 590f;
                                        break;
                                    case 3:
                                        dancers[2].Position.X = 610f;
                                        break;
                                    case 4:
                                        dancers[3].Position.X = 630f;
                                        break;
                                }
                                break;
                        }
                        break;
                }                
            }
            else if (InputManager.Right() && InputManager.source != InputSource.Local)
            {
                switch (mapSelectionManager.songDesc.numCoach)
                {
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
                        if (selectedCoach[(int)InputManager.source - 1] == 4)
                        {
                            selectedCoach[(int)InputManager.source - 1] = 1;
                        }
                        else
                        {
                            selectedCoach[(int)InputManager.source - 1]++;
                        }
                        switch (selectedCoach[(int)InputManager.source - 1])
                        {
                            case 1:
                                switch ((int)InputManager.source)
                                {
                                    case 1:
                                        dancers[0].Position.X = -630f;
                                        break;
                                    case 2:
                                        dancers[1].Position.X = -610f;
                                        break;
                                    case 3:
                                        dancers[2].Position.X = -590f;
                                        break;
                                    case 4:
                                        dancers[3].Position.X = -570f;
                                        break;
                                }
                                break;
                            case 2:
                                switch ((int)InputManager.source)
                                {
                                    case 1:
                                        dancers[0].Position.X = -230f;
                                        break;
                                    case 2:
                                        dancers[1].Position.X = -210f;
                                        break;
                                    case 3:
                                        dancers[2].Position.X = -190f;
                                        break;
                                    case 4:
                                        dancers[3].Position.X = -170f;
                                        break;
                                }
                                break;
                            case 3:
                                switch ((int)InputManager.source)
                                {
                                    case 1:
                                        dancers[0].Position.X = 170f;
                                        break;
                                    case 2:
                                        dancers[1].Position.X = 190f;
                                        break;
                                    case 3:
                                        dancers[2].Position.X = 210f;
                                        break;
                                    case 4:
                                        dancers[3].Position.X = 230f;
                                        break;
                                }
                                break;
                            case 4:
                                switch ((int)InputManager.source)
                                {
                                    case 1:
                                        dancers[0].Position.X = 570f;
                                        break;
                                    case 2:
                                        dancers[1].Position.X = 590f;
                                        break;
                                    case 3:
                                        dancers[2].Position.X = 610f;
                                        break;
                                    case 4:
                                        dancers[3].Position.X = 630f;
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
        }
    }
}
