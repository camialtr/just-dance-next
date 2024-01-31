using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{
    private void Start()
    {
        Screen.fullScreen = true;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadTitle()
    {
        StartCoroutine(LoadTitleAsync());
    }

    private IEnumerator LoadTitleAsync()
    {
        AsyncOperation loadSceneAsyncOperation = SceneManager.LoadSceneAsync("Title");
        while (!loadSceneAsyncOperation.isDone)
        {
            yield return null;
        }
    }
}
