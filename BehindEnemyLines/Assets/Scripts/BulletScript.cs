// attached to Bullet prefab
// handles bullet movement and collision
using System.Threading.Tasks;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    private Animator animator;
    public float force;
    private GameObject startPoint;
    private GameObject wallOfDeath;
    public float wallOffset = -10f;

    void Start()
    {
        // Get references to the game objects and components
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        startPoint = GameObject.FindGameObjectWithTag("Respawn");
        wallOfDeath = GameObject.FindGameObjectWithTag("WallOfDeath");

        // Set the velocity of the bullet towards the player
        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        // Set the rotation of the bullet to face the player
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Handle the bullet colliding with other game objects
    async private void OnCollisionEnter2D(Collision2D other)
    {
        // If the bullet collides with the player, kill the player
        if (other.gameObject.CompareTag("Player"))
        {
            animator = other.gameObject.GetComponent<Animator>();

            // Trigger the player's death animation
            animator.SetTrigger("Dead");

            // Delay for 500 milliseconds to allow the death animation to play
            await Task.Delay(500);

            // Move player to starting point
            Player.transform.position = startPoint.transform.position;
            // Move camera to starting point
            Camera.main.transform.position = new Vector3(startPoint.transform.position.x, startPoint.transform.position.y, startPoint.transform.position.z - 15);

            // Move wall of death to starting point 
            wallOfDeath.transform.position = new Vector3
            (
                    startPoint.transform.position.x + wallOffset,
                    startPoint.transform.position.y,
                    startPoint.transform.position.z - 5
            );
        }
        // Destroy the bullet
        Destroy(gameObject);
    }
}
