using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoleManWaypointing : MonoBehaviour
{
    public List<Transform> waypointsList = new List<Transform>();
    private Transform currentWaypoint;
    private int currentWaypointIndex;
    private float safeDistance = 0.1f;
    private int previousWaypointIndex;
    private float movementSpeed = 0.05f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        currentWaypointIndex = 0;
        currentWaypoint = waypointsList[currentWaypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentWaypoint.position) > safeDistance)
        {
            transform.LookAt(currentWaypoint);
            rb.AddRelativeForce(Vector3.forward * movementSpeed, ForceMode.Force);
        }
    }
}
