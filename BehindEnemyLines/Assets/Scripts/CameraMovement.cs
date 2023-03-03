using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 newPosition;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        // addCameraCollision();
    }

    // Update is called once per frame
    void Update()
    {
        newPosition.x = transform.position.x + Time.deltaTime * speed;
        transform.position = newPosition;

    }

    // void addCameraCollision() {
    //     Camera cam = Camera.main;

    //     var edgeCollider =  gameObject.GetComponent<EdgeCollider2D>() == null
    //         ? gameObject.AddComponent<EdgeCollider2D>()
    //         : gameObject.GetComponent<EdgeCollider2D>();
        
    //     var leftBottom = (Vector2) cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
    //     var leftTop = (Vector2) cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
    //     var rightTop = (Vector2) cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane)); 
    //     var rightBottom = (Vector2) cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

    //     var edgePoints = new[] {leftBottom, leftTop, rightTop, rightBottom, leftBottom};

    //     edgeCollider.points = edgePoints;
    // }
}
