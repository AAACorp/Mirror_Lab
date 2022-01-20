using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    #region Singletone
    private static InputManager _instance;
    
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    private Vector3 _movementVector = new Vector3();

    [SerializeField]
    private InputField _inputField;

    [SerializeField]
    private Dropdown _dropdown;

    [SerializeField]
    private Player _playerObj;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if(_playerObj) 
            MoveInput();
    }

    public void SetPlayer(Player _pl)
    {
        _playerObj = _pl;
    }

    public void SpawnPlayer()
    {
        PlayerManager.Instance.SpawnPlayer();
    }

    public void SendName(string name)
    {
        PlayerManager.Instance.SetPlayerName(_inputField.text);
    }

    public void SendColor(int id)
    {
        PlayerManager.Instance.SetPlayerColor(_dropdown.value);
    }

    #region Movement Function
    private void MoveInput()
    {
        _movementVector.x = Input.GetAxis("Horizontal");
        _movementVector.z = Input.GetAxis("Vertical");

        _playerObj.CmdMovePlayer(_movementVector);
        _playerObj.MovePlayer(_movementVector);
    }
    #endregion
}
