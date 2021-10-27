using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private NetworkManager _netManager;
    public void SpawnPlayer()
    {
        if (!_netManager.clientLoadedScene)
        {
            // Ready/AddPlayer is usually triggered by a scene load
            // completing. if no scene was loaded, then Ready/AddPlayer it
            // here instead.
            if (!NetworkClient.ready) NetworkClient.Ready(); //остановились тут
            
                NetworkClient.AddPlayer();
            
        }
    }
}
