using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tim
{
    

public class ChemtrailTest : MonoBehaviour
{
    public Transform target;
    public float speed;
    private int current;
    private Vector3 velocity;
    public GameObject enemy;
    public float planeHeight;
    public ParticleSystem trail;
    public List<ParticleCollisionEvent> collisionEvents;

    
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 position = new Vector3(Random.Range(-41f,58f),2,Random.Range(-46,54));
        //Instantiate(enemy, position, Quaternion.identity);
        StartCoroutine("Restart");
        trail = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();


    }

    private void OnParticleCollision(GameObject other)
    {
        if (!(trail is null))
        {
            int numCollisionEvents = trail.GetCollisionEvents(other, collisionEvents);

            Rigidbody rb = other.GetComponent<Rigidbody>();
            int i = 0;

            while (i < numCollisionEvents)
            {
                if (rb)
                {
                    Vector3 pos = collisionEvents[i].intersection;
                    Vector3 force = collisionEvents[i].velocity * 10;
                    rb.AddForce(force);
                }

                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity=velocity;
        
        
    }

    IEnumerator Restart()
    {
        while (true)
        {
            Debug.Log("Restarting");
            yield return new WaitForSeconds(5f);
            Vector3 position = new Vector3(Random.Range(-41f, 58f), planeHeight, Random.Range(-46, 54));
            yield return new WaitForSeconds(5f);
            transform.position = position;
            Vector3 targetPos = target.position;
            targetPos.y = planeHeight;
            velocity = (targetPos - transform.position).normalized * speed;
            
        }
        
        //Instantiate(enemy, position, Quaternion.identity);
        

    }
    
}
}
