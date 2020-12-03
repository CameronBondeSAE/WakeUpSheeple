using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zach
{


    public class Cloud : MonoBehaviour
    {
        public CoreSheepFinder CoreSheepFinder;

        public Vector3 centreSheep;
        
        private float distanceX;
        private float distanceY;
        private float distanceZ;

        public float cloudMovingSpeed = 0.5f;
        
        private Vector3 distance;
        
        //lightning Instantiate 
        public GameObject lightning;

        public bool spawnLighting = true;

        public float probability = 0.01f;

        public Vector3 point;
        // Start is called before the first frame update
        void Start()
        {
            distanceX = centreSheep.x - transform.position.x;
            //distanceY = centreSheep.y - transform.position.y;
            distanceZ = centreSheep.z - transform.position.z;
            distance = new Vector3(distanceX,0f,distanceZ);
            
        }

        // Update is called once per frame
        void Update()
        {
            centreSheep = new Vector3(CoreSheepFinder.centerofSheepFlock.x,CoreSheepFinder.centerofSheepFlock.y,CoreSheepFinder.centerofSheepFlock.z);
            //transform.position = Vector3.MoveTowards(transform.position, centreSheep,1f);
            
            //Use of cloudMovingSpeed is for changing the overall speed of the cloud moving
            transform.Translate((distance * Time.deltaTime) * cloudMovingSpeed);

            point = (Random.insideUnitSphere * 5) + transform.position;
        }

        private void FixedUpdate()
        {
            if (Random.value < 0.01f)
            {
                Lightning(); 
            }
            //Random.insideUnitSphere
        }

        void Lightning()
        {
            Instantiate(lightning, point, new Quaternion(0, 0, 0, 0));
        }
    }
}