using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverDialog : Dialog
{
    public Text bestScoreText;

    public override void Show(bool isShow)
    {
        Time.timeScale = 0;
        base.Show(isShow);

        if (Prefs.newBestScore)
        {
            if (bestScoreText)
                bestScoreText.text = "NEW BEST: " + Prefs.bestScore.ToString("n0");
        }
        else
        {
            if (bestScoreText)
            {
                bestScoreText.text = "BEST SCORE: " + Prefs.bestScore.ToString("n0");
            }
        }

        AudioController.Ins.PlaySound(AudioController.Ins.lose);
    }

    public void HomeBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneConsts.MAIN);
    }

    public void QuitGameBtn()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void ReplayBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneConsts.GAME_PLAY);
    }
}
