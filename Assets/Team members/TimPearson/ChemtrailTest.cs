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
    public GameObject wall;

    
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 position = new Vector3(Random.Range(-41f,58f),2,Random.Range(-46,54));
        //Instantiate(enemy, position, Quaternion.identity);
        StartCoroutine("Restart");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent < Rigidbody > ().velocity=velocity;
        
        
    }

    IEnumerator Restart()
    {
        while (true)
        {
            Debug.Log("Restarting");
            yield return new WaitForSeconds(5f);
            Vector3 position = new Vector3(Random.Range(-41f, 58f), 2, Random.Range(-46, 54));
            yield return new WaitForSeconds(5f);
            transform.position = position;
            velocity = (target.position - transform.position).normalized * speed;
            
        }
        
        //Instantiate(enemy, position, Quaternion.identity);
        

    }



    // private void OnCollisionEnter(Collision wall)
    // {
    //     if (wall.gameObject.tag == "Enemy")
    //     {
    //         Destroy(enemy.gameObject);
    //     }
    //  
    // }
}
}
