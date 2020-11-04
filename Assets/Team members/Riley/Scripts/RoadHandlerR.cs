using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class RoadHandlerR : MonoBehaviour
{
    public GameObject CarObjectToSpawn;
    private Vector3 carVector;
    private Rigidbody rb;
    private float speedCarR = 0.2f;
    GameObject instantiate;
    // Start is called before the first frame update
    void Start()
    {
        carVector = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        
        instantiate = Instantiate<GameObject>(CarObjectToSpawn, carVector, transform.rotation);
        rb = instantiate.GetComponent<Rigidbody>();
        //FindObjectOfType<CarHandlerR>().DeleteEvent += deleteEvent;
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(-transform.right * speedCarR);
    }

    void deleteEvent()
    {
        
    }
    
    
}
