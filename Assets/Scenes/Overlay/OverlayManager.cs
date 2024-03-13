using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject mobileConnectionUI;

    [SerializeField] AudioSource popupEnterAudio;
    [SerializeField] AudioSource popupExitAudio;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Instantiate(mobileConnectionUI);
        }
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            LeanTween.init(5000);
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                Cursor.visible = false;
            }
            Instantiate(titleUI);
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
