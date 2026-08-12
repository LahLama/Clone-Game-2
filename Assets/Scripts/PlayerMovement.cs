using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 12f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask breakLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;
    private bool jumpQueued;
    private bool hasJumped;
    private int groundContacts;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        moveInput = 0f;
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) moveInput = -1f;
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) moveInput = 1f;

        isGrounded = groundContacts > 0;

        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded && !hasJumped)
        {
            jumpQueued = true;
            hasJumped = true;
        }

        if (isGrounded && rb.linearVelocity.y <= 0.01f)
        {
            hasJumped = false;
        }

        if (moveInput != 0f)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        // Debug.Log($"moveInput: {moveInput}, timeScale: {Time.timeScale}, enabled: {enabled}, A pressed: {keyboard.aKey.isPressed}, D pressed: {keyboard.dKey.isPressed}");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (jumpQueued)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpQueued = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            groundContacts++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
            groundContacts = Mathf.Max(0, groundContacts - 1);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}