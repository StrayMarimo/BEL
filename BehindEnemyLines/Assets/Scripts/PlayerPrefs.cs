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
    public static int totalScore = 0;

    [HideInInspector]
    public bool isInBulletZone = false;

    [HideInInspector]
    public Animator playerAnimator;

    public OnDeath onDeath;
    public FireSpawnScript fireSpawnScript;

    private Text Score;
    private int currentLives;
    private int maxLives;
    private GameObject scoreCanvas;
    private GameObject livesCanvas;

    public RuntimeAnimatorController civilianController;
    public RuntimeAnimatorController messengerController;
    public RuntimeAnimatorController veteranController;
    public Image[] heartImages;


    // Start is called before the first frame update
    void Start()
    {
        avatar = MainMenu.avatar;
        playerAnimator = GetComponent<Animator>();
        SetAvatar();
        currentLives = maxLives;
       
        scoreCanvas = GameObject.FindGameObjectWithTag("Score");
        livesCanvas = GameObject.FindGameObjectWithTag("Lives");
        Score = scoreCanvas.GetComponentInChildren<Text>();
        heartImages = livesCanvas.GetComponentsInChildren<Image>();

        setLives();
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
        currentLives--;
         if (currentLives == 0)
        {
            SceneManager.LoadScene(5, LoadSceneMode.Single);
        } 
        else
        {
            onDeath.OnPlayerDeath();
            
            updateLives();
            fireSpawnScript.resetFireSpawn();
            fireSpawnScript.clearFire();
        }

       
    }

    private void SetAvatar() {
        if (avatar == "Civilian")
        {
            playerAnimator.runtimeAnimatorController = civilianController;
            maxLives = 1;
        }
        else if (avatar == "Messenger") 
        {
            playerAnimator.runtimeAnimatorController = messengerController;
            maxLives = 2;
        } else 
        {
            playerAnimator.runtimeAnimatorController = veteranController;
            maxLives = 3;
        }
    }


    private void setLives() {
        for(int i = 0; i < maxLives; i++) {
           heartImages[i].enabled = true;
        } 
    }

    private void updateLives() {
        for(int i = 0; i < maxLives; i++) {
            if (i < currentLives)
            {
                heartImages[i].enabled = true;
                
            } else
            {
                heartImages[i].enabled = false;
            }
        } 
    }
}
