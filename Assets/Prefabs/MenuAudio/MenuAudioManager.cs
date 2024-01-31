using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource menuAudio;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void StopAudio()
    {
        menuAudio.Stop();
    }
}
