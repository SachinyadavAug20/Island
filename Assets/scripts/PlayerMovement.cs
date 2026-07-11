using UnityEngine;
using UnityEngine.InputSystem; // Required for the new Input System

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 3;
    SpriteRenderer _sr;
    Animator _anim;
    public bool _isPlayerWalking;

    private Vector2 moveInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim =GetComponent<Animator>();
    }

    // Unity automatically calls this because your action is named "Move"
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
