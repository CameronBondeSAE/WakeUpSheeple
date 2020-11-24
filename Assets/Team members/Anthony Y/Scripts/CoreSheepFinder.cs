using System.Collections;
using System.Collections.Generic;
using AlexM;
using Mirror;
using UnityEngine;
using FlockBehavior = AJ.FlockBehavior;

public class CoreSheepFinder : NetworkBehaviour
{
    public NeigboursDetector neighboursDetect;
// [SyncVar]
//     public Sheep centerofFlockSheep;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MassFlockAmount());
    }

    IEnumerator MassFlockAmount()
    {
        foreach (Sheep sheep in neighboursDetect.GetNearbyObjects())
        {
           sheep.GetComponent<NeigboursDetector>().GetNearbyObjects();
        }
        yield return new WaitForSeconds(2f);
    }
}


//foreach through all sheep (use a coroutine to only do it every few seconds for efficiency)
// every sheep has a 'Neighbours' script
// Keep track of the highest neighbours count
// have a single 'centerOfFlockSheep'
// NetworkIdentity variable (because netid is automatically synced to clients)

