using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {
    
    public string mainMenuLevel;

    public void ResetGame() {
        GameManager.instance.Reset();
    } 

    public void QuitToMain() {
        SceneManager.LoadScene(mainMenuLevel);
    }
}
