using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck; 
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;

    private Animator animator;
    private string currentState;
    const string idle = "Rogue_idle_01";
    const string run = "Rogue_run_01";
    

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;

    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Start() {
        jumpCount = maxJumpCount;
        animator = GetComponent<Animator>();
    }
     
    void Update()
    {
        InputProcess();
        changeAnimations();
        Animate();
    }

    private void FixedUpdate()
    {
        CheckGround();
        Move();
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position,new Vector2(1f,0.1f),0f,groundObjects);
        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping) 
        {
            rb.velocity = new Vector2(0f,jumpForce);
            jumpCount--;
        }
        isJumping = false;  
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
            flipCharacter();
        else if (moveDirection < 0 && facingRight)
            flipCharacter();
    }

    private void InputProcess()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && jumpCount > 0) 
        {
            isJumping  = true; 
        }
    }

    private void flipCharacter() 
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }

    void changeAnimations() 
    {
        if(moveDirection != 0)
            changeAnimationState(run);
        else
            changeAnimationState(idle);
    }

    void changeAnimationState(string newState) 
    {
        if(currentState == newState)
            return;
        animator.Play(newState);
        currentState = newState;
    }



    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(groundCheck.position,new Vector2(1f,0.1f));
    }

}
