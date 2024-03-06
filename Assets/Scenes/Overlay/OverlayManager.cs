using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject connectionUI;
    [SerializeField] GameObject mobileConnectionUI;

    [SerializeField] AudioSource popupEnterAudio;
    [SerializeField] AudioSource popupExitAudio;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            mobileConnectionUI.SetActive(true);
            Destroy(connectionUI);
            Destroy(titleUI);
            Destroy(gameObject);
        }
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            LeanTween.init(5000);
            if (Cursor.visible)
            {
                Cursor.visible = false;
            }
            titleUI.SetActive(true);
            Destroy(mobileConnectionUI);
            //mobileConnectionUI.SetActive(true);
            //Destroy(connectionUI);
            //Destroy(titleUI);
            //Destroy(gameObject);
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
