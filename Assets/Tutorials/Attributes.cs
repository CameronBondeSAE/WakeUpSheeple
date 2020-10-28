using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[HelpURL("www.cameronbonde.com")]
public class Attributes : MonoBehaviour
{
	[SerializeField]
	[Range(0,100)]
	int health;

	[Header("More things")]

	[SerializeField]
	[Tooltip("Player name goes here")]
	string nameOfThing;

	[SerializeField]
	[HideInInspector]
	bool tickBox;

	[Multiline(4)]
	[SerializeField]
	[HideInInspector]
	public string thing;


	[SerializeField]
	ParticleSystem fx;

	public Rigidbody rb;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0,100,0);
    }
}
