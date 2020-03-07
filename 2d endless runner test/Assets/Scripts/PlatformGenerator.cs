using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] thePlatforms;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;
    private int selectedPlatform;
    public float randomCoinChance;

    // Start is called before the first frame update
    void Start() {
        platformWidth = thePlatforms[0].GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update() {
        if(transform.position.x < generationPoint.position.x) {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            selectedPlatform = Random.Range(0, thePlatforms.Length);

            transform.position = new Vector3(transform.position.x + (platformWidth / 2), transform.position.y, transform.position.z);

            SimplePool.Spawn(thePlatforms[selectedPlatform], transform.position, transform.rotation);

            if(Random.Range(0f, 100f) < randomCoinChance) {
                CoinGenerator.instance.SpawnCoins(new Vector3(transform.position.x, transform.position.y + .05f, transform.position.z));
            }           

            transform.position = new Vector3(transform.position.x + (platformWidth / 2), transform.position.y, transform.position.z);
        }
    }
}
