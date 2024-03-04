using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

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
            if (exitPopupShowed)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Application.Quit();
                }
                else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    overlayAnimator.Play("Popup-Quit-Exit");
                    exitPopupShowed = false;
                    canInteract = false;
                    await Task.Delay(333);
                    canInteract = true;
                }                
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    titleAnimator.Play("Title-Exit");
                }
                else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    overlayAnimator.Play("Popup-Quit-Enter");
                    exitPopupShowed = true;
                    canInteract = false;
                    await Task.Delay(400);
                    canInteract = true;
                }
            }
        }
    }

    void EnterAnimationEvent01()
    {
        background.PlayMenuAudio();
        logoAudio.Play();
    }

    void EnterAnimationEvent02()
    {
        canInteract = true;
    }

    void ExitAnimationEvent01()
    {
        canInteract = false;
        selectAudio.Play();
    }

    void ExitAnimationEvent02()
    {        
        exitAudio.Play();
    }

    void ExitAnimationEvent03()
    {
        connectionUI.SetActive(true);
        Destroy(gameObject);
    }

    void PopupAnimationEvent01()
    {
        canInteract = true;
    }
}
