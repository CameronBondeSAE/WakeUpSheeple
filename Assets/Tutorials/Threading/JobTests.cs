using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class JobTests : MonoBehaviour
{
	public JobHandle jobHandle1;
	
    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < 100; i++)
		{
			JobTest camJob = new JobTest();
			jobHandle1 = camJob.Schedule();
		}

    }
}
