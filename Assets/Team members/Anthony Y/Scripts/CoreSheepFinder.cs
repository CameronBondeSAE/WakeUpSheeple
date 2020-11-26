using System.Collections;
using System.Collections.Generic;
using AlexM;
using Mirror;
using ParadoxNotion;
using UnityEngine;
using FlockBehavior = AJ.FlockBehavior;

public class CoreSheepFinder : MonoBehaviour
{
    public NeigboursDetector neighboursDetect;

    public Vector3 centerofFlockSheep;
    public Spawner spawner;
    
// [SyncVar]
//     public Sheep centerofFlockSheep;
   
    // Start is called before the first frame update
    void Start()
    {
        List<Sheep> nearbyObjects = neighboursDetect.GetNearbyObjects();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MassFlockAmount());
    }

    IEnumerator MassFlockAmount()
    {
        Vector3 center = Vector3.zero;
     

        foreach (Sheep sheep in neighboursDetect.GetNearbyObjects())
        {
            center = center + sheep.transform.localPosition;

        }
        
       
        Debug.Log(centerofFlockSheep);
        centerofFlockSheep = center / (neighboursDetect.GetNearbyObjects().Count);
        

        
        yield return new WaitForSeconds(2f);
    }
}
    

//foreach through all sheep (use a coroutine to only do it every few seconds for efficiency)
// every sheep has a 'Neighbours' script
// Keep track of the highest neighbours count
// have a single 'centerOfFlockSheep'
// NetworkIdentity variable (because netid is automatically synced to clients)

