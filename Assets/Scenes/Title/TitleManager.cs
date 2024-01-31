using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    BackgroundManager background;
    [SerializeField] AudioSource menuAudio;
    [SerializeField] AudioSource logoAudio;
    [SerializeField] Animator titleAnimator;
    bool canStart = false;

    private void Start()
    {
        background = GameObject.FindWithTag("Background").GetComponent<BackgroundManager>();
    }

    private void Update()
    {
        if (canStart)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                titleAnimator.Play("Title-Exit");
            }
        }
    }

    public void LoadConnection()
    {
        StartCoroutine(LoadConnectionAsync());
    }

    private IEnumerator LoadConnectionAsync()
    {
        AsyncOperation loadSceneAsyncOperation = SceneManager.LoadSceneAsync("Connection");
        while (!loadSceneAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public void ShowBkgGradient()
    {
        background.ShowGradient();
    }

    public void HideBkgGradient()
    {
        background.HideGradient();
    }

    public void PlayMenuAudio()
    {
        menuAudio.Play();
    }

    public void PlayLogoAudio()
    {
        logoAudio.Play();
    }

    public void EnableStart()
    {
        canStart = true;
    }
}
