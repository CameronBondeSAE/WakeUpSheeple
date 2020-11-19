using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{



    public enum RayType
    {
        RaycastBool,
        RaycastOut
    }

    public class RayTracing : MonoBehaviour
    {

        public RayType RayType = RayType.RaycastOut;
        public ParticleSystem ParticleSystem;
        Ray ray = new Ray();
        RaycastHit raycastHit = new RaycastHit();
        public float turnSpeed = 50f;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            switch (RayType)
            {
                case RayType.RaycastBool:
                    RaycastBool();
                    break;
                case RayType.RaycastOut:
                    RaycastOut();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RaycastBool()
        {
            if (Physics.Raycast(transform.position, transform.forward))
            {
                //Rotate the object if the raycast detects something
                transform.Rotate(0, Time.deltaTime * turnSpeed, 0);
            }
        }


        private void RaycastOut()
        {
            ray.origin = transform.position;
            ray.direction = transform.forward;

            if (Physics.Raycast(ray, out raycastHit, 10f))
            {
                ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
                emitParams.position = raycastHit.point;
                ParticleSystem.Emit(emitParams, 1);
                
                
                //rotate the object when there is something in front of it
                transform.Rotate(0, Time.deltaTime * turnSpeed, 0);
            }
        }

        private void OnDrawGizmos()
        {
            if (raycastHit.transform != null && RayType == RayType.RaycastOut)
            {
                //Where has it hit
                Gizmos.color = Color.red;
                Gizmos.DrawLine(ray.origin,raycastHit.point);
                
                //Hit something
                Gizmos.color = Color.blue;
                Gizmos.DrawRay(raycastHit.point, raycastHit.normal);
                
                //Reflected after bouncing off a wall
                Gizmos.color = Color.yellow;
                Gizmos.DrawRay(raycastHit.point, Vector3.Reflect(ray.direction, raycastHit.normal));
            }
        }
    }
}