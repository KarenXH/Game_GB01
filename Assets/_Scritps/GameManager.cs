using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int timeDelay;
    public Ball ball;

    int _curTimeDelay;
    int _level;
    int _score;
    BricksManager _levelObj;

    public int Level { get => _level;}
    public BricksManager LevelObj { get => _levelObj; }

    public override void Awake()
    {
        MakeSingleton(false);
    }
    public override void Start()
    {
        _curTimeDelay = timeDelay;

        StartCoroutine(CountingDown());

        Prefs.newBestScore = false;

        GameGUIManager.Ins.UpdateScore(_score);
    }

    IEnumerator CountingDown()
    {
        BricksManager[] levelPrefabs = LevelsManager.Ins.levelPrefabs;
        if (levelPrefabs != null && levelPrefabs.Length > 0 && levelPrefabs.Length>LevelsManager.Ins.CurLevel)
        {
            BricksManager levelPrefab = levelPrefabs[LevelsManager.Ins.CurLevel];

            if (levelPrefab != null)
            {
                _level = LevelsManager.Ins.CurLevel;
                _levelObj = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
            }
        }

        while(_curTimeDelay > 0)
        {
            yield return new WaitForSeconds(1f);
            _curTimeDelay--;

            GameGUIManager.Ins.UpdateTimeCountingdown(_curTimeDelay);
        }

        if (ball) 
        { 
            ball.Trigger(); 
        }

        Prefs.SetGameEntered(true);
    }

    public void AddScore(int scoreToAdd)
    {
        _score += scoreToAdd;

        Prefs.bestScore = _score;

        GameGUIManager.Ins.UpdateScore(_score);
    }
}
