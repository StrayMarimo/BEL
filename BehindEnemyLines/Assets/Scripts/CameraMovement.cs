// attached to main camera
// handles camera movement
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /* New Camera movement */

    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    public GameObject Target;

    // Update is called once per frame
    void Update()
    {
        // Set the target position as the position of the Target game object, but maintain the same Y and Z positions as the bullet
        Vector3 targetPosition = new Vector3(Target.transform.position.x, transform.position.y, transform.position.z);
        
        // Smoothly move the bullet towards the target position using SmoothDamp
        // The velocity and smoothTime values are passed by reference to the method and used internally to calculate the movement
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
