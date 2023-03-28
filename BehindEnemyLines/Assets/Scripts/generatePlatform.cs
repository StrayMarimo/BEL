using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlatform : MonoBehaviour
{

    private GameObject randomPlatform;
    private GameObject[] platforms;
    // Start is called before the first frame update
    void Start()
    {
        platforms = Resources.LoadAll<GameObject>("platforms");
        randomPlatform = platforms[Random.Range(0, platforms.Length)];

        var newPlatform = Instantiate(randomPlatform, transform.position, transform.rotation);
        newPlatform.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
