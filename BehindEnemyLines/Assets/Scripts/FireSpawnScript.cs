using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawnScript : MonoBehaviour
{
    private GameObject wallOfDeath;
    private GameObject[] fireInstances;
    public GameObject[] FireVariations;
    public float spawnOffset = 1f; // The offset at which to spawn the new game object
    public float spawnInterval = 0.3f; // The interval at which to spawn the new game object
    private float lastSpawnPos; // The last position at which the game object was spawned
    
    // Start is called before the first frame update
    void Start()
    {
        wallOfDeath = GameObject.FindGameObjectWithTag("WallOfDeath");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the wall has moved by an amount equal to the spawn interval
        if (wallOfDeath.transform.position.x - lastSpawnPos >= spawnInterval)
        {
            // Spawn a new game object
            Vector3 spawnPos = new Vector3(wallOfDeath.transform.position.x + spawnOffset, wallOfDeath.transform.position.y + -4.2f, wallOfDeath.transform.position.z + 1);
            Instantiate(FireVariations[Random.Range(0, 5)], spawnPos, Quaternion.identity);
            lastSpawnPos += spawnInterval;
        }
    }

    // Reset fire spawning position to current wall position
    public void resetFireSpawn() {
        lastSpawnPos = wallOfDeath.transform.position.x;
    }

    // Delete all fire instances
    public void clearFire() {
        fireInstances = GameObject.FindGameObjectsWithTag("Fire");

         // Destroy each fire game object 
        foreach (GameObject flame in fireInstances)
        {
            Destroy(flame);
        }
    }
}
