using System.Collections.Generic;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
    public bool shouldMove;  // If the wall should move
    public float speed = 2f; // The speed that the wall moves
    public float wallOffset = -10f; // The amount of offset that the wall has away from the player on reset 
    public Transform startPointTransform; // The starting point of the level
    public Collider2D wallCollider; // The collider for the wall
    private GameObject Player;
    private AudioSource soundFlame;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        soundFlame = GetComponent<AudioSource>();
        soundFlame.Play();
        // startPointTransform.position = this.transform.position;
        // Ensure that the player and start point are properly assigned
        if (Player.transform == null || startPointTransform == null)
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
        if (other.transform == Player.transform)
        {   
            Debug.Log("Player collided with wall!");
            Player.GetComponent<PlayerPrefs>().KillPlayer();
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
            if (Player.transform.position.x - transform.position.x < 10f) 
            {
                soundFlame.volume = soundFlame.volume + 0.05f;
                if (Player.transform.position.x - transform.position.x < 5f) 
                    speed = 1f;
                if (Player.transform.position.x - transform.position.x < 2f) 
                    speed = 0.5f;
            }
            else{ 
                soundFlame.volume = soundFlame.volume - 0.05f;
                if (Player.transform.position.x - transform.position.x > 15f)
                    speed = 5f;
                else if (Player.transform.position.x - transform.position.x > 20f) 
                    speed = 8f;    
                else speed = 2f;  
            }
        }
    }
}
