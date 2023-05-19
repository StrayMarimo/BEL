// attached to BulletSpawn
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    private GameObject Player;
    public Transform bulletPos;
    private AudioSource shootSfx;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        // Get references to player
        Player = GameObject.FindGameObjectWithTag("Player");
        shootSfx = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the timer by the time elapsed since the last frame
        timer += Time.deltaTime;
        Debug.Log(Player.GetComponent<PlayerPrefs>().isInBulletZone);
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
        shootSfx.Play();
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

}


