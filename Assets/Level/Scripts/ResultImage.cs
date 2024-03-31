using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultImageManager : MonoBehaviour
{
    [SerializeField] private DataLevels _dataLevels;
    [SerializeField] private DataLevelIcons _dataLevelIcons;
    private int _sceneNumber;

    void Start()
    {       
        _sceneNumber = _dataLevels.ActiveSceneNumber;
        _dataLevelIcons.SetLevelResultImage(this.gameObject.GetComponent<Image>(), _dataLevels.GetLevel[_sceneNumber].Result);
    }
}
