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
    public float velocity;
    //public GameObject Sheep;
    public bool isAttached = false;
    public GameObject Virus;
    public Transform virusLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Movement and location of sheep
    void Update()
    {
        //transform.LookAt(Sheep.transform);
        //transform.position += transform.forward * velocity * Time.deltaTime;
    }

    
   
    //attachment to sheep 
    private void OnTriggerEnter(Collider other)
    {
        //transform.parent;
        if (other.gameObject.CompareTag("Player"))
        {
            if (isAttached == false)
            {
                var transform1 = transform;
                transform1.parent = other.transform;
                transform1.localPosition = new Vector3(0,1,0);
                
                isAttached = true;
                Debug.Log("Virus Attached");
            }else if (isAttached)
            {
                //finish creating the instatiate (creates another prefab of virus to simulate infection)
                Instantiate(Virus,virusLocation.localPosition, virusLocation.localRotation);
            }
              
            //record that I have been attached
        }
    }

    private void OnTriggerExit(Collider other)
    {
        throw new NotImplementedException();
    }
}
