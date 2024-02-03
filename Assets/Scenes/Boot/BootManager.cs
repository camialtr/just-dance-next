using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{
    AsyncOperation loadSceneAsyncOperation;

    private IEnumerator LoadTitleAsync()
    {
        loadSceneAsyncOperation = SceneManager.LoadSceneAsync("Title");
        while (!loadSceneAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public void BootAnimationEvent01()
    {
        StartCoroutine(LoadTitleAsync());
    }
}
