using UnityEngine;
using Unity.Netcode;

public class Dancer : NetworkBehaviour
{
    public NetworkVariable<Vector3> accelermeterData = new NetworkVariable<Vector3>(readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Owner);

    private void Start()
    {
        if (!IsServer && IsOwner)
        {
            ConfigureDancerServerRpc(DancerIdentifier.index);
        }
    }

    private void Update()
    {
        if (!IsServer && IsOwner)
        {
            accelermeterData.Value = Input.acceleration;
            if (InputManager.input != NetworkInput.None)
            {
                InputServerRpc(DancerIdentifier.index, InputManager.input);
                InputManager.input = NetworkInput.None;
            }
        }
    }

    [ServerRpc]
    void ConfigureDancerServerRpc(int dancerIndex)
    {
        gameObject.name = "Dancer " + dancerIndex;
        if (DancerIdentifier.dancers[dancerIndex -1] == null)
        {
            DancerIdentifier.dancers[dancerIndex - 1] = this;
        }
        else
        {
            NetworkManager.Singleton.DisconnectClient(OwnerClientId);
        }
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(DancerIdentifier.dancers[i]);
        }
    }

    [ServerRpc]
    public void InputServerRpc(int dancerIndex,NetworkInput input)
    {
        InputManager.source = (InputSource)dancerIndex;
        InputManager.input = input;
    }    
}
