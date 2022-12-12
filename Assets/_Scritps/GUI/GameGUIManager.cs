using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public Text scoreText;
    public Text timeCountingdownText;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void UpdateScore(int score)
    {
        if (scoreText)
            scoreText.text = "Score: " + score.ToString("n0");
    }

    public void UpdateTimeCountingdown(int time)
    {
        if (timeCountingdownText)
        {
            timeCountingdownText.text = time.ToString("0");
        }
        if(time <= 0)
        {
            if (timeCountingdownText)
            {
                timeCountingdownText.gameObject.SetActive(false);
            }
        }
    }

    public void BackToHomeBtn()
    {
        SceneManager.LoadScene(SceneConsts.MAIN);
    }
}
