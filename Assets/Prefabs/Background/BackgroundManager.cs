using Nova;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] ScreenSpace screenSpace;
    [SerializeField] Animator animator;

    private void Start()
    {
        DontDestroyOnLoad(this);
        Screen.SetResolution(3840, 2160, true);
    }

    private void Update()
    {
        if (!Screen.fullScreen)
        {
            Screen.SetResolution(3840, 2160, true);
        }

        if (Cursor.visible)
        {
            Cursor.visible = false;
        }

        if (screenSpace.TargetCamera == null)
        {
            screenSpace.TargetCamera = Camera.main;
        }
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
