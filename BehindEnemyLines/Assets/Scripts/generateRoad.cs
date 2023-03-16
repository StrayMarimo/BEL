using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateRoad : MonoBehaviour
{
    public int columns;
    public int rows = 1;
    public bool isWall = false;
    public GameObject roadTile;
    private SpriteRenderer tileSpriteRenderer;
    private Vector2 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        
        tileSpriteRenderer = roadTile.GetComponent<SpriteRenderer>();
        
        newPosition.y = transform.position.y;

        for (int i = 0; i < rows; i++) {
            newPosition.x = transform.position.x;
            for (int j = 0; j < columns; j++) {
                var newRoad = Instantiate(roadTile, newPosition, transform.rotation);
                newPosition.x += tileSpriteRenderer.bounds.size.x;
                newRoad.transform.parent = transform;
                if (isWall && i != rows - 1) {
                    newRoad.tag = "Untagged";
                }
            }
            newPosition.y += tileSpriteRenderer.bounds.size.y;
        }
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
