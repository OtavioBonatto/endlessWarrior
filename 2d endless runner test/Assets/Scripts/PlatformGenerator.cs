using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] thePlatforms;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    private int selectedPlatform;
    public float randomCoinChance;
    public float randomSpikesChance;
    public float randomPowerUpChance;

    // Start is called before the first frame update
    void Start() {
        platformWidth = thePlatforms[0].GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update() {
        if(transform.position.x < generationPoint.position.x) {

            selectedPlatform = Random.Range(0, thePlatforms.Length);

            transform.position = new Vector3(transform.position.x + (platformWidth / 2), transform.position.y, transform.position.z);

            SimplePool.Spawn(thePlatforms[selectedPlatform], transform.position, transform.rotation);

            if(Random.Range(0f, 100f) < randomPowerUpChance) {
                float gemXpos = Random.Range(transform.position.x - 6f, transform.position.x + 6f);

                CoinGenerator.instance.SpawnPowerUp(new Vector3(gemXpos, transform.position.y - 2.5f, transform.position.z));
            } else if(Random.Range(0f, 100f) < randomCoinChance) {

                float gemXpos = Random.Range(transform.position.x - 6f, transform.position.x + 6f);

                CoinGenerator.instance.SpawnCoins(new Vector3(gemXpos, transform.position.y - 2.5f, transform.position.z));
            } else {

                float spikeXposition = Random.Range(transform.position.x - 6f, transform.position.x + 6f);

                CoinGenerator.instance.SpawnSpikes(new Vector3(spikeXposition, transform.position.y - 3.3f, transform.position.z));
            }    

            transform.position = new Vector3(transform.position.x + (platformWidth / 2), transform.position.y, transform.position.z);
        }
    }
}
