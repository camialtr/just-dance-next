using Nova;
using System.Net;
using UnityEngine;
using System.Net.Sockets;
using System.Threading.Tasks;

public class ConnectionManager : MonoBehaviour
{
    [SerializeField] BackgroundManager background;
    [SerializeField] TextBlock IPAdress;
    [SerializeField] Animator connectionAnimator;
    [SerializeField] Animator overlayAnimator;
    [SerializeField] UIBlock2D selectorUIBlock;
    [SerializeField] AudioSource enterAudio;
    [SerializeField] AudioSource exitAudio;
    [SerializeField] AudioSource selectAudio;
    [SerializeField] AudioSource toggleUpAudio;
    [SerializeField] AudioSource toggleDownAudio;
    [SerializeField] AudioSource pConnectedAudio;
    [SerializeField] GameObject enterButton;
    [SerializeField] TextBlock enterText;
    [SerializeField] UIBlock2D p01LoadingUIBlock;
    [SerializeField] UIBlock2D p01ConnectedUIBlock;
    bool canInteract = false;
    bool exitPopupShowed = false;
    uint selectedSlot = 0;

    bool p01Connected = false;
    bool p02Connected = false;
    bool p03Connected = false;
    bool p04Connected = false;

    private void Start()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                IPAdress.Text = ip.ToString();
            }
        }
    }

    private async void Update()
    {
        if (Dancer01Server.connected && !Dancer01Server.breakThread && !p01Connected)
        {
            p01Connected = true;
            LeanTween.scaleX(p01LoadingUIBlock.gameObject, 0.3f, 0.1f);
            LeanTween.scaleY(p01LoadingUIBlock.gameObject, 0.3f, 0.1f);
            LeanTween.value(1f, 0f, 0.1f).setOnUpdate((float value) =>
            {
                p01LoadingUIBlock.Color = new(1f, 1f, 1f, value);
            }).setOnComplete(() =>
            {
                pConnectedAudio.Play();
                p01ConnectedUIBlock.gameObject.transform.localScale = new(0.3f, 0.3f, 1f);
                ToggleEnter();
                LeanTween.scaleX(p01ConnectedUIBlock.gameObject, 0.4f, 0.1f);
                LeanTween.scaleY(p01ConnectedUIBlock.gameObject, 0.4f, 0.1f);
                LeanTween.value(0f, 1f, 0.1f).setOnUpdate((float value) =>
                {
                    p01ConnectedUIBlock.Color = new(1f, 1f, 1f, value);
                });
            });
        }

        if (!Dancer01Server.connected && !Dancer01Server.breakThread && Dancer01Server.threadBreaked)
        {
            Dancer01Server.Disconnect();
            LeanTween.scaleX(p01ConnectedUIBlock.gameObject, 0.3f, 0.1f);
            LeanTween.scaleY(p01ConnectedUIBlock.gameObject, 0.3f, 0.1f);
            LeanTween.value(1f, 0f, 0.1f).setOnUpdate((float value) =>
            {
                p01ConnectedUIBlock.Color = new(1f, 1f, 1f, value);
            }).setOnComplete(() =>
            {
                pConnectedAudio.Play();
                p01LoadingUIBlock.gameObject.transform.localScale = new(0.3f, 0.3f, 1f);
                ToggleEnter();
                LeanTween.scaleX(p01LoadingUIBlock.gameObject, 0.4f, 0.1f);
                LeanTween.scaleY(p01LoadingUIBlock.gameObject, 0.4f, 0.1f);
                LeanTween.value(0f, 1f, 0.1f).setOnUpdate((float value) =>
                {
                    p01LoadingUIBlock.Color = new(1f, 1f, 1f, value);
                });
            });
            Dancer01Server.Connect(IPAdress.Text);
        }

        if (canInteract)
        {
            if (exitPopupShowed)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Application.Quit();
                }
                else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    overlayAnimator.Play("Popup-Quit-Exit");
                    exitPopupShowed = false;
                    canInteract = false;
                    await Task.Delay(333);
                    canInteract = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    switch (selectedSlot)
                    {
                        case 0:
                            if (p01Connected)
                            {
                                Dancer01Server.breakThread = true;
                                p01Connected = false;
                                selectAudio.Play();
                                selectorUIBlock.gameObject.transform.localScale = new Vector3(0.985f, 0.965f, 1f);
                                LeanTween.cancelAll();
                                LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
                                LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f);
                            }
                            break;
                        case 1:
                            
                            break;
                        case 2:
                            
                            break;
                        case 3:
                            
                            break;
                        case 4:
                            canInteract = false;
                            selectAudio.Play();
                            selectorUIBlock.gameObject.transform.localScale = new Vector3(0.97f, 0.93f, 1f);
                            LeanTween.cancelAll();
                            LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
                            LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f).setOnComplete(() =>
                            {
                                exitAudio.Play();
                                connectionAnimator.Play("Connection-Exit");
                                LeanTween.scaleX(selectorUIBlock.gameObject, 1.02f, 0.2f);
                                LeanTween.scaleY(selectorUIBlock.gameObject, 1.1f, 0.2f);
                                LeanTween.value(5f, 0f, 0.2f).setOnUpdate((float value) =>
                                {
                                    selectorUIBlock.Border.Width = value;
                                });
                            });
                            break;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    overlayAnimator.Play("Popup-Quit-Enter");
                    exitPopupShowed = true;
                    canInteract = false;
                    await Task.Delay(400);
                    canInteract = true;
                }
                else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    uint lastSelectedSlot = selectedSlot;
                    if (selectedSlot != 4)
                    {
                        selectedSlot++;
                    }
                    ToggleSelection(lastSelectedSlot);
                    toggleDownAudio.Play();
                }
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    uint lastSelectedSlot = selectedSlot;
                    if (selectedSlot != 0)
                    {
                        selectedSlot--;
                    }
                    ToggleSelection(lastSelectedSlot);
                    toggleUpAudio.Play();
                }
            }
        }
    }

    void EnterAnimationEvent01()
    {
        enterAudio.Play();
    }

    void EnterAnimationEvent02()
    {
        LeanTween.value(0f, 5f, 0.2f).setOnUpdate((float value) =>
        {
            selectorUIBlock.Border.Width = value;
        });
    }

    void EnterAnimationEvent03()
    {
        canInteract = true;
        Dancer01Server.Connect(IPAdress.Text);
    }

    void ToggleSelection(uint lastSelectedSlot)
    {
        LeanTween.cancelAll();
        DefineSlotPosition(lastSelectedSlot);
        LeanTween.scaleX(selectorUIBlock.gameObject, 1.02f, 0.2f);
        LeanTween.scaleY(selectorUIBlock.gameObject, 1.1f, 0.2f);
        LeanTween.value(5f, 0f, 0.2f).setOnUpdate((float value) =>
        {
            selectorUIBlock.Border.Width = value;
        }).setOnComplete(() =>
        {
            DefineSlotPosition(selectedSlot);
            ToggleEnter();
            LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
            LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f);
            LeanTween.value(0f, 5f, 0.2f).setOnUpdate((float value) =>
            {
                selectorUIBlock.Border.Width = value;
            });
        });
    }

    void DefineSlotPosition(uint slot)
    {
        switch (slot)
        {
            case 0:
                selectorUIBlock.CornerRadius.Value = 20f;
                selectorUIBlock.Size = new(510f, 90f, selectorUIBlock.Size.Z);
                selectorUIBlock.Position = new(-441f, 207.285f, 0f);
                break;
            case 1:
                selectorUIBlock.CornerRadius.Value = 20f;
                selectorUIBlock.Size = new(510f, 90f, selectorUIBlock.Size.Z);
                selectorUIBlock.Position = new(-441f, 87.285f, 0f);
                break;
            case 2:
                selectorUIBlock.CornerRadius.Value = 20f;
                selectorUIBlock.Size = new(510f, 90f, selectorUIBlock.Size.Z);
                selectorUIBlock.Position = new(-441f, -32.715f, 0f);
                break;
            case 3:
                selectorUIBlock.CornerRadius.Value = 20f;
                selectorUIBlock.Size = new(510f, 90f, selectorUIBlock.Size.Z);
                selectorUIBlock.Position = new(-441f, -152.717f, 0f);
                break;
            case 4:
                selectorUIBlock.CornerRadius.Value = 60f;
                selectorUIBlock.Size = new(260f, 75f, selectorUIBlock.Size.Z);
                selectorUIBlock.Position = new(385f, -464.172f, 0f);
                break;
        }
    }

    void ToggleEnter()
    {
        switch (selectedSlot)
        {
            case 0:
                enterButton.SetActive(p01Connected);
                enterText.Text = "Disconect";
                break;
            case 1:
                enterButton.SetActive(p02Connected);
                enterText.Text = "Disconect";
                break;
            case 2:
                enterButton.SetActive(p03Connected);
                enterText.Text = "Disconect";
                break;
            case 3:
                enterButton.SetActive(p04Connected);
                enterText.Text = "Disconect";
                break;
            case 4:
                enterButton.SetActive(true);
                enterText.Text = "Select";
                break;
        }
    }

    void ExitAnimationEvent()
    {
        //Next Scene
        background.StopMenuAudio();
        Destroy(gameObject);
    }
}
