using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Tim
{
    public class GenericSpawner : MonoBehaviour
    {
        public int number = 10;
        public GameObject prefab;

        [SerializeField] private Vector2 radius;
        // Start is called before the first frame update
        void Start()
        {
            //transform.position = Random.insideUnitSphere * 5;
            for (int i = 0; i < number; i++)
            {
                Vector2 insideUnitCircle = Random.insideUnitCircle * radius;
                Vector3 flatPos = new Vector3(insideUnitCircle.x, 1, insideUnitCircle.y);
                GameObject newGo = Instantiate(prefab, flatPos, Quaternion.identity);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
        
        public void Spawn()
        {
            for (int i = 0; i < number; i++)
            {
                Vector2 insideUnitCircle = Random.insideUnitCircle * radius;
                Vector3 flatPos = new Vector3(insideUnitCircle.x, 1, insideUnitCircle.y);
                GameObject newGo = Instantiate(prefab, flatPos, Quaternion.identity);
            }
        }
    }
}