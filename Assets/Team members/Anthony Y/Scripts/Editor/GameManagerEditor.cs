﻿using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
   public override void OnInspectorGUI()
   {
      base.OnInspectorGUI();
      GameManager gameManager = (GameManager) target;
      if (GUILayout.Button("Map Overview"))
      {
         gameManager.OverviewOfMap();
      }
      if (GUILayout.Button("Game Started"))
      {
         gameManager.PlayPhaseStarted();
      }
      if (GUILayout.Button("Players Spawned"))
      {
         gameManager.PlayersSpawned(null);
      }

      if (GUILayout.Button("Game Won"))
      {
         gameManager.EndGoalTrackerWin();
      }
      if (GUILayout.Button("Game Lost"))
      {
         gameManager.EndGoalTrackerLost(null);
      }
      if (GUILayout.Button("Game Over"))
      {
         gameManager.RpcGameOver();
      }
      
      
   }
}
