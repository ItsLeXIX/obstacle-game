using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            playerMovement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
