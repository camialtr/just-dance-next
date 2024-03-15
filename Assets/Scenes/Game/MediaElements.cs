using System.IO;
using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.Networking;
using Nova;

public class MediaElements : MonoBehaviour
{
    [SerializeField] public VideoPlayer videoPlayer;
    [SerializeField] AudioSource audioPlayer;

    [HideInInspector] public bool isLoaded = false;

    UnityWebRequestAsyncOperation audioClip;

    public void LoadMediaAssets(string mapName)
    {
        videoPlayer.url = "file://" + Path.Combine(Application.persistentDataPath, "Maps", mapName, "media", mapName + ".webm");
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
        yield return audioClip = UnityWebRequestMultimedia.GetAudioClip(Path.Combine(Application.persistentDataPath, "Maps", mapName, "media", mapName + ".ogg"), AudioType.OGGVORBIS).SendWebRequest();
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
}
