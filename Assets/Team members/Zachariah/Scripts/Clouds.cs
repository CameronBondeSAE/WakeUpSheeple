using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{


    public class Clouds : MonoBehaviour
    {
        public GameManager gameManager;

        public CoreSheepFinder CoreSheepFinder;

        public Vector3 centreSheep;

        public Vector3 moving;

        public float distanceX;
        public float distanceY;
        public float distanceZ;

        public Vector3 distance;
        // Start is called before the first frame update
        void Start()
        {
            distanceX = centreSheep.x - transform.position.x;
            distanceY = centreSheep.y - transform.position.y;
            distanceZ = centreSheep.z - transform.position.z;
            distance = new Vector3(distanceX,distanceY,distanceZ);
            
            
        }

        // Update is called once per frame
        void Update()
        {
            centreSheep = new Vector3(CoreSheepFinder.centerofSheepFlock.x,CoreSheepFinder.centerofSheepFlock.y,CoreSheepFinder.centerofSheepFlock.z);
            //transform.position = Vector3.MoveTowards(transform.position, centreSheep,1f);
            transform.Translate(distance * Time.deltaTime);
        }
    }
}