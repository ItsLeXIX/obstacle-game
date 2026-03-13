using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float forwardForce = 500f;
    public float sidewayForce = 200f;
    void FixedUpdate()
    {
        rigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            rigidBody.AddForce(sidewayForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a")) 
        {
            rigidBody.AddForce(-sidewayForce * Time.deltaTime, 0, 0);
        }

        if (rigidBody.position.y < -0.5)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
