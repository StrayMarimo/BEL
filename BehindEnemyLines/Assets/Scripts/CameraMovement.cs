// attached to main camera
// handles camera movement
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /* New Camera movement */

    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    public GameObject Target;
    private GameObject Player;
    private GameObject startPoint;
    private GameObject wallOfDeath;
    public float wallOffset = -10f;

    void Start()
    {
        // Get references to the game objects and components
       
        Player = GameObject.FindGameObjectWithTag("Player");
        startPoint = GameObject.FindGameObjectWithTag("Respawn");
        wallOfDeath = GameObject.FindGameObjectWithTag("WallOfDeath");
    }

    // Update is called once per frame
    void Update()
    {

        var lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        if (Player.transform.position.x < lowerLeft.x || Player.transform.position.y < lowerLeft.y)
        {
            // Move player to starting point
            Player.transform.position = startPoint.transform.position;
            // Move camera to starting point
            Camera.main.transform.position = new Vector3(startPoint.transform.position.x, startPoint.transform.position.y, startPoint.transform.position.z - 15);
            // Move wall of death to starting point 
            wallOfDeath.transform.position = new Vector3
            (
                    startPoint.transform.position.x + wallOffset,
                    startPoint.transform.position.y,
                    startPoint.transform.position.z + 0.5f
            );
        }

        // Set the target position as the position of the Target game object, but maintain the same Y and Z positions as the bullet
        Vector3 targetPosition = new Vector3(Target.transform.position.x, transform.position.y, transform.position.z);

        // Smoothly move the bullet towards the target position using SmoothDamp
        // The velocity and smoothTime values are passed by reference to the method and used internally to calculate the movement
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
