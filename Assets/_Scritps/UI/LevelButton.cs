using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelGoto;
    public bool isUnlocked;
    public GameObject levelState;
    public Image icon;
    public Text levelText;
    public Sprite checkMark;
    public Sprite lookIcon;

    Button _btnComp;

    private void Start()
    {
        if (levelText)
        {
            levelText.text = (levelGoto+1).ToString("00");
        }

        _btnComp = GetComponent<Button>();
        if (_btnComp)
        {
            _btnComp.onClick.AddListener(() => GoToLevel());
        }
        
        //conly run when player play first time
        if (!Prefs.IsGameEntered())
        {
            Prefs.SetLevelUnlocked(levelGoto, isUnlocked);
        }

        if (Prefs.IsLevelUnlocked(levelGoto))
        {
            if (levelState)            
                levelState.SetActive(false);
            
            if (Prefs.IsLevelPassed(levelGoto))
            {
                if (levelState)                
                    levelState.SetActive(true);

                if (icon && checkMark)
                    icon.sprite = checkMark;
            }
        }
        else
        {
            if (levelState)
                levelState.SetActive(true);

            if (icon && lookIcon)
                icon.sprite = lookIcon;
        }
    }

    public void GoToLevel()
    {
        if (Prefs.IsLevelUnlocked(levelGoto))
        {
            LevelsManager.Ins.CurLevel = levelGoto;
            SceneManager.LoadScene(SceneConsts.GAME_PLAY);
        }
    }
}
