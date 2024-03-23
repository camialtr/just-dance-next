using Nova;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public string mapName;

    SongDesc songDesc;
    MusicTrack musicTrack;
    Timeline timeline;

    [SerializeField] MediaElements mediaElements;
    [SerializeField] LyricElements lyricElements;
    [SerializeField] PictoElements pictoElements;
    [SerializeField] MoveElements moveElements;

    readonly Stopwatch timeManager = new();
    bool started = false;
    bool pausePressed = false;

    public bool[] playerConnected;
    public int[] selectedCoach;

    [SerializeField] ClipMask UIGameClipMask;
    [SerializeField] GameObject mapSelection;
    GameObject background;

    private async void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background");

        string path;
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            path = Application.dataPath;
        }
        else if (Application.platform == RuntimePlatform.WSAPlayerX86)
        {
            path = Application.persistentDataPath;
        }
        else
        {
            path = Path.Combine(Directory.GetCurrentDirectory(), "Build/Just Dance Next_Data");
        }

        songDesc = await Task.Run(async () => JsonConvert.DeserializeObject<SongDesc>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", mapName, "songdesc.json"))));
        musicTrack = await Task.Run(async() => JsonConvert.DeserializeObject<MusicTrack>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", mapName, "musictrack.json"))));
        timeline = await Task.Run(async () => JsonConvert.DeserializeObject<Timeline>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", mapName, "timeline.json"))));

        Color accentColor = new(timeline.lyricColor[0], timeline.lyricColor[1], timeline.lyricColor[2], 1f);

        lyricElements.musicTrack = musicTrack;
        lyricElements.timeline = timeline;
        lyricElements.lyricColor = accentColor;
        lyricElements.timeManager = timeManager;

        pictoElements.songDesc = songDesc;
        pictoElements.musicTrack = musicTrack;
        pictoElements.timeline = timeline;
        pictoElements.accentColor = accentColor;
        pictoElements.timeManager = timeManager;

        moveElements.songDesc = songDesc;
        moveElements.musicTrack = musicTrack;
        moveElements.timeline = timeline;
        moveElements.playerConnected = playerConnected;
        moveElements.selectedCoach = selectedCoach;
        moveElements.timeManager = timeManager;

        mediaElements.musicTrack = musicTrack;
        mediaElements.timeManager = timeManager;
        mediaElements.background = background;

        lyricElements.LoadAllLyrics();

        pictoElements.ApplyPictobarColor();

        mediaElements.LoadMediaAssets(mapName, path);        

        await pictoElements.LoadPictoAssets(mapName, path);        

        await moveElements.LoadAndAssociateAllMoves(mapName, path);

        LeanTween.value(0f, 1f, 0.5f).setOnUpdate((float value) =>
        {
            UIGameClipMask.Tint = new(1f, 1f, 1f, value);
        });
    }

    private async void Update()
    {
        if (!started && mediaElements.isLoaded && pictoElements.isLoaded && !mediaElements.videoPlayer.isPlaying && moveElements.isLoaded)
        {
            mediaElements.Play(musicTrack);
            timeManager.Start();

            await Task.Delay(250);

            UIBlock2D videoTexture = mediaElements.videoPlayer.gameObject.GetComponent<UIBlock2D>();

            LeanTween.value(0f, 1f, 0.1f).setOnUpdate((float value) =>
            {
                videoTexture.Color = new(1f, 1f, 1f, value);
            }).setOnComplete(() =>
            {
                started = true;
            });

        }
        if (!pausePressed && started && InputManager.Undo() && InputManager.source == InputManager.controller | InputManager.source == InputSource.Local)
        {
            pausePressed = true;
            timeManager.Stop();
            LeanTween.cancelAll();
            await Task.Delay(500);
            LeanTween.cancelAll();
            background.SetActive(true);
            for (int i = 0; i < 4; i++)
            {
                if (moveElements.scoring[i] != null)
                {
                    moveElements.scoring[i].EndScore();
                }
            }
            Instantiate(mapSelection);
            Destroy(gameObject);
        }
    }
}
