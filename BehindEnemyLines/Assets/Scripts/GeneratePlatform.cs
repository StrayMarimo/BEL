// Attached to Platform prefab
// generates a random platform
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{

    private GameObject randomPlatform;
    private GameObject[] platforms;
    // Start is called before the first frame update
    void Start()
    {
        // Load all the platform prefabs from the Resources/platforms folder
        platforms = Resources.LoadAll<GameObject>("platforms");

        // Select a random platform prefab from the loaded platforms
        randomPlatform = platforms[Random.Range(0, platforms.Length)];

        // Instantiate a new platform at the spawner's position and rotation
        var newPlatform = Instantiate(randomPlatform, transform.position, transform.rotation);

        // Set the new platform's parent to be the spawner object, so that it moves along with it
        newPlatform.transform.parent = transform;
    }

}
