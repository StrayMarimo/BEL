using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotPlatforms : MonoBehaviour
{
    public float XPos = 8.884f;
    public float YPos = 5f;
    public float platformSize = 17.768f;
    public int platforms = 5;
    public GameObject platform;
    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position.x = XPos;
        position.y = YPos;
        for (int i = 0; i < platforms; i++)
        {
            Instantiate(platform, position, transform.rotation);
            position.x += platformSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
