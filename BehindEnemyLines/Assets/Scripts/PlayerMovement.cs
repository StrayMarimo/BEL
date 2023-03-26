using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jump;
    public bool isInBulletZone;
    private int jumpableCount = 0;
    private bool canJump {get { return jumpableCount > 0;}}
   
    private Rigidbody2D rb;
    private SpriteRenderer p_SpriteRenderer;
    private Animator p_Animator;
    float time = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        p_Animator = GetComponent<Animator>();
        p_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        // delay user from spamming jump button
        if (time > 0f)  
        {
            time -= Time.deltaTime;
        }
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        // Direction
        if (Move < 0) 
        {
            p_SpriteRenderer.flipX = true;
        } else if (Move > 0)
        {
            p_SpriteRenderer.flipX = false;
        }

        // Animations
        if (rb.velocity.x == 0 || !canJump)
        {
            // Idle
            p_Animator.SetFloat("Speed", 0);
        } else if (!Input.GetKey(KeyCode.LeftShift)) 
        {
            // Walk
            p_Animator.SetFloat("Speed", 0.5f);
            speed = 5;
        } else 
        {
            // Run
            p_Animator.SetFloat("Speed", 1);
            speed = 10;
        }

        
        if(Input.GetButtonDown("Jump") && canJump && time <= 0) 
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            time = 0.5f;
        }
    }



    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpableCount--;
        }

        if (other.gameObject.CompareTag("BulletZone"))
        {
            isInBulletZone = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
           jumpableCount++;
        }

        if (other.gameObject.CompareTag("BulletZone"))
        {
            isInBulletZone = false;
        }
    }

}
