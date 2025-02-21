using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //OnTriggerEnter fires whenever an object enters the same Enemy Sphere Collider radius
    void OnTriggerEnter (Collider other) 
    {
        //other accesses the name of the colliding GameObject and checks if it's the Player
        if (other.name == "Player")
        {
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
