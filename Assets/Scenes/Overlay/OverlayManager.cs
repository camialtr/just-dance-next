using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    [SerializeField] AudioSource popupEnterAudio;
    [SerializeField] AudioSource popupExitAudio;

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

    void EnterAnimationEvent()
    {
        popupEnterAudio.Play();
    }

    void ExitAnimationEvent()
    {
        popupExitAudio.Play();
    }
}
