using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jump;
    public bool isJumping;
    private bool isWalking, isRunning;
    private Rigidbody2D rb;
    private SpriteRenderer p_SpriteRenderer;
    Animator p_Animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        p_Animator = gameObject.GetComponent<Animator>();
        p_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && !isJumping) 
        {
            if (Move < 0) {
                p_SpriteRenderer.flipX = true;
            } else {
                p_SpriteRenderer.flipX = false;
            }

            p_Animator.ResetTrigger("Idle");
            if (isWalking) 
            {
                p_Animator.SetTrigger("Run");
                isRunning = true;
            } else 
            {
                p_Animator.SetTrigger("Walk");
                isWalking = true;
                isRunning = false;
            }   
           
        } else 
        {
            if (isRunning)
                p_Animator.ResetTrigger("Run");
            else
                p_Animator.ResetTrigger("Walk");
            
            p_Animator.SetTrigger("Idle");
            isWalking = false;
        }

        if(Input.GetButtonDown("Jump") && !isJumping) 
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
