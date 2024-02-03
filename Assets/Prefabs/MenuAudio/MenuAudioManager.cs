using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource menuAudio;

    private void Start()
    {
        DontDestroyOnLoad(this);
        menuAudio.Play();
        menuAudio.Stop();
    }

    public void PlayAudio()
    {
        menuAudio.Play();
    }

    public void StopAudio()
    {
        menuAudio.Stop();
    }
}
