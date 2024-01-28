using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private void Start()
    {

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
}
