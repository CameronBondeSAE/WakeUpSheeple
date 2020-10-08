using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChemtrailTest : MonoBehaviour
{
    public Transform target;
    public float speed;
    private int current;
    private Vector3 velocity;

    
    // Start is called before the first frame update
    void Start()
    {
        velocity = (target.position - transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent < Rigidbody > ().velocity=velocity;
        
    }
}
