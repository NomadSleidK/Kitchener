using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    [SerializeField] private DataLevels _dataLevels;
    private GameObject _levelsMenu;
    private int _lastSceneNumber;

    private void Start()
    {
        _dataLevels.DataUpdate();

        if (!PlayerPrefs.HasKey("activeScene"))
            PlayerPrefs.SetInt("activeScene", 0);

        _lastSceneNumber = PlayerPrefs.GetInt("activeScene");
        _levelsMenu = GameObject.FindGameObjectWithTag("LevelsScreen");
        _levelsMenu.SetActive(false);
    }

    public void PlayButtonClick()
    {
        SceneManager.LoadScene(_dataLevels.GetLevel[_lastSceneNumber].SceneName);
    }

    public void LevelsMenuButtonClick()
    {
        _levelsMenu.SetActive(true);
    }
   
    public void ExitLevelsMenuButtonClick()
    {
        _levelsMenu.SetActive(false);
    }
}
