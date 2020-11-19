using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DotweenJohn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float xScale = 1f;
    public float yScale = 3f;
    public float zScale = 15f;
    public float duration = 1.5f;

    void Start()
    {
        Sequence summon = DOTween.Sequence();
        summon.Append(transform.DOScale(new Vector3(xScale, yScale, zScale), duration));
        summon.Append(transform.DOLookAt(new Vector3(0, 25), duration));
    }
}
