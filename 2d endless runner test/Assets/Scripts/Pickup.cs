﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int scorePoints;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            ScoreManager.instance.AddScore(scorePoints);
            AudioManager.instance.PlaySFX(1);
            gameObject.SetActive(false);
        }
    }
}
