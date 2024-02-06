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

    public void EnterAnimationEvent()
    {
        popupEnterAudio.Play();
    }

    public void ExitAnimationEvent()
    {
        popupExitAudio.Play();
    }
}
