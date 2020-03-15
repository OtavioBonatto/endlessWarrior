using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPowerUp : MonoBehaviour {

    public static PickupPowerUp instance;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerController.instance.invencibleCounter = PlayerController.instance.invencibleLength;
            AudioManager.instance.PlaySFX(1);
            gameObject.SetActive(false);
        }
    }
}
