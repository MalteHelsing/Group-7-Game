using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float crouchSpeed = 1f;
    [SerializeField] float jumpHeight = 1f;
    [SerializeField] float jumpDistance = 2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float coyoteTime = 0.2f;

    [Header("Music & SFX")]
    [SerializeField] AudioClip one;
    [SerializeField, Range(0, 1)] float oneVolume;

    bool canControlPlayer = true;
    private float currentSpeed;
    public float groundRadius = 0.2f;
    float coyoteTimeCounter;

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

        //jumpAction.performed += _ => JumpActionStarted();

        currentSpeed = moveSpeed;
    }

    void Update()
    {
        //CoyoteTime();

        if (canControlPlayer == true)
        {
            Move();
            Crouch();
        }
    }

    void Move()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        rb.linearVelocityX = moveVector.x * currentSpeed;

        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, jumpDistance, groundLayer);

        if (jumpAction.IsPressed() && ground.collider)
        {
            rb.linearVelocityY = jumpHeight;
            coyoteTimeCounter = 0f;
        }
    }

    void Crouch()
    {
        if (crouchAction.IsPressed())
        {
            currentSpeed = crouchSpeed;
            rb.rotation = 90; // temporary, remove later
        }
        else
        {
            currentSpeed = moveSpeed;
            rb.rotation = 0; // temporary, remove later
        }
    }
    public void Death()
    {
        canControlPlayer = false;
    }
}