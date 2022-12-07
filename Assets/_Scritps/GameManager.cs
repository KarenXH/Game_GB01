using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float timeDelay;
    public Ball ball;

    float _curTimeDelay;
    int _level;

    public int Level { get => _level; set => _level = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }
    public override void Start()
    {
        _curTimeDelay = timeDelay;

        StartCoroutine(CountingDown());
    }

    IEnumerator CountingDown()
    {
        while(_curTimeDelay > 0)
        {
            yield return new WaitForSeconds(1f);
            _curTimeDelay--;
        }

        if (ball) 
        { 
            ball.Trigger(); 
        }
    }
}
