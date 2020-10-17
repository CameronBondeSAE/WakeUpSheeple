using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{

[RequireComponent(typeof(Collider))]
    public class FlockAgent : MonoBehaviour
    {
        private Collider agentCollider;
        public Collider AgentCollider
        {
            get { return agentCollider; }
        }

        public Rigidbody rb;
        
        // Start is called before the first frame update
        void Start()
        {
            agentCollider = GetComponentInChildren<Collider>();
            rb = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 velocity)
        {
            transform.forward = velocity;
            rb.AddForce(velocity * Time.deltaTime);
           // transform.position += velocity * Time.deltaTime;
        }
    }
}
