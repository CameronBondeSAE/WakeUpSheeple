using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropagandaTV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVideo());
        
    }
    
    // Update is called once per frame
    void Update()
    {
        DetectSheep();
    }
    
    public void DetectSheep()
    {
        
    }


    public IEnumerator PlayVideo()
    {
        //PlayVideo on TV
        yield return new WaitForSeconds(10f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}