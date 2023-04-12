// attached to Bullet Zone Game Object
// Toggles isInBulletZone variable of playermovement script
using UnityEngine;

public class BulletZone : MonoBehaviour
{
    private GameObject Player;
    private bool isInBulletZone;


    // Start is called before the first frame update
    void Start()
    {
        // Get references to player
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player collided with the bullet zone
        if (other.gameObject.CompareTag("Player"))
        {
            // Set the player's isInBulletZone flag to true
            Player.GetComponent<PlayerMovement>().isInBulletZone = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        // If player exits the bullet zone
        if (other.gameObject.CompareTag("Player"))
        {
            // Set the player's isInBulletZone flag to false
            Player.GetComponent<PlayerMovement>().isInBulletZone = false;
        }

    }
}


