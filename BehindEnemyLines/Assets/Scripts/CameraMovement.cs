using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 newPosition;
    public GameObject Player;
    public GameObject startPoint;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition.x = transform.position.x + Time.deltaTime * speed;
        transform.position = newPosition;

      
        var lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        var upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (Player.transform.position.x < lowerLeft.x || 
            Player.transform.position.x > upperRight.x )
        {
            Player.transform.position = startPoint.transform.position;
            Camera.main.transform.position = startPoint.transform.position;
        }

    }
}
