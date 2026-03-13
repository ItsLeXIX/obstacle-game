using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float forwardForce = 500f;
    public float sidewayForce = 200f;
    public float jumpForce = 300f;
    public int jumpCount = 3;
    public float jumpCd = 3f;
    public float nextJumpTime = 0f;

    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    private Vector2 moveInput;
    private bool jumpQueued;

    private void Start()
    {
        InvokeRepeating("AddJump", 10f, 10f);
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        jumpAction.action.performed += OnJumpPerformed; 
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
        jumpAction.action.performed -= OnJumpPerformed;
    }
    void FixedUpdate()
    {
        Vector3 velocity = rigidBody.linearVelocity;
        velocity.z = forwardForce * Time.deltaTime;
        rigidBody.linearVelocity = velocity;

        if (moveInput.x > 0.1f)
        {
            rigidBody.AddForce(sidewayForce * Time.deltaTime, 0, 0);
        }

        if (moveInput.x > -0.1f) 
        {
            rigidBody.AddForce(-sidewayForce * Time.deltaTime, 0, 0);
        }

        if (jumpQueued && Time.time >= nextJumpTime)
        {
            jumpCount--;
            rigidBody.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
            nextJumpTime = Time.time + jumpCd;
 
        }

        if (rigidBody.position.y < -0.5)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        jumpQueued = true;
    }

    public void AddJump()
    {
        jumpCount++;
    }
}
