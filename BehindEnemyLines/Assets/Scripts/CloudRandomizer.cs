// Attached to a cloud prefab
// generates a random object
using UnityEngine;

public class CloudRandomizer : MonoBehaviour
{
    private SpriteRenderer cloudSpriteRenderer;
    private Sprite[] clouds;
    // Start is called before the first frame update
    void Start()
    {
        // Load all the cloud sprites from the Resources/clouds folder
        clouds = Resources.LoadAll<Sprite>("clouds");
        // Select a random platform prefab from the loaded platforms
        cloudSpriteRenderer = GetComponent<SpriteRenderer>();
        cloudSpriteRenderer.sprite = clouds[Random.Range(0, clouds.Length)];
    }

}
