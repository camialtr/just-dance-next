using UnityEngine;
using Unity.Netcode;
using System;

public class Dancer : NetworkBehaviour
{
    public NetworkVariable<Vector3> accelermeterData = new(readPerm: NetworkVariableReadPermission.Everyone, writePerm: NetworkVariableWritePermission.Owner);
    public float pingData;

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
            UpdatePingServerRpc();
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
    }

    [ServerRpc]
    public void InputServerRpc(int dancerIndex,NetworkInput input)
    {
        InputManager.source = (InputSource)dancerIndex;
        InputManager.input = input;
    }

    [ServerRpc]
    public void UpdatePingServerRpc()
    {
        pingData = NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetCurrentRtt(OwnerClientId) / 1000f;
    }
}
