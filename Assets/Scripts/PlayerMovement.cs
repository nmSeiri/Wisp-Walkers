using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 5f;
    public float jumpForce = 12f;

    private bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    private float groundCheckRadius = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    void Update()
    {
        // horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Checks if the character is touching grass (always false for you) >:)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump 
        // TO DO - Stop jump when spacebar isn't pressed anymore
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }
    
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
