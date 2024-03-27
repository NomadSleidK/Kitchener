using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour
{
    [SerializeField] private DataLevels _dataLevels;
    private GameObject _settingsScreen;
    private int _sceneNumber;

    private void Start()
    {
        _settingsScreen = GameObject.FindGameObjectWithTag("SettingsScreen");
        if (_settingsScreen.activeInHierarchy)
            _settingsScreen.SetActive(false);

        _sceneNumber = _dataLevels.ActiveSceneNomber;
    }
    public void MenuButtonClick()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void SettingsButtonClick()
    {
        if (_settingsScreen.activeInHierarchy)
            _settingsScreen.SetActive(false);

        else if(!_settingsScreen.activeInHierarchy)
            _settingsScreen.SetActive(true);

    }

    public void ResetLevelButtonClick()
    {
        SceneManager.LoadScene(_dataLevels.GetLevel[_sceneNumber].SceneName);
    }

    public void NextLevelButtonClick()
    {
        if (_sceneNumber + 1 > _dataLevels.GetLevel.Length - 1)
        {
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            _dataLevels.ActiveSceneNomber++;
            SceneManager.LoadScene(_dataLevels.GetLevel[_sceneNumber + 1].SceneName);
        }
        
    }
}
