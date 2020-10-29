using System;
using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.Chat;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class EndGoalChecker : MonoBehaviour
{
    [Header("List of Colliders")]
    public List<Collider> boxes;
    public BoxCollider boxCollider;
    [Header("List of Sheep")]
    public List<Movement_ForwardAM> safeSheep;
    public int maxSheepCount;

    public event Action SheepMadeitEvent;
    
    //may not need this event
    public event Action ASheepMadeitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>())
        {
            //***********BOX CODE************
            Debug.Log(other.gameObject.name);
            boxes.Add(other);
           //****SHEEP CODE**************
            safeSheep.Add(other.transform.root.GetComponent<Movement_ForwardAM>());
            Destroy(other.transform.root.GetComponent<Movement_ForwardAM>());
            Debug.Log(safeSheep.Count.ToString());
            ASheepMadeitEvent?.Invoke();
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>())
        {
            //****SHEEP CODE**************
            Debug.Log(other.transform.root.gameObject.name + ": has left the zone");
            safeSheep.Remove(other.transform.root.GetComponent<Movement_ForwardAM>());
            Debug.Log(safeSheep.Count.ToString());
            
            boxes.Remove(other);
            
        }
    }

    private void Update()
    {
        
    }

    public void EndGoalReached()
    {
        if (safeSheep.Count >= maxSheepCount)
        {
            SheepMadeitEvent?.Invoke();
        }
    }

    public void EndGoalNotReached()
    {
        if (safeSheep.Count < maxSheepCount)
        {
            //I dont know how this may work because this will keep spamming the event if there isn't enough sheep
            //in the list
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }
}
