using System.Collections;
using System.Collections.Generic;
using AlexM;
using Mirror;
using UnityEngine;
using FlockBehavior = AJ.FlockBehavior;

public class CoreSheepFinder : NetworkBehaviour
{
    public NeigboursDetector neighboursDetect;

    public Vector3 centerofSheepFlock;
    public GameManager gameManager;
    public Sheep centerSheep;
    
    public int highestSheepCount;

// [SyncVar]
//     public Sheep centerofFlockSheep;
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("i Waited for 3 seconds");
        StartCoroutine(MassFlockAmount(3f));
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator MassFlockAmount(float waitTime)
    {
        while (true)
        {
            highestSheepCount = 0;
            foreach (Sheep sheep in gameManager.allSheep)
            {
                // centre = centre - sheep.transform.localPosition;
                if (sheep.GetComponent<NeigboursDetector>().GetNearbyObjects().Count > highestSheepCount)
                {
                    highestSheepCount = sheep.GetComponent<NeigboursDetector>().GetNearbyObjects().Count;
                    centerofSheepFlock = sheep.transform.position;
                    centerSheep = sheep;
                }
               
            }
            yield return new WaitForSeconds(waitTime);
        }
       
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(centerofSheepFlock,2);
    }
}




//foreach through all sheep (use a coroutine to only do it every few seconds for efficiency)
// every sheep has a 'Neighbours' script
// Keep track of the highest neighbours count
// have a single 'centerOfFlockSheep'
// NetworkIdentity variable (because netid is automatically synced to clients)

