using System.Collections.Generic;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
    public bool shouldMove;  // If the wall should move
    public float speed = 2f; // The speed that the wall moves
    public float wallOffset = -10f; // The amount of offset that the wall has away from the player on reset
    public float spawnOffset; // The offset at which to spawn the new game object
    public float spawnInterval; // The interval at which to spawn the new game object
    private float lastSpawnPos; // The last position at which the game object was spawned
    private GameObject[] fires;
    public GameObject[] fireTypes;
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

        lastSpawnPos = transform.position.x; // Initialize lastSpawnPos to the starting position of the wall
    }

    // On collision with the wall
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == playerTransform)
        {   
            Debug.Log("Player collided with wall!");

            // Move player to starting position
            playerTransform.position = startPointTransform.position;

            // Move camera to starting position
            Camera.main.transform.position = new Vector3(startPointTransform.position.x, startPointTransform.position.y, startPointTransform.position.z - 15);

            // Move wall to starting position with offset
            transform.position = new Vector3
                (
                    startPointTransform.position.x + wallOffset, 
                    startPointTransform.position.y, 
                    startPointTransform.position.z + 0.5f
                );

            // Restart flame spawning process
            lastSpawnPos = transform.position.x; // Initialize lastSpawnPos to the starting position of the wall

            fires = GameObject.FindGameObjectsWithTag("Fire"); // Store all flame currently present in an array and delete them
            // Destroy each fire game object 
            foreach (GameObject flame in fires)
            {
                Destroy(flame);
            }
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

            // Check if the wall has moved by an amount equal to the spawn interval
            if (transform.position.x - lastSpawnPos >= spawnInterval)
            {
                // Spawn a new game object
                // Vector3 spawnPos = transform.position + new Vector3(spawnOffset, transform.position.y, 0);
                Vector3 spawnPos = new Vector3(transform.position.x + spawnOffset, transform.position.y + -4.2f, transform.position.z + 1);
                Instantiate(fireTypes[Random.Range(0, 5)], spawnPos, Quaternion.identity);
                lastSpawnPos += spawnInterval;
            }


        }
    }
}
