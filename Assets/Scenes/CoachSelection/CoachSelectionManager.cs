using Nova;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class CoachSelectionManager : MonoBehaviour
{
    MapSelectionManager mapSelectionManager;
    [SerializeField] ClipMask coachSelectionClipMask;
    [SerializeField] GameObject[] coachController;

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

    bool canInteract = false;

    private async void Start()
    {
        mapSelectionManager = GameObject.Find("UI-MapSelection(Clone)").GetComponent<MapSelectionManager>();

        string path = Application.persistentDataPath;

        if (mapSelectionManager.songDesc.numCoach == 1)
        {
            coachController[0].SetActive(true);

            Texture2D bkg = new(2048, 1024, TextureFormat.RGBA32, false);
            bkg.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "bkg.png")));
            oneCoachBkg.SetImage(bkg);

            Texture2D coach01 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach01.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach01.png")));
            oneCoachCoach.SetImage(coach01);
        }
        else if (mapSelectionManager.songDesc.numCoach == 2)
        {
            coachController[1].SetActive(true);

            Texture2D bkg = new(2048, 1024, TextureFormat.RGBA32, false);
            bkg.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "bkg.png")));
            for (int i = 0; i < 2; i++)
            {
                duoCoachBkg[i].SetImage(bkg);
            }            

            Texture2D coach01 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach01.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach01.png")));
            duoCoachCoach[0].SetImage(coach01);

            Texture2D coach02 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach02.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach02.png")));
            duoCoachCoach[1].SetImage(coach02);
        }
        else if (mapSelectionManager.songDesc.numCoach == 3)
        {
            coachController[2].SetActive(true);

            Texture2D bkg = new(2048, 1024, TextureFormat.RGBA32, false);
            bkg.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "bkg.png")));
            for (int i = 0; i < 3; i++)
            {
                trioCoachBkg[i].SetImage(bkg);
            }

            Texture2D coach01 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach01.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach01.png")));
            trioCoachCoach[0].SetImage(coach01);

            Texture2D coach02 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach02.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach02.png")));
            trioCoachCoach[1].SetImage(coach02);

            Texture2D coach03 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach03.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach03.png")));
            trioCoachCoach[2].SetImage(coach03);
        }
        else if (mapSelectionManager.songDesc.numCoach == 4)
        {
            coachController[3].SetActive(true);

            Texture2D bkg = new(2048, 1024, TextureFormat.RGBA32, false);
            bkg.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "bkg.png")));
            for (int i = 0; i < 4; i++)
            {
                quartCoachBkg[i].SetImage(bkg);
            }

            Texture2D coach01 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach01.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach01.png")));
            quartCoachCoach[0].SetImage(coach01);

            Texture2D coach02 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach02.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach02.png")));
            quartCoachCoach[1].SetImage(coach02);

            Texture2D coach03 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach03.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach03.png")));
            quartCoachCoach[2].SetImage(coach03);

            Texture2D coach04 = new(1024, 1024, TextureFormat.RGBA32, false);
            coach04.LoadImage(File.ReadAllBytes(Path.Combine(path, "Maps", mapSelectionManager.playlists.playlistCluster[0].maps[mapSelectionManager.selectedMap].name, "coach04.png")));
            quartCoachCoach[3].SetImage(coach04);
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
        }
    }
}
