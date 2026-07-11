using UnityEngine;
using UnityEngine.InputSystem; // Required for the new Input System

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 3;
    public float jumpForce = 7f;
    SpriteRenderer _sr;
    Animator _anim;
    public bool _isPlayerWalking;

    [Header("Ground Detection")]
    public Transform groundCheck; 
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private Vector2 moveInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim =GetComponent<Animator>();
    }

    void Update()
    {
        if (groundCheck != null) {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        _anim.SetBool("isJumping", !isGrounded);
    }
    void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        // move
        _rb.linearVelocity = new Vector2(moveInput.x * speed, _rb.linearVelocity.y);
        // flip
        if (_rb.linearVelocity.x > 0) _sr.flipX = false;
        else if (_rb.linearVelocity.x < 0) _sr.flipX = true;
        // animator
        _isPlayerWalking = Mathf.Abs(moveInput.x) > 0;
        _anim.SetBool("isWalking", _isPlayerWalking);
    }
}
