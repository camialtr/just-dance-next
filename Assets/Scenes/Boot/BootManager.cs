using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{
    [SerializeField] GameObject titleUI;

    public void BootAnimationEvent01()
    {
        titleUI.SetActive(true);
        Destroy(gameObject);
    }
}
