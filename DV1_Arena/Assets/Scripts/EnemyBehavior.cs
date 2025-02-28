using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void Update()
    {
        if(agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {
        if(locations.Count == 0)
        {
            return;
        }
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }
    //OnTriggerEnter fires whenever an object enters the same Enemy Sphere Collider radius
    void OnTriggerEnter (Collider other) 
    {
        //other accesses the name of the colliding GameObject and checks if it's the Player
        if (other.name == "Player")
        {
            agent.destination = player.position;
            Debug.Log("Player detected - attack!");
        }
    }

    //OnTriggerExit fires when an object leaves the Enemy Sphere Collider Radius
    void OnTriggerExit(Collider other)
    {
        //check the object leaving the Enemy Sphere collider Radius 
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
}
