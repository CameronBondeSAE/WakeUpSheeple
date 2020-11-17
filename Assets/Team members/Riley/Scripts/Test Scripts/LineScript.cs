using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Mirror;
using Mirror.Examples.RigidbodyPhysics;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public GameObject pos0;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    int timePassed = 0;
    public float transformObject = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 a = Vector3.Lerp(pos0.transform.position, pos1.transform.position, transformObject);
        Vector3 b = Vector3.Lerp(pos1.transform.position, pos2.transform.position, transformObject);
        Vector3 c = Vector3.Lerp(pos2.transform.position, pos3.transform.position, transformObject);
        Vector3 d = Vector3.Lerp(a, b, transformObject);
        Vector3 e = Vector3.Lerp(b, c, transformObject);
        this.transform.position = Vector3.Lerp(d, e, transformObject);
    }
}
