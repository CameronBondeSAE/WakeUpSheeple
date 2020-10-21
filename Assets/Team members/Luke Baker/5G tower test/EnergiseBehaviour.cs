using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnergiseBehaviour : MonoBehaviour
{
    //variables
    public int timeEffected = 3;
    public bool isEnergised;
    
    IEnumerator EnergiseForTime()
    {
        //apply the energise buff or de-buff here
        //gameObject.GetComponent<Movement>.speed * 3 ??

        yield return new WaitForSeconds(timeEffected);
        
        //removes the script from the object
        Destroy(this);
    }

    private void Start()
    {
        if (isEnergised = true)
        {
            StartCoroutine(EnergiseForTime());
        }
    }
}
