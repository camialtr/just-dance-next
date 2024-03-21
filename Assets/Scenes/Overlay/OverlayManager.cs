using Newtonsoft.Json;
using NovaSamples.Effects;
using System;
using System.IO;
using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    [SerializeField] GameObject overlayCamera;
    [SerializeField] GameObject background;
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject mobileConnectionUI;

    [SerializeField] AudioSource popupEnterAudio;
    [SerializeField] AudioSource popupExitAudio;

    [SerializeField] RenderTexture[] textures;
    [SerializeField] BlurEffect blurEffect;

    private void Start()
    {
        string path;
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            path = Application.dataPath;
        }
        else if (Application.platform == RuntimePlatform.WSAPlayerX86)
        {
            path = Application.persistentDataPath;
        }
        else
        {
            path = Path.Combine(Directory.GetCurrentDirectory(), "Build/Just Dance Next_Data");
        }

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            overlayCamera.gameObject.SetActive(false);
            background.gameObject.SetActive(false);
            Camera.main.targetTexture = null;
            Instantiate(mobileConnectionUI);
            gameObject.SetActive(false);
        }
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WSAPlayerX86)
        {
            if (!File.Exists(Path.Combine(path + "/settings.json")))
            {
                GlobalSettings.gameSettings = new();
                GlobalSettings.gameSettings.resolution = Resolution.high;
                GlobalSettings.gameSettings.videoResolution = Resolution.ultra;
                File.WriteAllText(Path.Combine(path + "/settings.json"), JsonConvert.SerializeObject(GlobalSettings.gameSettings, Formatting.Indented));
            }

            GlobalSettings.gameSettings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Path.Combine(path + "/settings.json")));
            Camera.main.targetTexture = textures[(int)GlobalSettings.gameSettings.resolution];
            blurEffect.InputTexture = textures[(int)GlobalSettings.gameSettings.resolution];

            LeanTween.init(2500);
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                Cursor.visible = false;
            }
            Instantiate(titleUI);
        }
    }

    void EnterAnimationEvent()
    {
        popupEnterAudio.Play();
    }

    void ExitAnimationEvent()
    {
        popupExitAudio.Play();
    }
}

public struct Settings
{
    public Resolution resolution;
    public Resolution videoResolution;
}

public enum Resolution
{
    low,
    medium,
    high,
    ultra
}

public static class GlobalSettings
{
    public static Settings gameSettings;
}