using System.Collections.Generic;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
    public OnDeath OnDeath; // on Player death script
    public FireSpawnScript fireSpawnScript; // Fire spawner script

    public bool shouldMove;  // If the wall should move
    public float speed = 2f; // The speed that the wall moves
    public float wallOffset = -10f; // The amount of offset that the wall has away from the player on reset 
    public Transform playerTransform; // Player
    public Transform startPointTransform; // The starting point of the level
    public Collider2D wallCollider; // The collider for the wall

    void Start()
    {
        // startPointTransform.position = this.transform.position;
        // Ensure that the player and start point are properly assigned
        if (playerTransform == null || startPointTransform == null)
        {
            Debug.LogError("WallOfDeath script: playerTransform or startPointTransform is not assigned!");
        }

        // Ensure that the wall collider is assigned and is set to trigger mode
        if (wallCollider == null)
        {
            Debug.LogError("WallOfDeath script: wallCollider is not assigned!");
        }
        else if (!wallCollider.isTrigger)
        {
            wallCollider.isTrigger = true;
        }

        fireSpawnScript.resetFireSpawn(); // Initialize lastSpawnPos to the starting position of the wall
    }

    // On collision with the wall
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == playerTransform)
        {   
            Debug.Log("Player collided with wall!");

            // Reset player and camera position
            OnDeath.OnPlayerDeath();

            // Restart flame spawning process
            fireSpawnScript.resetFireSpawn();
            fireSpawnScript.clearFire();
        }
    }

    void FixedUpdate()
    {
        if (shouldMove) {
            transform.position = new Vector3
                (
                    transform.position.x + (Time.fixedDeltaTime * speed), 
                    transform.position.y, 
                    transform.position.z
                );
        }
    }
}
