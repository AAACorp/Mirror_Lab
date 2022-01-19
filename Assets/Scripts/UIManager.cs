using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singletone
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        _instance = this;
    }

    #region UI Groups
    [SerializeField]
    private GameObject _spawnGroupContainer;
    [SerializeField]
    private GameObject _playerStatsGroupContainer;
    #endregion

    [SerializeField]
    private Text _nameField;

    public void SetUIPlayerName(string plName)
    {
        _nameField.text = plName;
    }

    public void SpawnGroupToggle()
    {
        _spawnGroupContainer.SetActive(!_spawnGroupContainer.activeSelf);
    }

    public void PlayerStatsGroupToggle()
    {
        _playerStatsGroupContainer.SetActive(!_playerStatsGroupContainer.activeSelf);
    }

}
