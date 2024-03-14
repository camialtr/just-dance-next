using Nova;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] AudioSource menuAudio;

    private void Start()
    {
        LeanTween.init(5000);
    }

    public void PlayMenuAudio()
    {
        menuAudio.Play();
    }

    public void StopMenuAudio()
    {
        menuAudio.Pause();
    }
}
