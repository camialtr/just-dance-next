using Nova;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] ScreenSpace screenSpace;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource menuAudio;

    private void Update()
    {
        if (!Screen.fullScreen)
        {
            Screen.SetResolution(1920, 1080, true);
        }

        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
    }

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
