using System.Collections;
using System.Collections.Generic;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.XR;

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
         gameManager.PlayersSpawned();
      }

      if (GUILayout.Button("Game Won"))
      {
         gameManager.EndGoalTrackerWin();
      }
      if (GUILayout.Button("Game Lost"))
      {
         gameManager.EndGoalTrackerLost();
      }
      if (GUILayout.Button("Game Over"))
      {
         gameManager.GameOver();
      }
      
      
   }
}
