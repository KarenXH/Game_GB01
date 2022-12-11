using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGUIManager : MonoBehaviour
{
    public LevelSelectionDialog levelSelectionDialog;
    public void PlayGame()
    {
        if (levelSelectionDialog)
        {
            levelSelectionDialog.Show(true);
        }
    }
}
