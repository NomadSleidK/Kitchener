using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] private DataLevels _dataLevels;
    [SerializeField] private int _sceneNomber;
    private string _sceneName;
    private int _objectInZoneCount;

    private void Start()
    {
        _objectInZoneCount = 0;
        _sceneName = _dataLevels.GetLevel[_sceneNomber].SceneName;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Object")
        {
            Debug.Log("Попадание");
        }
    }

    private void LoadNextScene()
    {

    }
}
