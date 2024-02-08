using Nova;
using System.Net;
using UnityEngine;
using System.Net.Sockets;

public class ConnectionManager : MonoBehaviour
{
    [SerializeField] TextBlock IPAdress;
    [SerializeField] Animator connectionAnimator;
    [SerializeField] UIBlock2D selectorUIBlock;
    [SerializeField] AudioSource toggleUpAudio;
    [SerializeField] AudioSource toggleDownAudio;
    bool canInteract = true;
    uint selectedSlot = 0;

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

    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
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
}
