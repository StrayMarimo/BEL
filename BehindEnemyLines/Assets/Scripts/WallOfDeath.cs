using System.Collections.Generic;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
    public bool shouldMove;
    public float speed = 2f;
    public float wallOffset = -10f;
    public Transform playerTransform;
    public Transform startPointTransform;
    public Collider2D wallCollider;

    void Start()
    {
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
                    startPointTransform.position.z
                );
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
