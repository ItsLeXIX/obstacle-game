using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            playerMovement.forwardForce = 0;
        }
    }
}
