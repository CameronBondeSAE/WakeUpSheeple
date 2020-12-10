using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderRotaty : MonoBehaviour
{
    public Material clay;
    private static readonly int RotationAmount = Shader.PropertyToID("RotationAmount");

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
        {
            clay.SetInt(RotationAmount,Random.Range(0,360));
        }
        else
        {
            clay.SetInt(RotationAmount, 0);
        }
    }
       
}
