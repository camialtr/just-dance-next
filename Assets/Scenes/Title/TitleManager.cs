using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class TitleManager : MonoBehaviour
{
    [SerializeField] BackgroundManager background;
    [SerializeField] AudioSource logoAudio;
    [SerializeField] AudioSource selectAudio;
    [SerializeField] AudioSource exitAudio;
    [SerializeField] Animator titleAnimator;
    [SerializeField] Animator overlayAnimator;
    [SerializeField] GameObject connectionUI;
    bool canInteract = false;
    bool exitPopupShowed = false;

    private async void Update()
    {
        if (canInteract)
        {
            if (!exitPopupShowed)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    titleAnimator.Play("Title-Exit");
                }
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    overlayAnimator.Play("Popup-Quit-Enter");
                    exitPopupShowed = true;
                    canInteract = false;
                    await Task.Delay(400);
                    canInteract = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Application.Quit();
                }
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    overlayAnimator.Play("Popup-Quit-Exit");
                    exitPopupShowed = false;
                    canInteract = false;
                    await Task.Delay(333);
                    canInteract = true;
                }
            }
        }
    }

    public void EnterAnimationEvent01()
    {
        background.PlayMenuAudio();
        logoAudio.Play();
        background.HideGradient();
    }

    public void EnterAnimationEvent02()
    {
        canInteract = true;
    }

    public void ExitAnimationEvent01()
    {
        selectAudio.Play();
    }

    public void ExitAnimationEvent02()
    {
        background.StopMenuAudio();
        background.ShowGradient();
        exitAudio.Play();
    }

    public void ExitAnimationEvent03()
    {
        Instantiate(connectionUI);
        Destroy(gameObject);
    }

    public void PopupAnimationEvent01()
    {
        canInteract = true;
    }
}
