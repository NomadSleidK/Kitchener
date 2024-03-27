using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private DataLevels _dataLevels;

    private GameObject _screenResult;
    private int _objectInZoneCount;
    private int _levelResult;
    public int LevelResult
    {
        get
        {
            return _levelResult;
        }
        set
        {
            _levelResult++;
        }
    }

    private void Start()
    {
        _screenResult = GameObject.FindGameObjectWithTag("ScreenResult");
        if (_screenResult.activeInHierarchy)
            _screenResult.SetActive(false);
        _objectInZoneCount = 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Object" && _objectInZoneCount < 3)
        {
            _objectInZoneCount++;
            other.gameObject.SetActive(false);
        }

        if (_objectInZoneCount == 3)
        {
            _levelResult++;
            _dataLevels.SaveLevelResult(_levelResult);   
            _screenResult.SetActive(true);
        }
    }
}
