using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPTextHandlerR : MonoBehaviour
{
    public TextMeshProUGUI textMeshR;

    private void Start()
    {
        textMeshR = GetComponent<TextMeshProUGUI>();
    }

    public void OnStand()
    {
        textMeshR.text = "<b> On Start: </b> The mole will wait, after a set period of time the mole will swap to the Waypoint state.";
    }

    public void OnWaypointFollow()
    {
        textMeshR.text = "<b> On Waypoint: </b> The mole will follow the nearest Sheep until in the safe distance.";
    }

    public void OnJumpState()
    {
        textMeshR.text = "<b> On Jump: </b> The mole will begin to lift from the ground until an expected time has been reached.";
    }
}
