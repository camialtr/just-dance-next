using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class Game : MonoBehaviour
{
    public string mapName;

    MusicTrack musicTrack;
    Timeline timeline;

    [SerializeField] MediaElements mediaElements;

    private async void Start()
    {
        string path = Application.persistentDataPath;

        musicTrack = await Task.Run(async() => JsonConvert.DeserializeObject<MusicTrack>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", mapName, "musictrack.json"))));
        timeline = await Task.Run(async () => JsonConvert.DeserializeObject<Timeline>(await File.ReadAllTextAsync(Path.Combine(path, "Maps", mapName, "timeline.json"))));

        mediaElements.LoadMediaAssets(mapName);
    }

    private void Update()
    {
        if (mediaElements.isLoaded && !mediaElements.isPlaying)
        {
            mediaElements.Play(musicTrack);
        }
    }
}
