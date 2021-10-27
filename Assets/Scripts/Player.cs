using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private float _speed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();

        if(isClient && isLocalPlayer)
        {
            SetInputManagerPlayer();
        }   
        
        if(isServer)
        {
            _speed = 3f;
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
    
    public void MovePlayer(Vector3 _movementVector)
    {
        _rb.AddForce(_movementVector.normalized * _speed);
    }

}
