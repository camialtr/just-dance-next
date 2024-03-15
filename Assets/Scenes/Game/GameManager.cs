using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using Nova;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public string mapName;

    SongDesc songDesc;
    MusicTrack musicTrack;
    Timeline timeline;

    [SerializeField] MediaElements mediaElements;
    [SerializeField] LyricElements lyricElements;
    [SerializeField] PictoElements pictoElements;

    readonly Stopwatch timeManager = new();

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

        pictoElements.ApplyPictobarColor();

        mediaElements.LoadMediaAssets(mapName);

        await pictoElements.LoadPictoAssets(mapName, path);

        LeanTween.value(0f, 1f, 0.5f).setOnUpdate((float value) =>
        {
            UIGameClipMask.Tint = new(1f, 1f, 1f, value);
        });
    }

    private async void Update()
    {
        if (mediaElements.isLoaded && pictoElements.isLoaded && !mediaElements.videoPlayer.isPlaying)
        {
            mediaElements.Play(musicTrack);
            timeManager.Start();

            await Task.Delay(500);

            UIBlock2D videoTexture = mediaElements.videoPlayer.gameObject.GetComponent<UIBlock2D>();

            LeanTween.value(0f, 1f, 0.5f).setOnUpdate((float value) =>
            {
                videoTexture.Color = new(1f, 1f, 1f, value);
            });

        }
        if (InputManager.Undo() && InputManager.source == InputManager.controller | InputManager.source == InputSource.Local)
        {
            LeanTween.cancelAll();
            background.SetActive(true);
            Instantiate(mapSelection);
            Destroy(gameObject);
        }
    }
}
