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

        bool quit = false;
        for (int i = 0; i < 4; i++)
        {
            if (Server.Dancer[i].isQuitting && Server.Dancer[i].threadBreaked || Server.Dancer[i].isQuitting && !Server.Dancer[i].connected)
            {
                quit = true;
            }
            else
            {
                quit = false;
                break;
            }
        }
        if (quit)
        {
            Application.Quit();
        }
    }

    [System.Obsolete]
    private void OnApplicationQuit()
    {
        bool cancelQuit = false;
        for (int i = 0; i < 4; i++)
        {
            if (!Server.Dancer[i].isQuitting)
            {
                if (!cancelQuit) { cancelQuit = true; }
                Server.Dancer[i].isQuitting = true;
                Server.Dancer[i].breakThread = true;
            }
        }
        if (cancelQuit)
        {
            Application.CancelQuit();
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
