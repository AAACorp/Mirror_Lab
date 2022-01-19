using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class Player : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private float _speed;

    [SyncVar]
    [SerializeField]
    private string _playerName;

    [SerializeField]
    private Text _nameText;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();

        if (isServer)
        {
            _speed = 3f;
            CmdSetPlayerName(PlayerManager.Instance.GetPlayerName);
        }

        _rb = this.GetComponent<Rigidbody>();

        if(isClient && isLocalPlayer)
        {
            SetInputManagerPlayer();
        }
       
    }

    private void SetInputManagerPlayer()
    {
        InputManager.Instance.SetPlayer(this);
    }

    [Command]
    public void CmdMovePlayer(Vector3 _movementVector)
    {
        _rb.AddForce(_movementVector.normalized * _speed);
    }
    
    [Command]
    public void CmdSetPlayerName(string plName)
    {
        _playerName = plName;
        RpcSetVisibleName(_playerName);
    }

    [ClientRpc]
    public void RpcSetVisibleName(string plName)
    {
        _nameText.text = plName;
    }

    public void MovePlayer(Vector3 _movementVector)
    {
        _rb.AddForce(_movementVector.normalized * _speed);
    }

}
