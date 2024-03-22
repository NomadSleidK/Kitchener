using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelIconScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private DataLevels _dataLevels;
    [SerializeField] private int _sceneNomber;
    private string _sceneName;


    private void Start()
    {
        _sceneName = _dataLevels.GetLevel[_sceneNomber].SceneName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
