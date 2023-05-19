using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    [SerializeField, HideInInspector]
    public int totalScore = 0;
   
    private Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponentInChildren<Text>();
        totalScore = PlayerPrefs.totalScore;
        score.text = "Score: " + totalScore.ToString();      
    }

}
