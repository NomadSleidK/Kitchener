using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScriptableObject/DataLevels", order = 51)]
public class DataLevels : ScriptableObject
{
    public int ActiveScene
    {
        get
        {
            return PlayerPrefs.GetInt("activeScene");
        }
        set
        {
            if (!(value < 0))
                PlayerPrefs.SetInt("activeScene", value);
        }
    }

    [System.Serializable]
    public class Level
    {
        [SerializeField] private string _sceneName;
        public string SceneName => _sceneName;

        private bool _isLevelOpened;

        private int _result;
        public int Result
        {
            get
            {
                return _result;
            }
            set
            {
                if(value > _result && value <= 3)
                    _result = value;
                SaveResult(SceneName, _result);
            }
        }

        public void SaveResult(string name, int result)
        {
            PlayerPrefs.SetInt(name, result);
        }
    }
    [SerializeField] private Level[] _levels;
    public Level[] GetLevel => _levels;

    public void DataUpdate()
    {
        foreach (Level level in GetLevel)
        {
            if (!PlayerPrefs.HasKey(level.SceneName))
                PlayerPrefs.SetInt(level.SceneName, 0);

            level.Result = PlayerPrefs.GetInt(level.SceneName);
        }

        foreach (Level level in GetLevel)
        {
            if (!PlayerPrefs.HasKey(level.SceneName))
                PlayerPrefs.SetInt(level.SceneName, 0);

            level.Result = PlayerPrefs.GetInt(level.SceneName);
        }
    }

    public void SaveLevelResult(int value)
    {
        GetLevel[PlayerPrefs.GetInt("activeScene")].Result = value;
    }
}
