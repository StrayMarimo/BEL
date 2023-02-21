using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jump;
    public bool isJumping;
    private Rigidbody2D rb;
    Animator p_Animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        p_Animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            p_Animator.ResetTrigger("Idle");
            p_Animator.SetTrigger("Walk");
        }

        

        if(Input.GetButtonDown("Jump") && isJumping == false) 
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
