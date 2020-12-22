using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class LevelLoader : NetworkBehaviour
{
    public static event Action<string,bool> LoadLevelEvent;

    [Scene]
    public string levelToLoad;

    public bool LoadNextLevel = true;

   
    [Server]
    public void LoadLevel()
    {
        LoadLevelEvent?.Invoke(levelToLoad,LoadNextLevel);
        Debug.Log("Next level Loaded");
    }
}
