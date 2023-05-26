using UnityEngine;

public class IdleObjectMovement : MonoBehaviour
{
    public Vector3 movementVector = new Vector3(0, 0, 0.1f); // the amount to move the object by
    public float loopTime = 2f; // the time it takes for one loop

    private Vector3 startingPosition; // the starting position of the object
    private float timeElapsed = 0f; // the time elapsed since the start of the loop

    void Start()
    {
        startingPosition = transform.position; // store the starting position of the object
    }

    void Update()
    {
        // calculate the new position of the object based on the movement vector and time elapsed
        Vector3 newPosition = startingPosition + movementVector * Mathf.Sin(2 * Mathf.PI * timeElapsed / loopTime);

        // update the position of the object
        transform.position = newPosition;

        // update the time elapsed
        timeElapsed += Time.deltaTime;

        // reset the time elapsed when one loop is completed
        if (timeElapsed > loopTime)
        {
            timeElapsed = 0f;
        }
    }
}
