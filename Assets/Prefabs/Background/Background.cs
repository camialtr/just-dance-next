using Nova;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] ScreenSpace screenSpace;

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
}
