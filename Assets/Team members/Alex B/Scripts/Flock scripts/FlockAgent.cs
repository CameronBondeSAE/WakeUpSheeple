using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    [RequireComponent(typeof(Collider2D))]

    public class FlockAgent : MonoBehaviour
    {
        private Flock agentFlock;
        public Flock AgentFlock
        {
            get
            {
                return agentFlock; 
                
            }
        }
        
        Collider2D agentCollider;
        //public Rigidbody2D rb2D;
        //private float thrust = 10.0f;

        public Collider2D AgentCollider
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
            agentCollider = GetComponent<Collider2D>();
            
            
        }

        public void Move(Vector2 velocity)
        {
            transform.up = velocity;
            transform.position += (Vector3)velocity * Time.deltaTime;

            

            //Use add force for speed and torque for angles after finishing the tutorial.
        }
    }
}

