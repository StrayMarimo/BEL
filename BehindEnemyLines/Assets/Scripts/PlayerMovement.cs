// attached to Player
// handles player movement and transition animations
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jump;
    public bool isInBulletZone;
    private int jumpableCount = 0;  // counter to keep track of how many jumpable surfaces are below the player
    private bool canJump {get { return jumpableCount > 0;}} // a property indicating whether the player can jump
    private int score = 0;
    private float distance = 0;
    private Rigidbody2D rb;
    private SpriteRenderer p_SpriteRenderer;
    private Animator p_Animator;
    private GameObject ScoreCanvas;
    float time = 0.5f;

    [SerializeField]
    Text Score;
    public int totalScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Get references to the game objects and components
        rb = GetComponent<Rigidbody2D>();
        p_Animator = GetComponent<Animator>();
        p_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ScoreCanvas = GameObject.FindGameObjectWithTag("Score");
        Score = ScoreCanvas.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // delay user from spamming jump button
        if (time > 0f)  
        {
            time -= Time.deltaTime;  // reduces the delay timer by the time elapsed since the last frame
        }
        Move = Input.GetAxis("Horizontal");  // gets the player's horizontal input
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);  // sets the player's velocity based on the horizontal input
        
        // flips player facing to direction it is moving
        if (Move < 0) 
        {
            p_SpriteRenderer.flipX = true;
        } else if (Move > 0)
        {
            p_SpriteRenderer.flipX = false;
            if (transform.position.x > distance){
                distance = transform.position.x;
                score += 1;
            }
               
        }
        totalScore = score / 50;
        Score.text = "Score: " + totalScore.ToString();

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
            // Jump
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            time = 0.5f;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpableCount++;
        }

        if (other.gameObject.CompareTag("BulletZone"))
        {
            // Player entered the bullet xone
            isInBulletZone = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpableCount--; // reduces the jumpable count if the player exits a jumpable surface
        }

        if (other.gameObject.CompareTag("BulletZone"))
        {
            // Player exited the bullet zone
            isInBulletZone = false;
        }
    }



}
