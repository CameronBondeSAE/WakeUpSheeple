using System;
using System.Collections;
using System.Collections.Generic;
using AlexM;
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
    public List<Sheep> safeSheep;
    public int sheepRequired;

    public event Action<Sheep> SheepMadeitEvent;
    
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>())
        {
            //***********BOX CODE************
            Debug.Log(other.gameObject.name);
            boxes.Add(other);
           //****SHEEP CODE**************
            safeSheep.Add(other.GetComponent<Sheep>());
            // Destroy(other.transform.root.gameObject);
            Debug.Log(safeSheep.Count.ToString());
            SheepMadeitEvent?.Invoke(other.GetComponent<Sheep>());
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>())
        {
            //****SHEEP CODE**************
            Debug.Log(other.transform.root.gameObject.name + ": has left the zone");
            safeSheep.Remove(other.GetComponent<Sheep>());
            Debug.Log(safeSheep.Count.ToString());
            
            boxes.Remove(other);
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }
}
