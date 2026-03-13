using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float forwardForce = 500f;
    public float sidewayForce = 200f;
    public float jumpForce = 300f;
    public int jumpCount = 3;
    public float jumpCd = 3f;
    public float nextJumpTime = 0f;

    private void Start()
    {
        InvokeRepeating("AddJump", 10f, 10f);
    }
    void FixedUpdate()
    {
        Vector3 velocity = rigidBody.linearVelocity;
        velocity.z = forwardForce * Time.deltaTime;
        rigidBody.linearVelocity = velocity;

        if (Input.GetKey("d"))
        {
            rigidBody.AddForce(sidewayForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a")) 
        {
            rigidBody.AddForce(-sidewayForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("space") && Time.time >= nextJumpTime)
        {
            if (jumpCount > 0)
            {
                jumpCount--;
                rigidBody.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
                nextJumpTime = Time.time + jumpCd;
                Debug.Log("Jumped");
            }
        }

        if (rigidBody.position.y < -0.5)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    public void AddJump()
    {
        jumpCount++;
    }
}
