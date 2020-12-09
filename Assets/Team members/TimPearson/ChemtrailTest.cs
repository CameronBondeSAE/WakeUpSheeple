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
    public GameObject Virus;
    private GameManager gameManager; 


    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
           Debug.LogWarning("Chemplane NEEDS a target set",this);
           //return;
        }
        //Vector3 position = new Vector3(Random.Range(-41f,58f),2,Random.Range(-46,54));
        //Instantiate(enemy, position, Quaternion.identity);
        StartCoroutine("FlyOverSequence");
       // trail = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!(trail is null) && (!(other.GetComponent<CharacterBase>()is null)))
        {
            int numCollisionEvents = trail.GetCollisionEvents(other, collisionEvents);

            for (int i = 0; i < collisionEvents.Count; i++)
            {
                Vector3 pos = collisionEvents[i].intersection;
                GameObject trailVirus = Instantiate(Virus, pos, Quaternion.identity);
                trailVirus.GetComponent<Zach.VirusBehaviour>().deathTimer = 0.5f;
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity=velocity;
        Rigidbody rb = GetComponent<Rigidbody>();
        transform.forward = rb.velocity;


    }

    IEnumerator FlyOverSequence()
    {
        while (true)
        {
            
            //yield return new WaitForSeconds(5f);
            Vector3 position = new Vector3(Random.Range(-41f, 58f), planeHeight, Random.Range(-46, 54));
            transform.position = position;
            Vector3 targetPos = gameManager.GetComponent<CoreSheepFinder>().centerofSheepFlock;
            targetPos.y = planeHeight;
            velocity = (targetPos - transform.position).normalized * speed;
            yield return new WaitForSeconds(5f);
        }
        
        //Instantiate(enemy, position, Quaternion.identity);
        

    }

    public void TrailOff()
    {
        trail.Stop();
    }

    public void TrailOn()
    {
        trail.Play();
    }
    
}
}
