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
    // [Header("List of Colliders")]
    // public List<Collider> boxes;
    public BoxCollider boxCollider;
    [Header("List of Sheep")]
    public List<Sheep> safeSheep;
    public int sheepRequired;

    public event Action<Sheep> SheepMadeitEvent;
    
  

    private void OnTriggerEnter(Collider other)
    {
		// CAM FIX, was looking for collider, needs to look for Sheep
        if (other.gameObject.GetComponent<Sheep>())
        {
            // //***********BOX CODE************
            // boxes.Add(other);
           //****SHEEP CODE**************
            safeSheep.Add(other.GetComponent<Sheep>());
			Debug.Log(other.gameObject.name + ": Count = "+safeSheep.Count.ToString());
            // Destroy(other.transform.root.gameObject);
            SheepMadeitEvent?.Invoke(other.GetComponent<Sheep>());

			// CAM HACK
			Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>())
        {
            //****SHEEP CODE**************
            Debug.Log(other.transform.root.gameObject.name + ": has left the zone : Count = "+safeSheep.Count.ToString());
            safeSheep.Remove(other.GetComponent<Sheep>());
            
            // boxes.Remove(other);
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }
}
