using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public override void OnClientConnect(NetworkConnection conn)
    {
        UIManager.Instance.SpawnGroupToggle();
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        UIManager.Instance.PlayerStatsGroupToggle();
        base.OnClientDisconnect(conn);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        UIManager.Instance.PlayerStatsGroupToggle();
        base.OnServerDisconnect(conn);
    }

}
