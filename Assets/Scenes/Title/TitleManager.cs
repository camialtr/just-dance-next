using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    BackgroundManager background;

    private void Start()
    {
        background = GameObject.FindWithTag("Background").GetComponent<BackgroundManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadConnection();
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

    public void HideBackgroundGradient()
    {
        background.HideGradient();
    }
}
