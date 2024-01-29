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

    public void HideGradient()
    {
        animator.Play("Hide_Gradient");
    }
}
