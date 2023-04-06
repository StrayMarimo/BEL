using System.Collections.Generic;
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
        Vector3 targetPosition = new Vector3(Target.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
