using AlexM;
using UnityEngine;
using UnityEngine.UIElements;

namespace Zach
{
    //locate nearest sheep
    //move towards nearest sheep
    //attach to sheep and create new virus object
    public class VirusBehaviour : MonoBehaviour
    {
        //private Vector3 currentVelocity;
        //public float velocity;
        //public GameObject Sheep;
        public Sheep isAttached;

        [Tooltip("Prefab for the Virus for instantiate")]
        public GameObject virus;

        //public Vector3 virusLocation;
        [Tooltip("How long it takes for the virus to be able to breed")]
        public float incubation;

        [Tooltip("How long it takes the virus to die without being attached")]
        public float deathTimer = 15f;

        [SerializeField] [Tooltip("Location for the virus prefab to be stored")]
        private GameObject instantiate;

        public float convertTimer;

        // Start is called before the first frame update\

        private void Awake()
        {
            //resetting bool here due to instantiate cloning instance not prefab
            //isAttached = false;
        }

        

        // Update is called once per frame
        // Movement and location of sheep
        private void Update()
        {
            //transform.LookAt(Sheep.transform);
            //transform.position += transform.forward * velocity * Time.deltaTime;
            incubation += Time.deltaTime;
            if (deathTimer > 0f)
                deathTimer -= 1 * Time.deltaTime;
            else if (deathTimer < 0f) Destroy(gameObject);
            if (isAttached) deathTimer = 10000f;
            if (isAttached)
            {
                convertTimer += Time.deltaTime;
            }
            
            if (convertTimer > 10f)
            {
                GetComponentInParent<Sheep>().ChangeToBlack();
            }
        }


        //attachment to sheep 
        private void OnTriggerEnter(Collider other)
        {
            //transform.parent;
            if (other.GetComponent<Sheep>())
            {
                if (isAttached == false && !other.gameObject.GetComponentInChildren<VirusBehaviour>())
                {
                    var transform1 = transform;
                    transform1.parent = other.transform;
                    transform1.localPosition = new Vector3(0, 1, 0);

                    isAttached = other.GetComponent<Sheep>();
                    Debug.Log("Virus Attached");
                    
                    
                }
                else if (isAttached)
                {
                    //finish creating the instatiate (creates another prefab of virus to simulate infection)
                    //create if statement that uses the incubation float to create new viruses 
                    Debug.Log("Incubate Start");
                    if (incubation > 5f && !other.GetComponentInChildren<VirusBehaviour>())
                    {
                        incubation = 0f;
                        instantiate = Instantiate(virus, other.transform.position, new Quaternion(0, 0, 0, 0));
                    }
                }

                //record that I have been attached
            }
        }

        //Button test for breeding the virus
        public void Breed()
        {
            instantiate = Instantiate(virus, transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
}