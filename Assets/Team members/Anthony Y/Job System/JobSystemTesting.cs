using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class JobSystemTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //job works on a copy of a values not a reference of them
        //original result will still have a value of 0
        
        
        NativeArray<int> result = new NativeArray<int>(1,Allocator.TempJob);
       
        SimpleJob simpleJob = new SimpleJob()
        {
            a = Random.Range(0,100),
            b = Random.Range(0,100),
            result = result,
        };
        JobHandle jobHandle = simpleJob.Schedule();
        jobHandle.Complete();
        Debug.Log(simpleJob.result[0]);
        Debug.Log( "Ihave started " + jobHandle);

        //Always dispose of the memory, unmanaged memory locations
        result.Dispose();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public struct SimpleJob : IJob
{
    public int a;
    public int b;
    public NativeArray<int> result;
    public void Execute()
    {
       
        result[0] = a + b;
        
       
       
        Debug.Log("I have executed");
    }
}

public struct SimpleJobby : IJob
{
    public void Execute()
    {
       
    }
}
