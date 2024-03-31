using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorZone : MonoBehaviour
{
    [SerializeField] private DataLevels _dataLevels;
    private int _sceneNumber;

    private void Start()
    {
        _sceneNumber = _dataLevels.ActiveSceneNumber;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Object")
        {
            SceneManager.LoadScene(_dataLevels.GetLevel[_sceneNumber].SceneName);
        }
    }
}
