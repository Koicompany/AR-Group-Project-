
using UnityEngine;

public class MultiplayerMovement : MonoBehaviour
{
    [Header("Characters")]
    public Transform characterWASD;
    public Transform characterArrows;

    [Header("Ground Checks")]
    public Transform groundCheckWASD;
    public Transform groundCheckArrows;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;  // BOTH characters use this

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rbWASD;
    private Rigidbody2D rbArrows;

    private void Start()
    {
        rbWASD = characterWASD.GetComponent<Rigidbody2D>();
        rbArrows = characterArrows.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // ---------- WASD CHARACTER ----------
        float inputX_W = Input.GetAxisRaw("Horizontal");
        bool groundedW = Physics2D.OverlapCircle(groundCheckWASD.position, groundCheckRadius, groundLayer);

        rbWASD.linearVelocity = new Vector2(inputX_W * moveSpeed, rbWASD.linearVelocity.y);

        if (groundedW && Input.GetKeyDown(KeyCode.W))
            rbWASD.linearVelocity = new Vector2(rbWASD.linearVelocity.x, jumpForce);


        // ---------- ARROW-KEY CHARACTER ----------
        float inputX_A = Input.GetAxisRaw("Horizontal_Arrows");
        bool groundedA = Physics2D.OverlapCircle(groundCheckArrows.position, groundCheckRadius, groundLayer);

        rbArrows.linearVelocity = new Vector2(inputX_A * moveSpeed, rbArrows.linearVelocity.y);

        if (groundedA && Input.GetKeyDown(KeyCode.UpArrow))
            rbArrows.linearVelocity = new Vector2(rbArrows.linearVelocity.x, jumpForce);
    }


    // ---------------- GIZMOS (for visualization only) ----------------
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        if (groundCheckWASD != null)
            Gizmos.DrawWireSphere(groundCheckWASD.position, groundCheckRadius);

        if (groundCheckArrows != null)
            Gizmos.DrawWireSphere(groundCheckArrows.position, groundCheckRadius);
    }
}


