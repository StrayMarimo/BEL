// attached to Generate Platforms Game Object
// instantiates a specified platform at a specified position
using UnityEngine;

public class PlotPlatforms : MonoBehaviour
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
        // Set the initial position of the platform
        position.x = XPos;
        position.y = YPos;
        for (int i = 0; i < platforms; i++)
        {
            // Instantiate a platform at the current position
            Instantiate(platform, position, transform.rotation);

            // Move the position to the right by the size of the platform
            position.x += platformSize;
        }
    }

}
