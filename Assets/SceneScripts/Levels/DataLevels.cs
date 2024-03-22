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
        [SerializeField] private int _result;
        public int Result
        {
            get
            {
                return _result;
            }
            set
            {
                if (value > 3)
                    _result = 3;
                else if (value < 1)
                    _result = 1;
                else
                    _result = value;
            }
        }
    }
    [SerializeField] private Level[] _levels;
    public Level[] GetLevel => _levels;

    public void SaveLevelResult(int sceneNomber, int result)
    {
        PlayerPrefs.SetInt(GetLevel[sceneNomber].SceneName, result);
        PlayerPrefs.Save();
    }
}
