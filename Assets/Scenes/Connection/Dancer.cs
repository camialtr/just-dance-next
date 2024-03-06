using UnityEngine;
using Unity.Netcode;

public class Dancer : NetworkBehaviour
{
    [SerializeField] NetworkVariable<ulong> dancerCID = new(readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Owner);

    private void Start()
    {
        if (!IsServer && IsOwner)
        {
            gameObject.name = "Dancer " + DancerIndex.value;
            SetDancerNameServerRpc(DancerIndex.value);
        }
    }

    private void Update()
    {
        if (IsServer)
        {
            //Debug.Log("Sended by Server: " + NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetCurrentRtt(OwnerClientId));
        }
        if (!IsServer && IsOwner)
        {
            if (InputManager.input != NetworkInput.None)
            {
                InputUndoServerRpc(InputManager.input);
                InputManager.input = NetworkInput.None;                
            }
        }
    }

    [ServerRpc]
    void SetDancerNameServerRpc(int dancerIndex)
    {
        gameObject.name = "Dancer " + dancerIndex;
    }

    [ServerRpc]
    public void InputUndoServerRpc(NetworkInput input)
    {
        InputManager.input = input;
    }
}
