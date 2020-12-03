using System.Collections.Generic;
using AnthonyY;
using UnityEngine;

namespace Team_members.Niall.Scripts.Cameras 
{


    [RequireComponent(typeof(Camera))]
    public class CameraPlayer : MonoBehaviour
    {
        public List<Transform> camtarget = new List<Transform>();
        public Transform OwnPlayer;
        public Camera cam;
        public float smoothSpeed;
        public Vector3 offset;


        public float minZoom = 10f;
        public float maxZoom = 25f;
        public float zoomLimiter = 50f;
        private Vector3 velocity;

        private void Awake()
        {
            FindObjectOfType<GameManager>().playersSpawnedEvent += OnPlayersSpawnedEvent;
            cam = GetComponent<Camera>();
        }

        private void OnPlayersSpawnedEvent(PlayerBehaviour player)
        {
            // if (player.isLocalPlayer)
            //  {
            //      target = player.transform;
            //   }

            OwnPlayer = player.transform;
            camtarget.Add(OwnPlayer);
        }



        private void LateUpdate()
        {
            if (camtarget.Count == 0)
                return;


            Move();
            Zoom();

        }

        void Move()
        {
            Vector3 centrePoint = GetCentrePoint();

            Vector3 newPos = centrePoint + offset;

            if (camtarget != null)
            {
                transform.position = Vector3.SmoothDamp(transform.position, newPos + offset,
                    ref velocity, smoothSpeed);
            }
        }

        void Zoom()
        {
            float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDist() / zoomLimiter);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
        }

        Vector3 GetCentrePoint()
        {
            if (camtarget.Count == 1)
            {
                return camtarget[0].position;
            }

            var bounds = new Bounds(camtarget[0].position, Vector3.zero);
            for (int i = 0; i < camtarget.Count; i++)
            {
                bounds.Encapsulate(camtarget[i].position);
            }

            return bounds.center;
        }

        float GetGreatestDist()
        {
            var bounds = new Bounds(camtarget[0].position, Vector3.zero);
            for (int i = 0; i < camtarget.Count; i++)
            {
                bounds.Encapsulate(camtarget[i].position);
            }

            return bounds.size.x;

        }


    }
}