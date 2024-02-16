using Nova;
using System.Net;
using UnityEngine;
using System.Net.Sockets;
using System.Threading.Tasks;

public class ConnectionManager : MonoBehaviour
{
    [SerializeField] BackgroundManager background;
    [SerializeField] TextBlock ipAdress;
    [SerializeField] Animator connectionAnimator;
    [SerializeField] Animator overlayAnimator;
    [SerializeField] UIBlock2D selectorUIBlock;
    [SerializeField] AudioSource enterAudio;
    [SerializeField] AudioSource exitAudio;
    [SerializeField] AudioSource selectAudio;
    [SerializeField] AudioSource toggleUpAudio;
    [SerializeField] AudioSource toggleDownAudio;
    [SerializeField] AudioSource connectedAudio;
    [SerializeField] GameObject enterButton;
    [SerializeField] TextBlock enterText;
    [SerializeField] UIBlock2D[] loadingUIBlock;
    [SerializeField] UIBlock2D[] connectedUIBlock;
    bool[] playerConnected;
    bool canInteract = false;
    bool exitPopupShowed = false;
    uint selectedSlot = 0;

    private void Start()
    {
        playerConnected = new bool[4] { false, false, false, false };
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                ipAdress.Text = ip.ToString();
            }
        }
    }

    private async void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!Server.Dancer[i].isQuitting && !Server.Dancer[i].breakThread)
            {
                if (Server.Dancer[i].connected && !playerConnected[i])
                {
                    ToggleConnection(i, true);
                }
                if (!Server.Dancer[i].connected && Server.Dancer[i].threadBreaked)
                {
                    ToggleConnection(i, false);
                }
            }
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
                            if (playerConnected[0])
                            {
                                Server.Dancer[0].breakThread = true;
                                playerConnected[0] = false;
                                selectAudio.Play();
                                selectorUIBlock.gameObject.transform.localScale = new Vector3(0.985f, 0.965f, 1f);
                                LeanTween.cancelAll();
                                LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
                                LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f);
                            }
                            break;
                        case 1:
                            if (playerConnected[1])
                            {
                                Server.Dancer[1].breakThread = true;
                                playerConnected[1] = false;
                                selectAudio.Play();
                                selectorUIBlock.gameObject.transform.localScale = new Vector3(0.985f, 0.965f, 1f);
                                LeanTween.cancelAll();
                                LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
                                LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f);
                            }
                            break;
                        case 2:
                            if (playerConnected[2])
                            {
                                Server.Dancer[2].breakThread = true;
                                playerConnected[2] = false;
                                selectAudio.Play();
                                selectorUIBlock.gameObject.transform.localScale = new Vector3(0.985f, 0.965f, 1f);
                                LeanTween.cancelAll();
                                LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
                                LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f);
                            }
                            break;
                        case 3:
                            if (playerConnected[3])
                            {
                                Server.Dancer[3].breakThread = true;
                                playerConnected[3] = false;
                                selectAudio.Play();
                                selectorUIBlock.gameObject.transform.localScale = new Vector3(0.985f, 0.965f, 1f);
                                LeanTween.cancelAll();
                                LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
                                LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f);
                            }
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
        for (int i = 0; i < 4; i++)
        {
            Server.Dancer[i].Connect(ipAdress.Text, i);
        }        
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
                enterButton.SetActive(playerConnected[0]);
                enterText.Text = "Disconect";
                break;
            case 1:
                enterButton.SetActive(playerConnected[1]);
                enterText.Text = "Disconect";
                break;
            case 2:
                enterButton.SetActive(playerConnected[2]);
                enterText.Text = "Disconect";
                break;
            case 3:
                enterButton.SetActive(playerConnected[3]);
                enterText.Text = "Disconect";
                break;
            case 4:
                enterButton.SetActive(true);
                enterText.Text = "Select";
                break;
        }
    }

    void ToggleConnection(int index, bool connected)
    {
        if (connected)
        {
            playerConnected[index] = true;
            LeanTween.scaleX(loadingUIBlock[index].gameObject, 0.3f, 0.1f);
            LeanTween.scaleY(loadingUIBlock[index].gameObject, 0.3f, 0.1f);
            LeanTween.value(1f, 0f, 0.1f).setOnUpdate((float value) =>
            {
                loadingUIBlock[index].Color = new(1f, 1f, 1f, value);
            }).setOnComplete(() =>
            {
                connectedAudio.Play();
                connectedUIBlock[index].gameObject.transform.localScale = new(0.3f, 0.3f, 1f);
                ToggleEnter();
                LeanTween.scaleX(connectedUIBlock[index].gameObject, 0.4f, 0.1f);
                LeanTween.scaleY(connectedUIBlock[index].gameObject, 0.4f, 0.1f);
                LeanTween.value(0f, 1f, 0.1f).setOnUpdate((float value) =>
                {
                    connectedUIBlock[index].Color = new(1f, 1f, 1f, value);
                });
            });
        }
        else
        {
            Server.Dancer[index].Disconnect();
            LeanTween.scaleX(connectedUIBlock[index].gameObject, 0.3f, 0.1f);
            LeanTween.scaleY(connectedUIBlock[index].gameObject, 0.3f, 0.1f);
            LeanTween.value(1f, 0f, 0.1f).setOnUpdate((float value) =>
            {
                connectedUIBlock[index].Color = new(1f, 1f, 1f, value);
            }).setOnComplete(() =>
            {
                connectedAudio.Play();
                loadingUIBlock[index].gameObject.transform.localScale = new(0.3f, 0.3f, 1f);
                ToggleEnter();
                LeanTween.scaleX(loadingUIBlock[index].gameObject, 0.4f, 0.1f);
                LeanTween.scaleY(loadingUIBlock[index].gameObject, 0.4f, 0.1f);
                LeanTween.value(0f, 1f, 0.1f).setOnUpdate((float value) =>
                {
                    loadingUIBlock[index].Color = new(1f, 1f, 1f, value);
                });
            });
            Server.Dancer[index].Connect(ipAdress.Text, index);
        }        
    }

    void ExitAnimationEvent()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!Server.Dancer[i].connected)
            {
                Server.Dancer[i].Disconnect();
            }
        }
        background.StopMenuAudio();
        Destroy(gameObject);
    }
}
