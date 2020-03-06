using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    private PlatformDestroyer[] platformList;
    public DeathMenu theDeathScreen;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void RestartGame() {   
        
        ScoreManager.instance.scoreIncreasing = false; 

        thePlayer.gameObject.SetActive(false);   

        theDeathScreen.gameObject.SetActive(true);  

        PlayerController.instance.death = false;

        // StartCoroutine("RestartGameCo");
    }

    public void Reset() {
        theDeathScreen.gameObject.SetActive(false);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++) {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        ScoreManager.instance.scoreCount = 0;
        ScoreManager.instance.scoreIncreasing = true;        
    } 

    // public IEnumerator RestartGameCo() {
        
    //     yield return new WaitForSeconds(2f);
    // }
}
