using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestGuyStuff : MonoBehaviour
{

    public event Action<GameObject, int> jumpEvent;
    public float force = 50;
    private Rigidbody _rB;
    public int jumpCount;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        _rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {

            jumpCount++;
            jumpEvent?.Invoke(this.gameObject, jumpCount);
            _rB.AddForce(0,force,0);
        }
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        jumpCount = 0;
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
}
