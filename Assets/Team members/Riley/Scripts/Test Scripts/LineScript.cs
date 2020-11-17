using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.RigidbodyPhysics;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 endPos = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z + 10);
    }

    // Update is called once per frame
    void Update()
    {
        float y = 0;
        float deviation = 0;
        for (int x = 0; x < 10; x++)
        {
            deviation = deviation + Mathf.Cos(Time.time);
            y = y + deviation * 1.5f;
            
        }
    }
}
