// attached to a Road prefab
// generates a random road sprite
using UnityEngine;

public class RoadTileRandomizer : MonoBehaviour
{
    public string sprite;
    private SpriteRenderer roadSpriteRenderer;
    private Sprite[] spriteArray;
    // Start is called before the first frame update
    void Start()
    {
        // Load an array of sprites from the Resources folder with the given sprite name
        spriteArray = Resources.LoadAll<Sprite>(sprite);

        // Get the SpriteRenderer component of the current game object
        roadSpriteRenderer = GetComponent<SpriteRenderer>();

        // Set the sprite of the SpriteRenderer to a random sprite from the loaded array
        roadSpriteRenderer.sprite = spriteArray[Random.Range(0, 8)];

        // Add a BoxCollider2D component to the current game object
        var boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.usedByComposite = true;

        
    }
}
