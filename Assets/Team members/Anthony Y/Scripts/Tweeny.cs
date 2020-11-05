using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class Tweeny : MonoBehaviour
{
    public float duration;

    public float bingboing;

    public Renderer wolfSkin;
    public Renderer dogSkin;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector3(2, 2, 2), 2f).SetEase(Ease.OutBounce));
        sequence.AppendCallback(ChangeToWolf);
        sequence.Append(transform.DOScale(new Vector3(1, 1, 1), 2f).SetEase(Ease.OutElastic));
        sequence.Play();
        wolfSkin.enabled = false;
        //can use append callback to turn your controls on and off.
    }

    private void ChangeToWolf()
    {
        wolfSkin.enabled = true;
        dogSkin.enabled = false;
    }

    private void DoneAthing()
    {
        Debug.Log("YAY!");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
