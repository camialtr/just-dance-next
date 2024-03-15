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
    GameObject background;

    private async void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background");

        string path = Application.persistentDataPath;

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

        await Task.Delay(500);

        LeanTween.value(0f, 1f, 0.5f).setOnUpdate((float value) =>
        {
            UIGameClipMask.Tint = new(1f, 1f, 1f, value);
        }).setOnComplete(async () =>
        {
            mediaElements.LoadMediaAssets(mapName);

            await pictoElements.LoadPictoAssets(mapName, path);
        });
    }

    private async void Update()
    {
        if (mediaElements.isLoaded && pictoElements.isLoaded && !mediaElements.videoPlayer.isPlaying)
        {
            mediaElements.Play(musicTrack);
            timeManager.Start();

            UIBlock2D mediaTexture = mediaElements.videoPlayer.gameObject.GetComponent<UIBlock2D>();
                        
            LeanTween.value(0f, 1f, 0.5f).setOnUpdate((float value) =>
            {
                mediaTexture.Color = new(1f, 1f, 1f, value);
            }).setOnComplete(() =>
            {
                background.SetActive(false);
            });
        }
    }
}
