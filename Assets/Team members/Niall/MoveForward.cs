using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 2;
    public float rot;
    public float perlinY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (perlinY <= 0.49f)
        {
            rot = -perlinY;
        }

        else
        {
            rot = perlinY;
        }




        perlinY = Mathf.PerlinNoise(0, Time.time/10f);
        
        rb.AddForce(transform.forward * speed);
        transform.Rotate(0, rot, 0);

       
    }
}
