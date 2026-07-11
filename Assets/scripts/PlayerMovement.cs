using UnityEngine;
using UnityEngine.InputSystem; // Required for the new Input System

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 3;
    SpriteRenderer _sr;

    private Vector2 moveInput;

    void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Unity automatically calls this because your action is named "Move"
    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate() {
        _rb.linearVelocity = new Vector2(moveInput.x * speed, _rb.linearVelocity.y);
        if (_rb.linearVelocity.x > 0) _sr.flipX = false;
        else if (_rb.linearVelocity.x < 0) _sr.flipX = true;
    }
}
