using UnityEngine;
using UnityEngine.InputSystem; 

public class CharacterSwitcher : MonoBehaviour
{
    [Header("Player References")]
    public PlayerMovement player1;
    public PlayerMovement player2;
    
    private bool isPlayer1Active = true;

    void Start()
    {
        UpdateActivePlayer();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.tabKey.wasPressedThisFrame)
        {
            isPlayer1Active = !isPlayer1Active;
            UpdateActivePlayer();
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        player1.ReceiveMoveInput(input);
        player2.ReceiveMoveInput(input);
    }

    void OnJump(InputValue value)
    {
        bool isPressed = value.isPressed;
        player1.ReceiveJumpInput(isPressed);
        player2.ReceiveJumpInput(isPressed);
    }

    void UpdateActivePlayer()
    {
        player1.isActivePlayer = isPlayer1Active;
        player2.isActivePlayer = !isPlayer1Active;

        player1.GetComponent<SpriteRenderer>().color = isPlayer1Active ? Color.white : new Color(0.5f, 0.5f, 0.5f, 1f);
        player2.GetComponent<SpriteRenderer>().color = !isPlayer1Active ? Color.white : new Color(0.5f, 0.5f, 0.5f, 1f);
    }
}
