using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class TitleManager : MonoBehaviour
{
    BackgroundManager background;
    [SerializeField] MenuAudioManager menuAudio;
    [SerializeField] AudioSource logoAudio;
    [SerializeField] AudioSource selectAudio;
    [SerializeField] AudioSource exitAudio;
    [SerializeField] Animator titleAnimator;
    [SerializeField] Animator popupAnimator;
    [SerializeField] AudioSource popupEnter;
    [SerializeField] AudioSource popupExit;
    bool canInteract = false;
    bool popupShowed = false;

    private void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundManager>();
    }

    private async void Update()
    {
        if (canInteract)
        {
            if (popupShowed)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Application.Quit();
                }
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    popupAnimator.Play("Popup-Exit");
                    popupShowed = false;
                    canInteract = false;
                    popupExit.Play();
                    await Task.Delay(500);
                    canInteract = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    titleAnimator.Play("Title-Exit");
                }
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    popupAnimator.Play("Popup-Enter");
                    popupShowed = true;
                    canInteract = false;
                    popupEnter.Play();
                    await Task.Delay(500);
                    canInteract = true;
                }
            }
        }
    }

    private IEnumerator LoadConnectionAsync()
    {
        AsyncOperation loadSceneAsyncOperation = SceneManager.LoadSceneAsync("Connection");
        while (!loadSceneAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public void EnterAnimationEvent01()
    {
        menuAudio.PlayAudio();
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
        background.ShowGradient();
        exitAudio.Play();
    }

    public void ExitAnimationEvent03()
    {
        StartCoroutine(LoadConnectionAsync());
    }

    public void PopupAnimationEvent01()
    {
        canInteract = true;
    }
}
