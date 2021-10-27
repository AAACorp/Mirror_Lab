using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    private GameObject _spawnGroupContainer;

    public void SpawnGroupToggle()
    {
        _spawnGroupContainer.SetActive(!_spawnGroupContainer.activeSelf);
    }
}
