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
        clay.SetInt(RotationAmount,Random.Range(0,360));
    }
}
