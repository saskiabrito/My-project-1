using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private Animator animator;
    private bool isGrounded;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        moveInput =  Input.GetAxisRaw("Horizontal");

        if(moveInput > 0)
            transform.localScale = new Vector3(1,1,1);
        else if (moveInput <0)
        transform.localScale = new Vector3(-1,1,1);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.1f,groundLayer);
    
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x , jumpForce);

        }
        animator.SetBool("isJumping", !isGrounded);
    
    
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput *speed, rb.linearVelocity.y);
    }
    }
