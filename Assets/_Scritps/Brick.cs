using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health;
    public int minScore;
    public int maxScore;
    public GameObject ballHittedVfx;

    public int ScoreBonus {
        get => Random.Range(minScore, maxScore) * (GameManager.Ins.Level +1);
    }

    public void Hit()
    {
        health--;

        if(health <= 0)
        {
            if (ballHittedVfx)
            {
                Instantiate(ballHittedVfx, transform.position, Quaternion.identity);

                GameManager.Ins.AddScore(ScoreBonus);

                if (GameManager.Ins.LevelObj != null && GameManager.Ins.LevelObj.bricks != null)
                {
                    GameManager.Ins.LevelObj.bricks.Remove(this);

                    if (GameManager.Ins.LevelObj.bricks != null && GameManager.Ins.LevelObj.bricks.Count <= 0)
                    {
                        Prefs.SetLevelPassed(LevelsManager.Ins.CurLevel, true);
                        Prefs.SetLevelUnlocked(LevelsManager.Ins.CurLevel + 1, true);
                        GameGUIManager.Ins.winDialog.Show(true);
                    }
                }
                Destroy(gameObject);
            }
        }
        AudioController.Ins.PlaySound(AudioController.Ins.bounci);
    }
}
