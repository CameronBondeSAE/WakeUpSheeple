using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TweenTestZach : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float xScale = 0.5f;
    public float yScale = 0.5f;
    public float zScale = 3.5f;
    public float duration = 2f;
    void Start()
    {
        Sequence summon = DOTween.Sequence();
        summon.Append(transform.DOScale(new Vector3(xScale,yScale,zScale), duration));
        summon.Append(transform.DOLookAt(new Vector3(0, 0), duration));
        //summon.Append(transform.DORotate(new Vector3(0,0,360),3f*Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
