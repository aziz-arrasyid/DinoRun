using UnityEngine;

public class Movement : MonoBehaviour
{
    //Components Global
    InputSystem inputSystem;

    //Components In
    private Rigidbody2D rb;
    private Animator animator;

    //variable
    private readonly float jumpForce = 8f;
    private bool isGround;
    private Vector2 position = new Vector2(-7.49f, -3.47f);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        inputSystem = new InputSystem();
        inputSystem.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable() => inputSystem.Enable();

    private void OnDisable() => inputSystem.Disable();

    private void Jump()
    {
        if (isGround && !GameManager.Instance.GetGameOver())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGround = false;
            animator.SetBool("IsJump", !isGround);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            animator.SetBool("IsJump", !isGround);
        }
    }

    public void ResetPosition()
    {
        rb.position = position;
    }
}
