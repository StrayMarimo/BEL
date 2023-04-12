// Attached to Road prefab
// generates a random road
using UnityEngine;

public class GenerateRoad : MonoBehaviour
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
        // Get the SpriteRenderer component of the road tile prefab
        tileSpriteRenderer = roadTile.GetComponent<SpriteRenderer>();

        // Initialize the y-coordinate of the new position
        newPosition.y = transform.position.y;

        for (int i = 0; i < rows; i++) {
            // Initialize the x-coordinate of the new position
            newPosition.x = transform.position.x;
            for (int j = 0; j < columns; j++) {
                // Instantiate a new road tile at the current position
                var newRoad = Instantiate(roadTile, newPosition, transform.rotation);

                // Move the x-coordinate of the new position to the right by the width of the tile
                newPosition.x += tileSpriteRenderer.bounds.size.x;

                // Set the parent of the new road tile to be the road object
                newRoad.transform.parent = transform;

                // If this is a wall and we're not on the top row, remove the "Untagged" tag from the road tile
                // so that the player can only jump on the top of a wall
                if (isWall && i != rows - 1) {
                    newRoad.tag = "Untagged";
                }
            }
            // Move the y-coordinate of the new position up by the height of the tile
            newPosition.y += tileSpriteRenderer.bounds.size.y;
        }
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
