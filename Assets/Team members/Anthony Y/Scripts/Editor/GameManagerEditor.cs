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
      if (GUILayout.Button("Simulate Map Overview"))
      {
         gameManager.OverviewOfMap();
      }
      if (GUILayout.Button("Simulate Game Started"))
      {
         gameManager.Playing();
      }
      if (GUILayout.Button("Simulate Players Spawned"))
      {
         gameManager.PlayersSpawned();
      }

      if (GUILayout.Button("Simulate Game Won"))
      {
         gameManager.EndGoalTrackerWin();
      }
      if (GUILayout.Button("Simulate Game Lost"))
      {
         gameManager.EndGoalTrackerLost();
      }
      if (GUILayout.Button("Simulate Game Over"))
      {
         gameManager.GameOver();
      }
      
      
   }
}
