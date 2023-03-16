using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletZone : MonoBehaviour
{
    public GameObject Player;
    private bool isInBulletZone;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Is in bullet Zone ");
            Player.GetComponent<PlayerMovement>().isInBulletZone = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<PlayerMovement>().isInBulletZone = false;
        }

    }
}


