using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class DeathScript : MonoBehaviour
{
    Animator p_Animator;
    public GameObject startPoint;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            p_Animator = other.gameObject.GetComponent<Animator>();
            p_Animator.ResetTrigger("Walk");
            p_Animator.SetTrigger("Dead");
            await Task.Delay(500);
            Player.transform.position = startPoint.transform.position;
            p_Animator.ResetTrigger("Dead");
            p_Animator.SetTrigger("Idle");
        }
    }
}
