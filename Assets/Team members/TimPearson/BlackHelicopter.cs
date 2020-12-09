using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tim
{

    public class BlackHelicopter : MonoBehaviour
    {
        public Transform target;
        public float speed;
        private int current;
        private Vector3 velocity;
        public GameObject enemy;
        public float heliHeight;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(StrafeRunSequence());
        }

        // Update is called once per frame
        void Update()
        {
            GetComponent<Rigidbody>().velocity = velocity;
            Rigidbody rb = GetComponent<Rigidbody>();
            transform.forward = rb.velocity;
        }

        IEnumerator StrafeRunSequence()
        {
            while (true)
            {

                //yield return new WaitForSeconds(5f);
                Vector3 position = new Vector3(Random.Range(-41f, 58f), heliHeight, Random.Range(-46, 54));
                transform.position = position;
                Vector3 targetPos = target.position;
                targetPos.y = heliHeight;
                velocity = (targetPos - transform.position).normalized * speed;
                yield return new WaitForSeconds(5f);
            }
        }
        public void StrafeOff()
        {
            
        }

        public void StrafeOn()
        {
            
        }
    }
}
