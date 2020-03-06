using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string GameLevel;
    
    public void PlayGame() {
        SceneManager.LoadScene(GameLevel);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
