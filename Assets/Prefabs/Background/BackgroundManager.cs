using Nova;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] ScreenSpace screenSpace;
    [SerializeField] Animator animator;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
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
