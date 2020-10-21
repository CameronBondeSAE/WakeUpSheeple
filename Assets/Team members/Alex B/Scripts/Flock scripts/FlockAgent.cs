using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    [RequireComponent(typeof(Collider))]

    public class FlockAgent : MonoBehaviour
    {
        public Rigidbody rb;
        private Flock agentFlock;
        public Flock AgentFlock
        {
            get
            {
                return agentFlock; 
                
            }
        }
        
        Collider agentCollider;
        
        public Collider AgentCollider
        {
            get
            {
                return agentCollider; 
                
            }
        }

        public void Initialize(Flock flock)
        {
            agentFlock = flock;
        }

        // Start is called before the first frame update
        void Start()
        {
            agentCollider = GetComponent<Collider>();
        }

        public void Move(Vector3 velocity)
        {
            transform.forward = velocity;
            velocity = new Vector3(velocity.x, transform.position.y, velocity.z);
            rb.AddForce(velocity * Time.deltaTime);
            //transform.position += (Vector3)velocity * Time.deltaTime;

            

            //Use add force for speed and torque for angles after finishing the tutorial.
        }
    }
}

