using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveScriptDamien : MonoBehaviour
{
    public GameObject position0;
    public GameObject position1;
    public GameObject position2;
    public GameObject position3;
    public GameObject point;

    public bool curveRunning = true;

    public float transformPoint = 0f;

    void Update()
    {
        Vector3 a = Vector3.Lerp(position0.transform.position, position1.transform.position, transformPoint);
        Vector3 b = Vector3.Lerp(position1.transform.position, position2.transform.position, transformPoint);
        Vector3 c = Vector3.Lerp(position2.transform.position, position3.transform.position, transformPoint);
        Vector3 d = Vector3.Lerp(a, b, transformPoint);
        Vector3 e = Vector3.Lerp(b, c, transformPoint);

        while(curveRunning == true);
        {
            transformPoint = Mathf.PerlinNoise(0, 1);
        }
        
        point.transform.position = Vector3.Lerp(d, e, transformPoint);
    }

}
