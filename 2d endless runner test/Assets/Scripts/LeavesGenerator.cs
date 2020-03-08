using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesGenerator : MonoBehaviour {

    public GameObject leaf;
    public float randomLeafChance;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
 
        Vector2 spawnPosition = new Vector2(spawnX, this.transform.position.y);

        if(Random.Range(0f, 100f) < randomLeafChance) {
            SimplePool.Spawn(leaf, spawnPosition, leaf.transform.rotation);
        }

        //SimplePool.Spawn(leaf, spawnPosition, leaf.transform.rotation);
    } 
}
