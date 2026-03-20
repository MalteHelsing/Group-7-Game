using System.Collections;
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

    [Header("Dash")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCoolDown = 1f;
    bool isDashing;

    [Header("Jump Assist")]
    [SerializeField] float coyoteTime = 0.1f;
    [SerializeField] float jumpBufferTime = 0.1f;

    [Header("Fall Through")]
    [SerializeField] float fallSpeed = -10f;
    [SerializeField] float platformFallSpeed = -20f;

    [Header("Music & SFX")]
    [SerializeField] private AudioClip jumpSound;

    bool canControlPlayer = true;
    private float currentSpeed;

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
            DoDash();
        }
    }

    void Movement()
    {
        // Movement
        moveVector = moveAction.ReadValue<Vector2>();
        rb.linearVelocityX = moveVector.x * moveSpeed;

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

            //SoundManager.Instance.PlaySound(jumpSound);

            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;
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

    void FallThrough()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            Physics2D.gravity = new Vector3(0, platformFallSpeed, 0);
        }
        else if (Keyboard.current.sKey.wasReleasedThisFrame)
        {
            Physics2D.gravity = new Vector3(0, fallSpeed, 0);
        }
    }

    public void Death()
    {
        canControlPlayer = false;
    }

    void DoDash()
    {
        if(dashAction.IsPressed())
        {
            StartCoroutine(Dash(dashDuration));
        }
    }

    IEnumerator Dash(float dashDuration)
    {
        isDashing = true;
        rb.linearVelocity = new Vector3(spearLooker.mousePos.x * dashSpeed, spearLooker.mousePos.y * dashSpeed, 0);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
}