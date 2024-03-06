using Nova;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class MobileConnectionManager : MonoBehaviour
{
    [SerializeField] GameObject input;
    [SerializeField] GameObject connect;
    [SerializeField] GameObject dancer01;
    [SerializeField] GameObject dancer02;
    [SerializeField] GameObject dancer03;
    [SerializeField] GameObject dancer04;

    [SerializeField] GameObject undo;
    [SerializeField] GameObject select;
    [SerializeField] GameObject up;
    [SerializeField] GameObject down;
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;

    [SerializeField] Dancer dancer;

    [SerializeField] TextBlock inputText;

    public void ConnectButtonPress()
    {
        input.SetActive(false);
        connect.SetActive(false);
        dancer01.SetActive(true);
        dancer02.SetActive(true);
        dancer03.SetActive(true);
        dancer04.SetActive(true);
    }

    public void DancerButtonPress(int index)
    {
        DancerIndex.value = index;
        try
        {
            NetworkManager.Singleton.gameObject.GetComponent<UnityTransport>().ConnectionData.Address = inputText.Text;
            NetworkManager.Singleton.StartClient();
            dancer01.SetActive(false);
            dancer02.SetActive(false);
            dancer03.SetActive(false);
            dancer04.SetActive(false);
            undo.SetActive(true);
            select.SetActive(true);
            up.SetActive(true);
            down.SetActive(true);
            left.SetActive(true);
            right.SetActive(true);
        }
        catch
        {
            input.SetActive(true);
            connect.SetActive(true);
            dancer01.SetActive(false);
            dancer02.SetActive(false);
            dancer03.SetActive(false);
            dancer04.SetActive(false);
        }
    }

    public void InputButtonPress(int inputIndex)
    {
        InputManager.input = (NetworkInput)inputIndex;
    }
}

public static class DancerIndex
{
    public static int value = 0;
}
