using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start Button

    public void LoadGame() {
        SceneManager.LoadScene(1);
    }
    
    public void SelectLevel() {
        SceneManager.LoadScene(2);
    }

    public void SelectDifficulty() {
        SceneManager.LoadScene(3);
    }

    public void StartLevel() {
        SceneManager.LoadScene(4);
    }

    public void SelectMessenger() {
        
    }
}
