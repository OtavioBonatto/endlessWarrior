using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string GameLevel;
    public string Leaderbords;

    private void Start() {
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>().PlayMusic();
    }
    
    public void PlayGame() {
        SceneManager.LoadScene(GameLevel);
    }

    public void LeaderbordsMenu() {
        SceneManager.LoadScene(Leaderbords);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
