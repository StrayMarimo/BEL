using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPrefs : MonoBehaviour
{

    [SerializeField, HideInInspector]
    public string avatar = "";

    [SerializeField, HideInInspector]
    public int totalScore = 0;

    [HideInInspector]
    public bool isInBulletZone = false;

    [HideInInspector]
    public Animator playerAnimator;

    public OnDeath onDeath;
    public FireSpawnScript fireSpawnScript;

    private Text Score;
    private GameObject scoreCanvas;

    public RuntimeAnimatorController civilianController;
    public RuntimeAnimatorController messengerController;
    public RuntimeAnimatorController veteranController;


    // Start is called before the first frame update
    void Start()
    {
        avatar = MainMenu.avatar;
        playerAnimator = GetComponent<Animator>();
        SetAvatar();
        scoreCanvas = GameObject.FindGameObjectWithTag("Score");
        Score = scoreCanvas.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + totalScore.ToString();   
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("BulletZone")) {
            isInBulletZone = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BulletZone"))
        {
            isInBulletZone = false;
        }
    }

    public void KillPlayer()
    {
        onDeath.OnPlayerDeath();

        fireSpawnScript.resetFireSpawn();
        fireSpawnScript.clearFire();
    }

    private void SetAvatar() {
        if (avatar == "Civilian")
        {
            playerAnimator.runtimeAnimatorController = civilianController;
        }
        else if (avatar == "Messenger") 
        {
            playerAnimator.runtimeAnimatorController = messengerController;
        } else 
        {
            playerAnimator.runtimeAnimatorController = veteranController;
        }
    }
}
