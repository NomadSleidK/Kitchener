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
        if (_dataLevels.GetLevel[_sceneNumber].IsLevelOpened)
        {
            _dataLevels.ActiveScene = _sceneNumber;
            SceneManager.LoadScene(_sceneName);
        }
        else
        {
            Debug.Log("Заблокировано");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        /*
        if (_dataLevels.GetLevel[_sceneNumber].IsLevelOpened)
        {
            Debug.Log("Рейтинг уровня " + _dataLevels.GetLevel[_sceneNumber].Result);
        }
        else
        {
            Debug.Log("Заблокировано");
        }
        */
    }
}
