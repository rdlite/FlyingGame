using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObstacleTriggerCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Obstacle>() != null)
        {
            other.GetComponent<Obstacle>().CountObstacle();
            other.GetComponent<Obstacle>().DestroyObstacle();
        }
    }
}