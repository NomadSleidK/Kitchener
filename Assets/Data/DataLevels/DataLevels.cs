using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DataLevels;

[CreateAssetMenu(menuName = "ScriptableObject/DataLevels", order = 51)]
public class DataLevels : ScriptableObject
{
    public int ActiveSceneNomber
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

        public bool IsLevelOpened;

        private int _result;
        public int Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                if (_result != -1)
                    IsLevelOpened = true;
                else
                    IsLevelOpened = false;
                PlayerPrefs.SetInt(_sceneName, _result);
            }
        }
    }
    [SerializeField] private Level[] _levels;
    public Level[] GetLevel => _levels;

    public void DataUpdate()
    {
        //PlayerPrefs.DeleteAll();

        foreach (Level level in GetLevel)
        {
            if (!PlayerPrefs.HasKey(level.SceneName))
                PlayerPrefs.SetInt(level.SceneName, -1);

            level.Result = PlayerPrefs.GetInt(level.SceneName);
        }
    
        if (GetLevel[0].Result == -1)
            GetLevel[0].Result = 0;
    }

    public void SaveLevelResult(int newRezult)
    {
        int oldThisLevelResult = GetLevel[PlayerPrefs.GetInt("activeScene")].Result;

        if (newRezult > oldThisLevelResult && newRezult <= 3)
            GetLevel[PlayerPrefs.GetInt("activeScene")].Result = newRezult;

        if (PlayerPrefs.GetInt("activeScene") + 1 <= GetLevel.Length - 1)
        {
            int nextLevelResult = GetLevel[PlayerPrefs.GetInt("activeScene") + 1].Result;

            if (nextLevelResult == -1)
                GetLevel[PlayerPrefs.GetInt("activeScene") + 1].Result = 0;
        }
    }
}
