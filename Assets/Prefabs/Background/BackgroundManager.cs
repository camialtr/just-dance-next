using Nova;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] AudioSource menuAudio;

    public void PlayMenuAudio()
    {
        menuAudio.Play();
    }

    public void StopMenuAudio()
    {
        menuAudio.Stop();
    }
}
