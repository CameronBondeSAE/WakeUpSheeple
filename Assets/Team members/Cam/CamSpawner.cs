using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSpawner : MonoBehaviour
{
	public GameObject prefab;
	public float      radius;
	public int        amount;

	// Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < amount; i++)
		{
			Vector2 insideUnitCircle       = Random.insideUnitCircle;
			Vector3 randomInsideUnitCircle = new Vector3(insideUnitCircle.x, 0, insideUnitCircle.y);

			GameObject newGo = Instantiate(prefab, transform.position + (randomInsideUnitCircle * radius), Quaternion.Euler(0,Random.Range(0,360),0));
		}
    }
}
