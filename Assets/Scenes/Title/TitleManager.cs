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
    [SerializeField] GameObject gameUI;
    bool canInteract = false;

    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                titleAnimator.Play("Title-Exit");
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
        Instantiate(gameUI);
        Destroy(gameObject);
    }

    public void PopupAnimationEvent01()
    {
        canInteract = true;
    }
}
