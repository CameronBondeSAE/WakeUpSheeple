﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexM
{
    public class Flock : MonoBehaviour
    {
        public FlockAgent agentPrefab;
        List<FlockAgent> agents = new List<FlockAgent>();
        public FlockBehavior behavior;

        [Range(10, 1500)] public int startingCount = 250;
        const float AgentDensity = 0.08f;

        [Range(1f, 100f)] public float driveFactor = 10f;

        [Range(1f, 100f)] public float maxSpeed = 5f;

        [Range(1f, 10f)] public float neighborRadius = 1.5f;
        [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;

        float squareMaxSpeed;
        float squareNeighborRadius;
        float squareAvoidanceRadius;
        public float SquareAvoidanceRadius
        {
            get { return squareAvoidanceRadius; }
        }
    
    
    
    
    
        // Start is called before the first frame update
        void Start()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
            squareNeighborRadius = neighborRadius * neighborRadius;
            squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

            for (int i = 0; i < startingCount; i++)
            {
                FlockAgent newAgent = Instantiate(agentPrefab, Random.insideUnitCircle * (startingCount * AgentDensity),
                    Quaternion.identity, transform);

                newAgent.name = "Agent " + i;
                newAgent.rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ |
                                          RigidbodyConstraints.FreezeRotationY;
                //newAgent.Initialize(this);
                agents.Add(newAgent);
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (FlockAgent agent in agents)
            {
                List<Transform> context = GetNearbyObjects(agent);
                
                //agent.GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.green, context.Count / 6f);

                Vector3 move = behavior.CalculateMove(agent, context, this);
                move *= driveFactor;
                if (move.sqrMagnitude > squareMaxSpeed)
                {
                    move = move.normalized * maxSpeed;
                }
                agent.Move(move);

            }
        }

        List<Transform> GetNearbyObjects(FlockAgent agent)
        {
            List<Transform> context = new List<Transform>();
            Collider[] contextCOlliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);
            foreach (Collider c in contextCOlliders)
            {
                if (c != agent.AgentCollider)
                {
                    context.Add(c.transform);
                }
            }

            return context;
        }
    }

}
