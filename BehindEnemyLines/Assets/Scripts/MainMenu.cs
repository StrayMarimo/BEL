using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start Button

    public static string avatar;
    public void LoadGame() {
        SceneManager.LoadScene(1);
    }
    
    public void SelectLevel() {
        SceneManager.LoadScene(2);
    }

    public void SelectDifficulty() {
        SceneManager.LoadScene(3);
    }

    public void StartLevel(string _avatar) {
        avatar = _avatar;
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void SelectMessenger() {
        
    }
}
