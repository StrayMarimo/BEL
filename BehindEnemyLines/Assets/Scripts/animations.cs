using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class animations : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        gameObject.SetActive(false);
        await Task.Delay(2500);
        gameObject.SetActive(true);
    }
}
