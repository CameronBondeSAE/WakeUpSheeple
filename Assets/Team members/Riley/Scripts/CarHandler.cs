using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Conditions;
using UnityEngine;
using UnityEngine.Events;

public class CarHandler : MonoBehaviour
{
    public GameObject carRespawnObject;
    private Vector3 carRespawnPoint;
    public GameObject destinationWaypoint;
    public float speed = 15f;
    private float safeDistance = 5f;
    void Update()
    {
        carRespawnPoint = new Vector3(carRespawnObject.transform.position.x, carRespawnObject.transform.position.y, carRespawnObject.transform.position.z); //Takes our respawn point
        if (destinationWaypoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinationWaypoint.transform.position, speed * Time.deltaTime); //move towards waypoint
        }

        if (Vector3.Distance(transform.position, destinationWaypoint.transform.position) < safeDistance)
        {
            transform.position = carRespawnPoint;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<Health>();
        if (health != null)
        {
            health.Damage(1000);
        }
    }
}
