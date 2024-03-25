using Nova;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;

public class RecapManager : MonoBehaviour
{
    public BackgroundManager backgroundManager;

    [SerializeField] ClipMask mainClipMask;
    [SerializeField] GameObject[] dancersObj;
    [SerializeField] TextBlock[] dancersTBScore;
    [SerializeField] AudioSource selectAudio;
    [SerializeField] GameObject mapSelection;
    [SerializeField] UIBlock2D selectorUIBlock;

    public bool[] playerConnected;
    public int[] playerScore;
    bool canInteract = false;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            dancersObj[i].SetActive(playerConnected[i]);
            dancersTBScore[i].Text = playerConnected[i] ? playerScore[i].ToString() : string.Empty;
        }

        backgroundManager.PlayMenuAudio();

        LeanTween.value(0f, 1f, 0.5f).setOnUpdate((float value) =>
        {
            mainClipMask.Tint = new(1f, 1f, 1f, value);
        }).setOnComplete(() =>
        {
            LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
            LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f);
            LeanTween.value(0f, 5f, 0.2f).setOnUpdate((float value) =>
            {
                selectorUIBlock.Border.Width = value;
            }).setOnComplete(() =>
            {
                canInteract = true;
            });
        });
    }

    private void Update()
    {
        if (canInteract)
        {
            if (InputManager.Select() && InputManager.source == InputManager.controller | InputManager.source == InputSource.Local)
            {
                canInteract = false;
                selectAudio.Play();
                selectorUIBlock.gameObject.transform.localScale = new Vector3(0.97f, 0.93f, 1f);
                LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
                LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f).setOnComplete(() =>
                {
                    LeanTween.scaleX(selectorUIBlock.gameObject, 1.02f, 0.2f);
                    LeanTween.scaleY(selectorUIBlock.gameObject, 1.1f, 0.2f);
                    LeanTween.value(5f, 0f, 0.2f).setOnUpdate((float value) =>
                    {
                        selectorUIBlock.Border.Width = value;
                    }).setOnComplete(() =>
                    {
                        LeanTween.value(1f, 0f, 0.5f).setOnUpdate((float value) =>
                        {
                            mainClipMask.Tint = new(1f, 1f, 1f, value);
                        }).setOnComplete(() =>
                        {
                            backgroundManager.StopMenuAudio();
                            Instantiate(mapSelection);
                            Destroy(gameObject);
                        });
                    });
                });
            }
        }
    }
}
