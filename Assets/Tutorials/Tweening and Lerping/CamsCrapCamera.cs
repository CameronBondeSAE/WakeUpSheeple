using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CamsCrapCamera : MonoBehaviour
{
	public Transform target;
	public Vector3   offset;
	public float     speed = 10;

    // Update is called once per frame
    void Update()
	{
		// Uses Unity's "Move" functions to do a very simple Tween/Lerp smooth movement
		// transform.position = Vector3.MoveTowards(transform.position, target.position + offset, speed * Time.deltaTime);
		transform.position = Vector3.Slerp(transform.position, target.position + offset, speed * Time.deltaTime);
	}
}
