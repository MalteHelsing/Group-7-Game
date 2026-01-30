using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpHeight = 1f;
    [SerializeField] float jumpDistance = 2f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float crouchSpeed = 1f;

    [Header("Music & SFX")]
    [SerializeField] AudioClip one;
    [SerializeField, Range(0, 1)] float oneVolume;

    bool canControlPlayer = true;

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
    }

    void FixedUpdate()
    {
        if (canControlPlayer == true)
        {
            Move();
            Crouch();
            
        }
    }

    void Move()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        rb.linearVelocityX = moveVector.x * moveSpeed;

        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, jumpDistance, layerMask);

        if (jumpAction.IsPressed() && ground.collider)
        {
            rb.linearVelocityY = jumpHeight;
        }
    }

    void Crouch()
    {
        if (crouchAction.IsPressed())
        {
            moveSpeed = crouchSpeed;
            rb.rotation = 90; // temporary
        }
        else
        {
            rb.rotation = 0;
            
            //Here the player will go back to moveSpeed
        }
    }

    public void Death()
    {
        canControlPlayer = false;
    }
}