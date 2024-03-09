using UnityEngine;
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

    private void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundManager>();
        overlayAnimator = GameObject.Find("UI-Overlay").GetComponent<Animator>();
    }

    private async void Update()
    {
        if (canInteract)
        {
            if (exitPopupShowed)
            {
                if (InputManager.Select())
                {
                    Application.Quit();
                }
                else if (InputManager.Undo())
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
                if (InputManager.Select())
                {
                    titleAnimator.Play("Title-Exit");
                }
                else if (InputManager.Undo())
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
        Instantiate(connectionUI);
        Destroy(gameObject);
    }

    void PopupAnimationEvent01()
    {
        canInteract = true;
    }
}
