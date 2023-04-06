using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /* New Camera movement */

    public float smoothTime = 0.3f;
    public float verticalOffset = 1.5f;
    private Vector3 velocity = Vector3.zero;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
