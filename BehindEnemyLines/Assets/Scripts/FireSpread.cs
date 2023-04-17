using UnityEngine;

public class FireSpread : MonoBehaviour
{
    public float widthIncreasePerSecond = 1f; // The amount to increase the width per second

    void Update()
    {
        // Increase the width of the game object by the desired amount
        transform.localScale += new Vector3(widthIncreasePerSecond * Time.deltaTime, 0f, 0f);
    }
}
