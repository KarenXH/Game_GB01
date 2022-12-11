using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : Singleton<LevelsManager>
{
    public BricksManager[] levelPrefabs;

    int _curLevel;

    public int CurLevel { get => _curLevel; set => _curLevel = value; }
}
