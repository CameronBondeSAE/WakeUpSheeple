using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

namespace AnthonyY
{
    public class JobTests : MonoBehaviour
    {
        public JobHandle jobHandle1;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                JobTest anthJob = new JobTest();
                jobHandle1 = anthJob.Schedule();
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        public void Execute()
        {
          

        }
    }
}

