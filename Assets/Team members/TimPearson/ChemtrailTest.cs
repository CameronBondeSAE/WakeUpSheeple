using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tim
{
    

public class ChemtrailTest : NetworkBehaviour
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
    public Vector3 startingPosition;
    public CoreSheepFinder coreSheepFinder;
    public AudioSource planeSound;


    // Start is called before the first frame update
    private void Awake()
    {
        
        gameManager = FindObjectOfType<GameManager>();
    }
    

    public override void OnStartServer()
    {
        base.OnStartServer();
        startingPosition = transform.position;
        if (target == null)
        {
            //Debug.LogWarning("Chemplane NEEDS a target set",this);
            //return;
        }
        coreSheepFinder = gameManager.GetComponent<CoreSheepFinder>();
        StartCoroutine("FlyOverSequence");
        // trail = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        
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

        if (isServer)
        {
            // CAM FIX
            if (rb.velocity.magnitude > 0.01f)
            {
                transform.forward = rb.velocity;
            }
        }
       

    }
    IEnumerator FlyOverSequence()
    {
        while (true)
        {
            
            if (gameManager is null)
            {
                gameManager = FindObjectOfType<GameManager>();
            }
            //yield return new WaitForSeconds(5f);
            Vector3 position = coreSheepFinder.centerofSheepFlock + new Vector3(Random.Range(-41f, 58f), planeHeight, Random.Range(-46, 54));
            transform.position = position;
			if (!(gameManager is null))
			{
                
				
				if (coreSheepFinder != null) 
				{
					Vector3 targetPos = coreSheepFinder.centerofSheepFlock;
					targetPos.y = coreSheepFinder.centerofSheepFlock.y + planeHeight;
					velocity    = (targetPos - transform.position).normalized * speed;
				}
                else
                {
                    Debug.Log("This is not working");
                }
			}
            
			yield return new WaitForSeconds(10f);
            planeSound.Play();
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
