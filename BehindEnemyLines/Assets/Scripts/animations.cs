using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject Option_1;
 
    IEnumerator Start()
    {
        Option_1.SetActive(false);
        yield return new WaitForSeconds(2f);
        Option_1.SetActive(true);
    }
}
