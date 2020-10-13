﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class Flock : MonoBehaviour
    {
        public FlockAgent agentPrefab;
        List<FlockAgent> agents = new List<FlockAgent>();
        public FlockBehaviour behaviour;

        [Range(10, 500)] public int startingCount = 250;

        private const float AgentDensity = 0.08f;

        [Range(1f, 100f)] public float driveFactor = 10f;
        [Range(1f, 100f)] public float maxSpeed = 5f;
        [Range(1f, 10f)] public float neighbourRadius = 1.5f;

        [Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;

        private float squareMaxSpeed;
        private float squareNeighbourRadius;
        private float squareAvoidanceRadius;

        public float SquareAvoidanceRadius
        {
            get { return squareAvoidanceRadius; }
        }
        
        void Start()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
            squareNeighbourRadius = neighbourRadius * neighbourRadius;
            squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

            for (int i = 0; i < startingCount; i++)
            {
                FlockAgent newAgent = Instantiate(agentPrefab, Random.insideUnitSphere * (startingCount * AgentDensity),
                    Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)), transform);

                newAgent.name = "Agent" + i;
                agents.Add(newAgent);
            }
        }
        
        void Update()
        {
            foreach (FlockAgent agent in agents)
            {
                List<Transform> context = GetNearbyObjects(agent);

                Vector3 move = behaviour.CalculateMove(agent, context, this);
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
            Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighbourRadius);

            foreach (Collider c in contextColliders)
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