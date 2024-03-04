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

    [SerializeField] public GameObject connectionUI;

    readonly Stopwatch timeManager = new();

    private async void Start()
    {
        string path = Application.persistentDataPath;        

        songDesc = await Task.Run(async () => JsonConvert.DeserializeObject<SongDesc>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", mapName, "songdesc.json"))));
        musicTrack = await Task.Run(async() => JsonConvert.DeserializeObject<MusicTrack>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", mapName, "musictrack.json"))));
        timeline = await Task.Run(async () => JsonConvert.DeserializeObject<Timeline>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", mapName, "timeline.json"))));

        mediaElements.LoadMediaAssets(mapName);

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

        await pictoElements.LoadPictoAssets(mapName, path);
    }

    private void Update()
    {
        if (mediaElements.isLoaded && pictoElements.isLoaded && !mediaElements.isPlaying)
        {
            mediaElements.Play(musicTrack);
            timeManager.Start();
        }
        if (InputManager.Undo())
        {
            connectionUI.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
