using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/DataLevelIcons", order = 52)]
public class DataLevelIcons: ScriptableObject
{
    [SerializeField] private Sprite _lockLevel;
    public Sprite LockLevel => _lockLevel;

    [SerializeField] private Sprite _resultZero;
    public Sprite ResultZero => _resultZero;

    [SerializeField] private Sprite _resultOne;
    public Sprite ResultOne => _resultOne;

    [SerializeField] private Sprite _resultTwo;
    public Sprite ResultTwo => _resultTwo;

    [SerializeField] private Sprite _resultThree;
    public Sprite ResultThree => _resultThree;

    public void SetLevelSprite(Image imageLevelIcon, int levelResult)
    {
        switch (levelResult)
        {
            case -1:
                imageLevelIcon.sprite = LockLevel;
                break;
            case 0:
                imageLevelIcon.sprite = ResultZero;
                break;
            case 1:
                imageLevelIcon.sprite = ResultOne;
                break;
            case 2:
                imageLevelIcon.sprite = ResultTwo;
                break;
            case 3:
                imageLevelIcon.sprite = ResultThree;
                break;
        }
    }

    [SerializeField] private Sprite _levelResultImage1;
    public Sprite LevelResultImage1 => _levelResultImage1;

    [SerializeField] private Sprite _levelResultImage2;
    public Sprite LevelResultImage2 => _levelResultImage2;

    [SerializeField] private Sprite _levelResultImage3;
    public Sprite LevelResultImage3 => _levelResultImage3;

    public void SetLevelResultImage(Image imageLevelIcon, int levelResult)
    {
        switch (levelResult)
        {
            case 1:
                imageLevelIcon.sprite = LevelResultImage1;
                break;
            case 2:
                imageLevelIcon.sprite = LevelResultImage2;
                break;
            case 3:
                imageLevelIcon.sprite = LevelResultImage3;
                break;
        }
    }
}
