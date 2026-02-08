using UnityEngine;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    Vector2 inputVec;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }
    }

    void Update()
    {
        inputVec = Vector2.zero;

        // Keyboard (WASD)
        if (Keyboard.current != null)
        {
            var k = Keyboard.current;
            float x = (k.dKey.isPressed || k.rightArrowKey.isPressed ? 1f : 0f) - (k.aKey.isPressed || k.leftArrowKey.isPressed ? 1f : 0f);
            float y = (k.wKey.isPressed || k.upArrowKey.isPressed ? 1f : 0f) - (k.sKey.isPressed || k.downArrowKey.isPressed ? 1f : 0f);
            inputVec = new Vector2(x, y);
        }

        // Gamepad fallback
        if (Gamepad.current != null)
        {
            inputVec = Gamepad.current.leftStick.ReadValue();
        }

        if (inputVec.sqrMagnitude > 1f) inputVec = inputVec.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = inputVec * speed;
    }
}