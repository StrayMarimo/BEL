using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    private Rigidbody2D rb;
    private Animator p_Animator;
    public float force;
    private GameObject startPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        startPoint = GameObject.FindGameObjectWithTag("Respawn");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    async private void OnCollisionEnter2D(Collision2D other) 
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Kill player");
            p_Animator = other.gameObject.GetComponent<Animator>();
            p_Animator.SetTrigger("Dead");
            await Task.Delay(500);
            
            // Move player to starting point
            Player.transform.position = startPoint.transform.position;
            // Move camera to starting point
            Camera.main.transform.position = new Vector3(startPoint.transform.position.x, startPoint.transform.position.y, startPoint.transform.position.z - 15);

            // Move wall of death to starting point 
            // TODO
            // MAKE WALL OF DEATH RESET
        }
        Destroy(gameObject);
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     // if (other.gameObject.CompareTag("Player")) 
    //     // {
    //     //     p_Animator = other.gameObject.GetComponent<Animator>();
    //     //     p_Animator.SetTrigger("Dead");
    //     //     await Task.Delay(500);
    //     //     Player.transform.position = startPoint.transform.position;
    //     //     Camera.main.transform.position = startPoint.transform.position;
    //     // }
    //     Destroy(gameObject);
    // }
}
