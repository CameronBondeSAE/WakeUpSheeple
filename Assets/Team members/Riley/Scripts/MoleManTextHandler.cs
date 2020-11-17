using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class MoleManTextHandler : MonoBehaviour
{
    public TextMeshProUGUI moleManTextMeshHandler;

    private void Start()
    {
        moleManTextMeshHandler = GetComponent<TextMeshProUGUI>();
        FindObjectOfType<MoleManManager>().tmpEventStand += OnStand;
        FindObjectOfType<MoleManManager>().tmpEventJump += OnJumpState;
        FindObjectOfType<MoleManManager>().tmpEventWaypoint += OnWaypointFollow;
    }

    public void OnStand()
    {
        moleManTextMeshHandler.text = "<b> On Start: </b> The mole will wait, after a set period of time the mole will swap to the Waypoint state.";
    }

    public void OnWaypointFollow()
    {
        moleManTextMeshHandler.text = "<b> On Waypoint: </b> The mole will follow the nearest Sheep until in the safe distance.";
    }

    public void OnJumpState()
    {
        moleManTextMeshHandler.text = "<b> On Jump: </b> The mole will begin to lift from the ground until an expected time has been reached.";
    }
}
