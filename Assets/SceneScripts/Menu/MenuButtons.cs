using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _levelsMenu;

    public void PlayButtonClick()
    {
        SceneManager.LoadScene("Level1Scene");
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
