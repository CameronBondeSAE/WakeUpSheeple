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
		    finder = Instantiate(pFinder, startPos + new Vector3(0,1,0), Quaternion.identity);
	    }

	    /// <summary>
	    /// Check where im stepping to, if its a blocked node, or one thats already visited, etc.
	    /// Then move based on the response.
	    /// </summary>
	    public void stepTo(float x, float z)
	    {
		    currPos = startPos + new Vector3(x, 1, z);
		    
		    
		    if (finder)
		    {
			    finder.transform.position = new Vector3(currPos.x,currPos.y,currPos.z);
		    }
	    }
	    
	    
    }

}