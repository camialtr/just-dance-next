using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

public class Game : MonoBehaviour
{
    public string mapName;

    MusicTrack musicTrack;
    Timeline timeline;

    [SerializeField] MediaElements mediaElements;
    [SerializeField] LyricElements lyricElements;

    readonly Stopwatch timeManager = new();

    private async void Start()
    {
        string path = Application.persistentDataPath;
        LeanTween.init(3000);

        musicTrack = await Task.Run(async() => JsonConvert.DeserializeObject<MusicTrack>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", mapName, "musictrack.json"))));
        timeline = await Task.Run(async () => JsonConvert.DeserializeObject<Timeline>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", mapName, "timeline.json"))));

        mediaElements.LoadMediaAssets(mapName);

        lyricElements.musicTrack = musicTrack;
        lyricElements.timeline = timeline;
        lyricElements.lyricColor = new Color(timeline.lyricColor[0], timeline.lyricColor[1], timeline.lyricColor[2], 1f);
        lyricElements.timeManager = timeManager;
    }

    private void Update()
    {
        if (mediaElements.isLoaded && !mediaElements.isPlaying)
        {
            mediaElements.Play(musicTrack);
            timeManager.Start();
        }
    }
}
