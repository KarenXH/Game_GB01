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
        get => Random.Range(minScore, maxScore) * GameManager.Ins.Level;
    }

    public void Hit()
    {
        health--;

        if(health <= 0)
        {
            if (ballHittedVfx)
            {
                Instantiate(ballHittedVfx, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
