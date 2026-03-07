using UnityEngine;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    [Header("Sprite Direction")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool use4Directions = true; // utile pour Animator
    [SerializeField] private Vector2 facingDirection = Vector2.down; // direction par defaut

    private Vector2 inputVec;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D manquant sur le player! Ajoutez-le dans l'inspecteur.");
            enabled = false;
            return;
        }

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        rb.gravityScale = 0f;
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        inputVec = Vector2.zero;

        // Keyboard (WASD + fleches)
        if (Keyboard.current != null)
        {
            var k = Keyboard.current;
            float x = (k.dKey.isPressed || k.rightArrowKey.isPressed ? 1f : 0f) - (k.aKey.isPressed || k.leftArrowKey.isPressed ? 1f : 0f);
            float y = (k.wKey.isPressed || k.upArrowKey.isPressed ? 1f : 0f) - (k.sKey.isPressed || k.downArrowKey.isPressed ? 1f : 0f);
            inputVec = new Vector2(x, y);
        }

        // Gamepad fallback
        if (Gamepad.current != null && inputVec == Vector2.zero)
        {
            inputVec = Gamepad.current.leftStick.ReadValue();
        }

        if (inputVec.sqrMagnitude > 1f)
        {
            inputVec = inputVec.normalized;
        }

        UpdateFacingDirection(inputVec);
        ApplySpriteFacing();
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = inputVec * speed;
        }
    }

    private void UpdateFacingDirection(Vector2 move)
    {
        if (move.sqrMagnitude < 0.0001f) return;

        if (use4Directions)
        {
            // Force 4 directions (comme beaucoup de jeux top-down type Stardew)
            if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
            {
                facingDirection = new Vector2(Mathf.Sign(move.x), 0f);
            }
            else
            {
                facingDirection = new Vector2(0f, Mathf.Sign(move.y));
            }
        }
        else
        {
            // Direction libre (8 directions / analogique)
            facingDirection = move.normalized;
        }
    }

    private void ApplySpriteFacing()
    {
        if (spriteRenderer == null) return;

        // Flip horizontal pour gauche/droite
        if (Mathf.Abs(facingDirection.x) > 0.01f)
        {
            spriteRenderer.flipX = facingDirection.x < 0f;
        }

        // Si tu as un Animator, tu peux y pousser ces valeurs:
        // animator.SetFloat("MoveX", facingDirection.x);
        // animator.SetFloat("MoveY", facingDirection.y);
    }

    public Vector2 GetFacingDirection()
    {
        return facingDirection;
    }
}