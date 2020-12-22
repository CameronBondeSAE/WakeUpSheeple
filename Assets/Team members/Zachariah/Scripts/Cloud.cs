using System;
using System.Collections;
using System.Collections.Generic;
using AJ;
using LukeBaker;
using UnityEngine;
using Random = UnityEngine.Random;
 
/*Notes:
Added a link to get component lightningon to activate lightning then use a timer to delete after spawned for a few seconds
Added humidity from the weather manager (this needs to be dragged in as a public game object)
Fixed lightning spawn to actually spawn on the cloud even if main flock is not available

*/
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
        private GameObject LightningStrike;
        public bool spawnLighting = true;
        private ParticleSystem ps; //This is so we can change cloud spawn rate - RM
        private ParticleSystem.MainModule main;
        public WeatherManagerAJ weatherManager;
        private float probability = 0.01f;

        private Vector3 point;
        
        // Start is called before the first frame update
        void Start()
        {
            ps = GetComponent<ParticleSystem>();
            distanceX = centreSheep.x - transform.position.x;
            //distanceY = centreSheep.y - transform.position.y;
            distanceZ = centreSheep.z - transform.position.z;
            distance = new Vector3(distanceX,0f,distanceZ);
            if (weatherManager == null)
            {
                Debug.Log("Clouds Probability is running without the weathermanager");
                probability = 0.01f;
            }
            else
            {
                main = ps.main;
            }
            // if (CoreSheepFinder.centerofSheepFlock != null) //Simple null check to tell the dev what they need - RM
            // {
                // Debug.LogWarning("The center of sheep cannot be detected. Is the game manager in?");
            // }
        }

        // Update is called once per frame
        void Update()
        {
            point = (Random.insideUnitSphere * 5) + transform.position;
            if (weatherManager != null)
            {
                main.maxParticles = Mathf.RoundToInt(weatherManager.Humidity * 1000);
            }
            //transform.position = Vector3.MoveTowards(transform.position, centreSheep,1f);
            //Use of cloudMovingSpeed is for changing the overall speed of the cloud moving
            // if (CoreSheepFinder.centerofSheepFlock != null) //Null check again to keep update running without it incase - RM
            // {
                // centreSheep = new Vector3(CoreSheepFinder.centerofSheepFlock.x,CoreSheepFinder.centerofSheepFlock.y,CoreSheepFinder.centerofSheepFlock.z);
            // }
            transform.Translate((distance * Time.deltaTime) * cloudMovingSpeed);
        }

        private void FixedUpdate()
        {
            if (weatherManager != null)
            {
                probability = weatherManager.Humidity/150; //Humidity can be changed here. It is the easy way of changing it - RM
            }
            if (Random.value < probability)
            {
                Lightning();
            }
            //Random.insideUnitSphere
        }
        void Lightning() //Makes the object, turns it on, then deletes it after a few seconds - RM
        {
            LightningStrike = Instantiate(lightning, point, new Quaternion(0, 0, 0, 0));
            LightningStrike.GetComponent<Lightning>().LightningOn();
            Destroy(LightningStrike, 1.5f);
        }
        public void ForceLightning() //This is for a quick editor script I wrote to test lightning - RM
        {
            Lightning();
        }
    }
}