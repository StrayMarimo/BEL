// attached to BulletSpawn
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    private GameObject Player;
    public Transform bulletPos;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        // Get references to player
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the timer by the time elapsed since the last frame
        timer += Time.deltaTime;

        // If the player is in the bullet zone and the timer has reached 2 seconds
        if (Player.GetComponent<PlayerPrefs>().isInBulletZone && timer > 2 )
        {
            // Reset the timer
            timer = 0;

            // Call method to shoot bullet
            shoot();
        }
    }

    // handles bullet shooting from spawn point
    void shoot() {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

}


