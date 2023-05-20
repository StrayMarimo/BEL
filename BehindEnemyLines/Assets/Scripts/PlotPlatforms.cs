// attached to Generate Platforms Game Object
// instantiates a specified platform at a specified position
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlotPlatforms : MonoBehaviour
{
    public float XPos = 8.884f;
    public float YPos = 5f;
    public float platformSize = 17.768f;
    private int platforms = 3;
    public GameObject platform;
    public GameObject baseEnd;
    private Vector2 position;
    private int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        level = MainMenu.level;
        platforms = platforms * level;
        // Set the initial position of the platform
        position.x = XPos;
        position.y = YPos;
        for (int i = 0; i < platforms; i++)
        {
            // Instantiate a platform at the current position
            var newPlatform = Instantiate(platform, position, transform.rotation);
            newPlatform.transform.parent = transform;
            // Move the position to the right by the size of the platform
            position.x += platformSize;
        }

        var endPlatform = Instantiate(baseEnd, position, transform.rotation);
        endPlatform.transform.parent = transform;
    }

}
