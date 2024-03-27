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
        switch(levelResult)
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
}
