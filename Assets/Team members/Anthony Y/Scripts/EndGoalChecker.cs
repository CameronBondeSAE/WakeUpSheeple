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
    public List<Movement_ForwardAM> sheep;
    public int maxSheepCount;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>())
        {
            //***********BOX CODE************
            Debug.Log(other.gameObject.name);
            boxes.Add(other);
           //****SHEEP CODE**************
            sheep.Add(other.transform.root.GetComponent<Movement_ForwardAM>());
            Destroy(other.transform.root.GetComponent<Movement_ForwardAM>());
            Debug.Log(sheep.Count.ToString());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>())
        {
            //****SHEEP CODE**************
            Debug.Log(other.transform.root.gameObject.name + ": has left the zone");
            sheep.Remove(other.transform.root.GetComponent<Movement_ForwardAM>());
            Debug.Log(sheep.Count.ToString());
            
            boxes.Remove(other);
            
        }
    }

    private void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }
}
