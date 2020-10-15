using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    private int layerMask = 1 << 8;
    public event Action<float> detector_fwd_dist;
    private void FixedUpdate()
    {
        layerMask = ~layerMask;
    }

    public void Detect_FWD()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            
            float dist;
            dist = Vector3.Distance(transform.position, hit.transform.position);
            detector_fwd_dist?.Invoke(dist);
        }
    }
}
