﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;
    public bool scoreIncreasing; 

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        if(PlayerPrefs.HasKey("HighScore")) {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update() {

        if(scoreIncreasing) {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if(scoreCount > highScoreCount) {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Pontos: " + Mathf.Round(scoreCount);
        highScoreText.text = "Melhor Pontuação: " + Mathf.Round(highScoreCount);
    }

    public void AddScore(int pointsToAdd) {
        scoreCount += pointsToAdd;
    }
}