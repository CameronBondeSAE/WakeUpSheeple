using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class RoadHandler : MonoBehaviour
{
    public GameObject CarObjectToSpawn;
    public GameObject CarEndWaypoint;
    private Vector3 carVector;
    public int carSpeed;
    GameObject instantiate;
    void Start()
    {
        carVector = new Vector3(transform.position.x, transform.position.y, transform.position.z); //Place we spawn
        instantiate = Instantiate<GameObject>(CarObjectToSpawn, carVector, transform.rotation); //Object spawned (Keep for use)
        instantiate.GetComponent<CarHandler>().carRespawnObject = gameObject;
        instantiate.GetComponent<CarHandler>().destinationWaypoint = CarEndWaypoint;
        instantiate.GetComponent<CarHandler>().speed = carSpeed;
    }
}
