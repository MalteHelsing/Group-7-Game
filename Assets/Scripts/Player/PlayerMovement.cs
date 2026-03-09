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

    [Header("Fall speeds")]
    [SerializeField] float FallSpeed = -10f;
    [SerializeField] float PlatformFallSpeed = -20f;

    [Header("Jump Assist")]
    [SerializeField] float coyoteTime = 0.1f;
    [SerializeField] float jumpBufferTime = 0.1f;

    [Header("Music & SFX")]
    [SerializeField] AudioClip jumpSound;
    [SerializeField, Range(0, 1)] float jumpVolume;

    bool canControlPlayer = true;
    public float currentSpeed;

    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    Vector2 moveVector;
    Rigidbody2D rb;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction crouchAction;
    InputAction dashAction;

    SpearLooker spearLooker;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Player/Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        crouchAction = InputSystem.actions.FindAction("Crouch");
        dashAction = InputSystem.actions.FindAction("Dash");
        
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        if (canControlPlayer == true)
        {
            Movement();
            Jump();
            JumpTimer();
            FallThrough();
        }
    }

    void Movement()
    {
        // Movement
        moveVector = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = moveVector.x * moveSpeed;

        // Spearturn
        if (moveVector.x == 2)
        {
            spearLooker.SpearLookRight();
        }
        else if (moveVector.x == -2)
        {
            spearLooker.SpearLookLeft();
        }
        
        // Crouch
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

    public void Death()
    {
        canControlPlayer = false;
    }

    void FallThrough()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            Physics2D.gravity = new Vector3(0, PlatformFallSpeed, 0);
        }
        else if (Keyboard.current.sKey.wasReleasedThisFrame)
        {
            Physics2D.gravity = new Vector3(0, FallSpeed, 0);
        }
    }
}