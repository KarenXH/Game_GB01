using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public static bool newBestScore;

    public static void SetBool(bool isTrue, string key)
    {
        if (isTrue)
        {
            PlayerPrefs.SetInt(key, 1);
        }
        else
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }

    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }

    public static int bestScore
    {
        set
        {
            if(PlayerPrefs.GetInt(PrefsConsts.BEST_SCORE,0) < value)
            {
                newBestScore = true;
                PlayerPrefs.SetInt(PrefsConsts.BEST_SCORE, value);
            }
            else
            {
                newBestScore = false;
            }
        }

        get => PlayerPrefs.GetInt(PrefsConsts.BEST_SCORE, 0);
    }

    public static bool IsLevelUnlocked(int level)
    {
        return GetBool(PrefsConsts.LEVEL_UNLOCKED + level);
    }

    public static bool IsLevelPassed(int level)
    {
        return GetBool(PrefsConsts.LEVEL_PASSED + level);
    }

    public static void SetLevelUnlocked(int level, bool unlocked)
    {
        SetBool(unlocked, PrefsConsts.LEVEL_UNLOCKED + level);
    }
    public static void SetLevelPassed(int level, bool unlocked)
    {
        SetBool(unlocked, PrefsConsts.LEVEL_PASSED + level);
    }

    public static bool IsGameEntered()
    {
        return GetBool(PrefsConsts.IS_GAME_ENTERED);
    }
    public static void SetGameEntered(bool isEntered)
    {
        SetBool(isEntered, PrefsConsts.IS_GAME_ENTERED);
    }
}
