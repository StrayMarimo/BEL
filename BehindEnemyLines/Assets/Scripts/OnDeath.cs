using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    private GameObject wallOfDeath;
    private GameObject Player;
    private GameObject startPosition;
    private GameObject[] fires;
    private float wallOffset = -10f;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        startPosition = GameObject.FindGameObjectWithTag("Respawn");
        wallOfDeath = GameObject.FindGameObjectWithTag("WallOfDeath");
    }

    public void OnPlayerDeath() 
    {
        Debug.Log("Player died.");

        // Move player to starting position
        Player.transform.position = startPosition.transform.position;
        // Move camera to starting position
        Camera.main.transform.position = new Vector3(startPosition.transform.position.x, startPosition.transform.position.y, startPosition.transform.position.z - 15);
        // Move wall to starting position with offset
        wallOfDeath.transform.position = new Vector3
            (
                startPosition.transform.position.x + wallOffset, 
                startPosition.transform.position.y, 
                startPosition.transform.position.z + 0.5f
            );

        
            fires = GameObject.FindGameObjectsWithTag("Fire"); // Store all flame currently present in an array and delete them
            // Destroy each fire game object 
            foreach (GameObject flame in fires)
            {
                Destroy(flame);
            }
    }
}
