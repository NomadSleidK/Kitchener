using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelIcon : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] private DataLevels _dataLevels;
    [SerializeField] private DataLevelIcons _dataLevelIcons;
    [SerializeField] private int _sceneNumber;
    private string _sceneName;


    private void Start()
    {
        _sceneName = _dataLevels.GetLevel[_sceneNumber].SceneName;
        _dataLevelIcons.SetLevelSprite(this.gameObject.GetComponent<Image>(), _dataLevels.GetLevel[_sceneNumber].Result);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_dataLevels.GetLevel[_sceneNumber].IsLevelOpened)
        {
            _dataLevels.ActiveSceneNumber = _sceneNumber;
            SceneManager.LoadScene(_sceneName);
        }
        else
        {
            Debug.Log("Уровень заблокирован");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        /*
        if (_dataLevels.GetLevel[_sceneNumber].IsLevelOpened)
        {
            Debug.Log("������� ������ " + _dataLevels.GetLevel[_sceneNumber].Result);
        }
        else
        {
            Debug.Log("�������������");
        }
        */
    }
}
