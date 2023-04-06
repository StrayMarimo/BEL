using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallOfDeath : MonoBehaviour
{
    public float speed = .005f;
    // public GameObject Player;
    // public GameObject startPoint;

    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    // void Start()
    // {
    //     startPoint = transform.position;
    // }

    // Update is called once per frame
    void Update()
    {
        // if (Player.transform.position.x <= transform.position.x) {
        //     Player.transform.position = startPoint.transform.position;
        //     Camera.main.transform.position = startPoint.transform.position;
        //     transform.position = startPoint;
        // }

        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CameraMovement : MonoBehaviour
// {
//     /* Old Camera movement */
    
//     public float speed = 2f;
//     private Vector3 newPosition;
//     private float objectWidth;
//     public GameObject Player;
//     public GameObject startPoint;
    

//     // Start is called before the first frame update
//     void Start()
//     {
//         newPosition = transform.position;
//         objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         newPosition.x = transform.position.x + Time.deltaTime * speed;
//         transform.position = newPosition;

//         var lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
//         var upperRight =
//             Camera
//                 .main
//                 .ScreenToWorldPoint(new Vector3(Screen.width,
//                     Screen.height,
//                     0));

//         if (Player.transform.position.x < lowerLeft.x || Player.transform.position.y < lowerLeft.y)
//         {
//             Player.transform.position = startPoint.transform.position;
//             Camera.main.transform.position = startPoint.transform.position;
//         }
//         else if (Player.transform.position.x > upperRight.x)
//         {
//             Player.transform.position =
//                 new Vector3(upperRight.x,
//                     Player.transform.position.y,
//                     Player.transform.position.z);
//         }

    
//         transform.position =
//             new Vector3(Mathf
//                     .Clamp(transform.position.x, lowerLeft.x + objectWidth, upperRight.x - objectWidth),
//                 transform.position.y,
//                 transform.position.z);
//     }

// }
