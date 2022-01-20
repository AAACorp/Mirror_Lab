using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : MonoBehaviour
{
    #region Singletone
    private static PlayerManager _instance;

    public static PlayerManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    [SerializeField]
    private string _playerName;

    [SerializeField]
    private Color _playerColor;

    public string GetPlayerName
    {
        get
        {
            return _playerName;
        }
    }

    public Color GetPlayerColor
    {
        get
        {
            return _playerColor;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] private NetworkManager _netManager;

    public void SetPlayerName(string plName)
    {
        _playerName = plName;
    }

    public void SetPlayerColor(int colorId)
    {
        switch (colorId)
        {
            case 0:
                _playerColor = Color.green;
                break;
            case 1:
                _playerColor = Color.red;
                break;
            case 2:
                _playerColor = Color.yellow;
                break;
        }
        Debug.Log("Player color is " + _playerColor);
    }

    public void SpawnPlayer()
    {
        if(string.IsNullOrWhiteSpace(_playerName))
        {
            Debug.Log("Name has not been set");
            return;
        }

        if (!_netManager.clientLoadedScene)
        {
            if (!NetworkClient.ready) 
                NetworkClient.Ready();

            NetworkClient.AddPlayer();
            UIManager.Instance.SpawnGroupToggle();
            UIManager.Instance.PlayerStatsGroupToggle();
            UIManager.Instance.SetUIPlayerName(_playerName);
            if(GetPlayerColor == Color.clear)
            {
                _playerColor = Color.green;
            }
        }
    }
}
