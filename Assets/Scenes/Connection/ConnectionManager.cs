using Nova;
using System.Net;
using UnityEngine;
using System.Net.Sockets;
using System.Threading.Tasks;
using Unity.Netcode.Transports.UTP;
using Unity.Netcode;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay.Models;
using Unity.Services.Relay;
using TMPro;
using Nova.TMP;

public class ConnectionManager : MonoBehaviour
{
    [SerializeField] BackgroundManager background;
    [SerializeField] TextBlock relayCode;
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
    [SerializeField] GameObject gameUI;

    bool[] playerConnected;
    bool canInteract = false;
    bool exitPopupShowed = false;
    uint selectedSlot = 0;

    LTDescr[] selectorAnimations;

    private async void Start()
    {
        playerConnected = new bool[4] { false, false, false, false };
        selectorAnimations = new LTDescr[3] { new(), new(), new() };
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(4);
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(allocation, "dtls"));
        relayCode.Text = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
        NetworkManager.Singleton.StartHost();
    }

    private async void Update()
    {
        if (canInteract)
        {
            if (exitPopupShowed)
            {
                if (InputManager.Select())
                {
                    Application.Quit();
                }
                else if (InputManager.Undo())
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
                if (InputManager.Select())
                {
                    switch (selectedSlot)
                    {
                        case 0:
                            
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
                else if (InputManager.Undo())
                {
                    overlayAnimator.Play("Popup-Quit-Enter");
                    exitPopupShowed = true;
                    canInteract = false;
                    await Task.Delay(400);
                    canInteract = true;
                }
                else if (InputManager.Down())
                {
                    uint lastSelectedSlot = selectedSlot;
                    if (selectedSlot != 4)
                    {
                        selectedSlot++;
                    }
                    ToggleSelection(lastSelectedSlot);
                    toggleDownAudio.Play();
                }
                else if (InputManager.Up())
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
        DefineSlotPosition(selectedSlot);
        ToggleEnter();
        selectorAnimations[0] = LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
        selectorAnimations[1] = LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f);
        selectorAnimations[2] = LeanTween.value(0f, 5f, 0.2f).setOnUpdate((float value) =>
        {
            selectorUIBlock.Border.Width = value;
        });
    }

    void EnterAnimationEvent03()
    {
        canInteract = true;
    }

    void ToggleSelection(uint lastSelectedSlot)
    {
        for (int i = 0; i < 3; i++)
        {
            LeanTween.cancel(selectorAnimations[i].uniqueId);
        }
        DefineSlotPosition(lastSelectedSlot);
        selectorAnimations[0] = LeanTween.scaleX(selectorUIBlock.gameObject, 1.02f, 0.2f);
        selectorAnimations[1] = LeanTween.scaleY(selectorUIBlock.gameObject, 1.1f, 0.2f);
        selectorAnimations[2] = LeanTween.value(5f, 0f, 0.2f).setOnUpdate((float value) =>
        {
            selectorUIBlock.Border.Width = value;
        }).setOnComplete(() =>
        {
            DefineSlotPosition(selectedSlot);
            ToggleEnter();
            selectorAnimations[0] = LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
            selectorAnimations[1] = LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f);
            selectorAnimations[2] = LeanTween.value(0f, 5f, 0.2f).setOnUpdate((float value) =>
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
                enterText.Text = "Disconnect";
                break;
            case 1:
                enterButton.SetActive(playerConnected[1]);
                enterText.Text = "Disconnect";
                break;
            case 2:
                enterButton.SetActive(playerConnected[2]);
                enterText.Text = "Disconnect";
                break;
            case 3:
                enterButton.SetActive(playerConnected[3]);
                enterText.Text = "Disconnect";
                break;
            case 4:
                enterButton.SetActive(true);
                enterText.Text = "Select";
                break;
        }
    }

    void DisconnectPlayer(int index)
    {
        canInteract = false;
        selectAudio.Play();
        selectorUIBlock.gameObject.transform.localScale = new Vector3(0.985f, 0.965f, 1f);
        LeanTween.scaleX(selectorUIBlock.gameObject, 1f, 0.2f);
        LeanTween.scaleY(selectorUIBlock.gameObject, 1f, 0.2f).setOnComplete(() =>
        {
            //Server.Dancer[index].breakThread = true;
            //playerConnected[index] = false;
        });
    }

    void ExitAnimationEvent()
    {
        Instantiate(gameUI).GetComponent<GameManager>().connectionUI = gameObject;
        background.StopMenuAudio();
        background.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
