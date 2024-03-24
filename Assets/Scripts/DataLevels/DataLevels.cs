using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "ScriptableObject/DataLevels", order = 51)]
public class DataLevels : ScriptableObject
{
    [System.Serializable]
    public class Level
    {
        [SerializeField] private string _sceneName;
        public string SceneName => _sceneName;

        public bool IsLevelOpen;
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
                Debug.Log(value);

                PlayerPrefs.SetInt(_sceneName, _result);
            }
        }
    }
    [SerializeField] private Level[] _levels;
    public Level[] GetLevel => _levels;

    public void DataUpdate()
    {
        foreach (Level level in GetLevel)
        {
            if (!PlayerPrefs.HasKey(level.SceneName))
                PlayerPrefs.SetInt(level.SceneName, -1);

            level.Result = PlayerPrefs.GetInt(level.SceneName);
        }
    }

    public void SaveLevelResult(int result)
    {
        PlayerPrefs.SetInt(GetLevel[PlayerPrefs.GetInt("activeScene")].SceneName, result);
    }
}
