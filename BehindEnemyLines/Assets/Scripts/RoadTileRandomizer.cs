using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTileRandomizer : MonoBehaviour
{
    public string sprite;
    private SpriteRenderer roadSpriteRenderer;
    private Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {
        spriteArray = Resources.LoadAll<Sprite>(sprite);
        roadSpriteRenderer = GetComponent<SpriteRenderer>();
        roadSpriteRenderer.sprite = spriteArray[Random.Range(0, 8)];
        gameObject.AddComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
