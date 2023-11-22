using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Transporting;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNameTracker : NetworkBehaviour
{
    public static event Action<NetworkConnection, string> OnNameChange;

    [SyncObject]
    private readonly SyncDictionary<NetworkConnection, string> _playerNames = new SyncDictionary<NetworkConnection, string>();

    private static PlayerNameTracker _instance;

    private void Awake()
    {
        _instance = this;
        _playerNames.OnChange += PlayerNames_OnChange;
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        base.NetworkManager.ServerManager.OnRemoteConnectionState += ServerManager_OnRemoteConnectionState;
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        base.NetworkManager.ServerManager.OnRemoteConnectionState -= ServerManager_OnRemoteConnectionState;
    }

    private void ServerManager_OnRemoteConnectionState(NetworkConnection connection, RemoteConnectionStateArgs args)
    {
        if (args.ConnectionState != RemoteConnectionState.Started)
        {
            _playerNames.Remove(connection);
        }
    }

    private void PlayerNames_OnChange(SyncDictionaryOperation op, NetworkConnection key, string value, bool asServer)
    {
        if (op == SyncDictionaryOperation.Add || op == SyncDictionaryOperation.Set) 
        {
            OnNameChange?.Invoke(key, value);
        }
    }

    [Client]
    public static void SetName(string name)
    {
        _instance.ServerSetName(name);
    }

    [ServerRpc(RequireOwnership = false)]
    private void ServerSetName(string name, NetworkConnection sender = null)
    {
        _playerNames[sender] = name;
    }

    internal static string GetPlayerName(NetworkConnection owner)
    {
        if (_instance._playerNames.TryGetValue(owner, out var name))
        {
            return name;
        }
        return "Unset";
    }
}
