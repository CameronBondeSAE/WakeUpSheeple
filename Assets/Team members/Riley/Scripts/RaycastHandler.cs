using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    public float distanceToPlatformInfo;
    public float redRayLine;
    public LayerMask RaycastHitLayer;
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit raycastToPlatform;
        if (Physics.Raycast(ray, out raycastToPlatform, 500, RaycastHitLayer))
        {
            Debug.DrawLine(ray.origin, raycastToPlatform.point, Color.green);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * redRayLine, Color.red);
        }
        distanceToPlatformInfo = raycastToPlatform.distance;
    }
}
