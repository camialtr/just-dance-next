using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{
    private void Start()
    {
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
