using Nova;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] ScreenSpace screenSpace;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource menuAudio;

    public void PlayMenuAudio()
    {
        menuAudio.Play();
    }

    public void StopMenuAudio()
    {
        menuAudio.Stop();
    }

    public void ShowGradient()
    {
        animator.Play("Show-Gradient");
    }

    public void HideGradient()
    {
        animator.Play("Hide-Gradient");
    }
}
