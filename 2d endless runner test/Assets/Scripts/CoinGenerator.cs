using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public static CoinGenerator instance;

    public GameObject coin;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SpawnCoins(Vector3 startPosition) {
        SimplePool.Spawn(coin, startPosition, coin.transform.rotation);
    }
}
