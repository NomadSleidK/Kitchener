using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelIcon : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] private DataLevels _dataLevels;
    [SerializeField] private int _sceneNumber;
    private string _sceneName;


    private void Start()
    {
        _sceneName = _dataLevels.GetLevel[_sceneNumber].SceneName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerPrefs.SetInt("activeScene", _sceneNumber);
        SceneManager.LoadScene(_sceneName);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(_dataLevels.GetLevel[_sceneNumber].Result);
    }
}
