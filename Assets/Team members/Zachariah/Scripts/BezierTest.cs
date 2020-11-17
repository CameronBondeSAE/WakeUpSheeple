using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject point0;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public float t;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 a = Vector3.Lerp(point0.transform.position, point1.transform.position,t);
       Vector3 b = Vector3.Lerp(point1.transform.position, point2.transform.position, t);
       Vector3 c = Vector3.Lerp(point2.transform.position, point3.transform.position, t);
       Vector3 d = Vector3.Lerp(a, b, t);
       Vector3 e = Vector3.Lerp(b, c, t);
       this.transform.position = Vector3.Lerp(d, e, t);
    }
}
