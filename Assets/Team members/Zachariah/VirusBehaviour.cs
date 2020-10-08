using System;
using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.Chat;
using TMPro;
using UnityEngine;


//locate nearest sheep
//move towards nearest sheep
//attach to sheep and create new virus object
public class VirusBehaviour : MonoBehaviour
{
    //private Vector3 currentVelocity;
    //public float velocity;
    //public GameObject Sheep;

    private void Awake()
    {
        //Sheep = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //transform.position = new Vector3(0.0f,0.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 sheepLocation = new Vector3(Sheep.transform.position.x,Sheep.transform.position.y,Sheep.transform.position.z);
        //Vector3.MoveTowards(currentVelocity, sheepLocation , velocity);
    }

    
    //Need help with this
    //attachment to sheep 
    private void OnTriggerEnter(Collider other)
    {
        //transform.parent;
        if (other.gameObject.CompareTag("Player"))
        {
            transform.parent = other.transform;
            transform.localPosition = new Vector3(0,0,0);
            Debug.Log("Virus Attached");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        throw new NotImplementedException();
    }
}
