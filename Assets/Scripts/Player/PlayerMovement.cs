using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float crouchSpeed = 1f;
    [SerializeField] float jumpHeight = 10f;
    [SerializeField] float jumpDistance = 2f;
    [SerializeField] LayerMask groundLayer;

    [Header("Jump Assist")]
    [SerializeField] float coyoteTime = 0.1f;
    [SerializeField] float jumpBufferTime = 0.1f;

    [Header("Music & SFX")]
    [SerializeField] AudioClip jumpSound;
    [SerializeField, Range(0, 1)] float jumpVolume;

    bool canControlPlayer = true;
    private float currentSpeed;

    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    Vector2 moveVector;
    Rigidbody2D rb;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction crouchAction;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Player/Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        crouchAction = InputSystem.actions.FindAction("Crouch");
        rb = GetComponent<Rigidbody2D>();

        currentSpeed = moveSpeed;
    }

    void Update()
    {
        if (canControlPlayer == true)
        {
            Move();
            Crouch();
            Jump();
            JumpTimer();
        }
    }

    void Move()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = moveVector.x * currentSpeed;
    }

    void JumpTimer()
    {
        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, jumpDistance, groundLayer);

        // Ground check
        if (ground.collider != null)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Jump buffer
        if (jumpAction.WasPressedThisFrame())
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    void Jump()
    {
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.linearVelocityY = jumpHeight;

            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;

            if (jumpSound != null)
            {
                AudioSource.PlayClipAtPoint(jumpSound, transform.position, jumpVolume);
            }
        }
    }

    void Crouch()
    {
        if (crouchAction.IsPressed())
        {
            currentSpeed = crouchSpeed;
            rb.rotation = 90; // temporary
        }
        else
        {
            currentSpeed = moveSpeed;
            rb.rotation = 0; // temporary
        }
    }

    public void Death()
    {
        canControlPlayer = false;
    }
}