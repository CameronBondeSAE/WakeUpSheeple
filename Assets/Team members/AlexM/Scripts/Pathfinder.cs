using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexM
{
    public class Pathfinder : MonoBehaviour
    {
	    public WorldScanner scanner;
	    public GameObject pFinder;

	    public Vector3 startPos;
	    public Vector3 currPos;

	    private GameObject finder;
	    private void Start()
	    {
		    scanner = FindObjectOfType<WorldScanner>();
		    startPos = scanner.transform.position;
		    currPos = startPos + new Vector3(0,1,0);
		    finder = Instantiate(pFinder, startPos + new Vector3(0,1,0), Quaternion.identity);
	    }

	    private void FixedUpdate()
	    {
		    ScanForMove();
	    }

	    /// <summary>
	    /// Check where im stepping to, if its a blocked node, or one thats already visited, etc.
	    /// Then move based on the response.
	    /// </summary>
	    public void stepTo(float x, float z)
	    {
		    currPos += new Vector3(x, 0, z);
		    
		    if (finder)
		    {
			    finder.transform.position = new Vector3(currPos.x,currPos.y,currPos.z);
		    }
	    }

	    void ScanForMove()
	    {
		    RaycastHit hit;
		    var finderPos = finder.transform.position;
		    var ray = Physics.Raycast(finderPos, Vector3.down, out hit, 10f);
		    if (ray)
		    {
			    Debug.Log(" [>" + hit.transform.name + "<] ");
		    }
		    //Debug.DrawRay(finderPos, Vector3.down, Color.blue, 1f);
	    }
	    
	    
	    
    }

}