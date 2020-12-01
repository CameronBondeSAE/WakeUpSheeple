using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    public float distanceToPlatformInfo;
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit raycastToPlatform;
        if (Physics.Raycast(ray, out raycastToPlatform))
        {
            Debug.DrawLine(ray.origin, raycastToPlatform.point, Color.green);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
        }
        distanceToPlatformInfo = raycastToPlatform.distance;
    }
}
