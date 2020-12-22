using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SubscribedObject1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<buttonHandler>().buttonEvent += randomPos;
    }
    void randomPos()
    {
        transform.position = new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y, transform.position.z + Random.Range(-5, 5));
    }
    private void OnDisable()
    {
        FindObjectOfType<buttonHandler>().buttonEvent -= randomPos;
    }
}
