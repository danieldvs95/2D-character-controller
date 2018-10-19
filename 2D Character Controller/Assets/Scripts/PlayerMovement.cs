using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    bool isAiming;

    bool isAimingUp;

    bool isJumping;

    float horizontalInput = 0f;

    Animator animator;

    public CharacterController2D controller;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        controller.Move(horizontalInput);
    }

	void Update()
	{
        UpdatePlayerInput();

        UpdateAnimations();

	}

    void UpdatePlayerInput()
    {
        bool jumpInput = Input.GetButtonDown("Jump");
        bool aimKeyDown = Input.GetButtonDown("Aim");
        bool aimKeyUp = Input.GetButtonUp("Aim");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        isJumping = !controller.IsGrounded();

        if (aimKeyDown)
        {
            isAiming = true;
        }

        if (aimKeyUp)
        {
            isAiming = false;
        }

        if (isAiming && verticalInput > 0)
        {
            isAimingUp = true;
        }

        if (!isAiming || verticalInput <= 0)
        {
            isAimingUp = false;
        }

        if (jumpInput && !isJumping && !isAiming)
        {
            controller.Jump();
        }
    }

    void UpdateAnimations ()
    {
        // Update animation based on player's input
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if ((isAimingUp || isAiming) && !isJumping)
        {
            animator.SetFloat("Speed", 0);
        }

        animator.SetBool("isJumping", isJumping);

        animator.SetBool("isAiming", isAiming);

        animator.SetBool("isAimingUp", isAimingUp);
    }

    public bool IsAimingUp()
    {
        return isAimingUp;
    }

    public bool IsAiming()
    {
        return isAiming;
    }

    public bool IsJumping()
    {
        return isJumping;
    }

    public void SetIsJumping(bool isJumping)
    {
        this.isJumping = isJumping;
    }
}
