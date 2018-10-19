using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    // The top speed on wich the player is going to move
    public float topSpeed = 9f;

    public float jumpForce = 500f;

    // For determining which way the player is currently facing.
    bool orientation = true;

    // The position for checking if the player is grounded
    public Transform groundCheck;

    // Radius of the overlap circle to determine if grounded
    const float groundDistance = 1.6f;

    // Select the layers that collide with the player as "ground"
    public LayerMask groundLayer;

    // The RigidBody2D component attached to the player object
    Rigidbody2D rb2d;

    public PlayerMovement player;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(float input)
    {
        // Add velocity to the rigidbody so the character moves according to (inputDirection * topSpeed)
        if ((player.IsAimingUp() || player.IsAiming()) && !player.IsJumping())
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(input * topSpeed, rb2d.velocity.y);
        }

        // Check if the character change direction of movement
        if ((input > 0 && !orientation) || (input < 0 && orientation))
        {
            Flip();
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        orientation = !orientation;

        // Set 180 y-axis in the rotation of the player.
        transform.Rotate(0f, 180f, 0f);
    }

    public bool IsGrounded()
    {
        Vector2 direction = Vector2.down;
        Debug.DrawRay(groundCheck.position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, direction, groundDistance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    public void Jump()
    {
        rb2d.AddForce(new Vector2(0, jumpForce));
    }
}
