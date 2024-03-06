using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    [SerializeField] AudioSource popupEnterAudio;
    [SerializeField] AudioSource popupExitAudio;

    private void Start()
    {
        LeanTween.init(5000);

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
