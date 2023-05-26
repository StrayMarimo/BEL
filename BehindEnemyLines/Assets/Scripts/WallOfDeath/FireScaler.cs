using UnityEngine;

public class FireScaler : MonoBehaviour
{
    public bool isScaling = true; // Whether to enable scaling
    public float scalingSpeed = 1.0f; // The speed at which to scale the sprite
    public float targetSize = 10.0f; // The target size to scale the sprite to
    public float startSize = 0.0f; // The starting size of the sprite
    public float expiry = 15f;
    public GameObject thisFire;
    private Transform transformComponent; // Reference to the Transform component

    void Start()
    {
        // Get a reference to the Transform component
        transformComponent = GetComponent<Transform>();

        // Set the starting scale of the transformComponent
        transformComponent.localScale = new Vector3(startSize, startSize, 1f);

        // Destroy fire game object after a certain duration
        Destroy(thisFire, expiry);
    }

    void Update()
    {
        // If scaling is enabled, scale the sprite towards the target size
        if (isScaling)
        {
            float newSize = Mathf.MoveTowards(transformComponent.localScale.x, targetSize, scalingSpeed * Time.deltaTime);
            transformComponent.localScale = new Vector3(newSize, newSize, 1f);
            // Debug.Log("Current size: " + transformComponent.localScale);
        }
        // Otherwise, scale the sprite back to the starting size
        else
        {
            float newSize = Mathf.MoveTowards(transformComponent.localScale.x, startSize, scalingSpeed * Time.deltaTime);
            transformComponent.localScale = new Vector3(newSize, newSize, 1f);
        }        
    }
}
