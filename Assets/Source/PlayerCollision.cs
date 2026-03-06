using System;
using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public TextMeshProUGUI gameOver;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            playerMovement.enabled = false;
            GameOver();
        }
    }
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
    }
}
