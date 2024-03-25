using Nova;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using System.Diagnostics;
using System.Collections;
using UnityEngine.Networking;


public class MediaElements : MonoBehaviour
{
    [HideInInspector] public MusicTrack musicTrack;

    [SerializeField] public VideoPlayer videoPlayer;
    [SerializeField] public AudioSource audioPlayer;
    [SerializeField] RenderTexture[] textures;
    [HideInInspector] public Stopwatch timeManager;
    [HideInInspector] public GameObject background;

    [HideInInspector] public bool isLoaded = false;
    int atualBeat = 0;

    UnityWebRequestAsyncOperation audioClip;

    public void LoadMediaAssets(string mapName, string path)
    {
        videoPlayer.url = "file://" + Path.Combine(path, "Maps", mapName, "media", mapName + ".webm");
        videoPlayer.targetTexture = textures[(int)GlobalSettings.gameSettings.videoResolution];
        videoPlayer.GetComponent<UIBlock2D>().SetImage(textures[(int)GlobalSettings.gameSettings.videoResolution]);
        videoPlayer.prepareCompleted += VideoPlayer_prepareCompleted;
        videoPlayer.Prepare();
        StartCoroutine(LoadMedia(mapName));
    }

    private void VideoPlayer_prepareCompleted(VideoPlayer source)
    {
        if (audioClip != null && audioClip.isDone)
        {
            isLoaded = true;
        }
    }

    IEnumerator LoadMedia(string mapName)
    {
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
        };

        yield return audioClip = UnityWebRequestMultimedia.GetAudioClip(Path.Combine(path, "Maps", mapName, "media", mapName + ".ogg"), AudioType.OGGVORBIS).SendWebRequest();
        audioPlayer.clip = DownloadHandlerAudioClip.GetContent(audioClip.webRequest);
        if (videoPlayer.isPrepared)
        {
            isLoaded = true;
        }
    }

    public void Play(MusicTrack musicTrack)
    {
        videoPlayer.time = musicTrack.videoStartTime - musicTrack.beats[musicTrack.startBeat];
        videoPlayer.Play();
        audioPlayer.Play();
    }

    private void Update()
    {
        if (timeManager == null || !timeManager.IsRunning) { return; }

        if (atualBeat < musicTrack.beats.Count && timeManager.ElapsedMilliseconds / 1000f >= musicTrack.beats[atualBeat] && audioPlayer.isPlaying)
        {
            if (atualBeat > 10)
            {
                if (background.activeInHierarchy)
                {
                    background.SetActive(false);
                }                
            }
            float correctionFactor = musicTrack.videoStartTime - musicTrack.beats[musicTrack.startBeat];
            float timeInMS = timeManager.ElapsedMilliseconds / 1000f;

            if (videoPlayer.time < timeInMS + correctionFactor - 0.25f || videoPlayer.time > timeInMS + correctionFactor + 0.25f)
            {
                videoPlayer.Pause();
                videoPlayer.time = timeInMS + correctionFactor;
                videoPlayer.Play();
            }
            if (audioPlayer.time < timeInMS - 0.1f || audioPlayer.time > timeInMS + 0.1f)
            {
                audioPlayer.Pause();
                audioPlayer.time = timeInMS;
                audioPlayer.Play();
            }
            atualBeat++;
        }
    }
}
