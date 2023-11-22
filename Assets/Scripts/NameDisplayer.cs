using FishNet.Connection;
using FishNet.Object;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameDisplayer : NetworkBehaviour
{
    [SerializeField]
    private TextMeshPro _text;

    public override void OnStartClient()
    {
        base.OnStartClient();
        SetName();
        PlayerNameTracker.OnNameChange += PlayerNameTracker_OnNameChange;
    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        PlayerNameTracker.OnNameChange -= PlayerNameTracker_OnNameChange;
    }

    private void PlayerNameTracker_OnNameChange(NetworkConnection connection, string arg2)
    {
        if (connection != base.Owner) { return; }

        SetName();
    }

    public override void OnOwnershipClient(NetworkConnection prevOwner)
    {
        base.OnOwnershipClient(prevOwner);
        SetName();
    }

    private void SetName()
    {
        string result = null;
        if ((base.Owner.IsValid))
        {
            result = PlayerNameTracker.GetPlayerName(base.Owner);
        }

        if (string.IsNullOrWhiteSpace(result))
        {
            result = "Unset";
        }

        _text.text = result;
    }
}
