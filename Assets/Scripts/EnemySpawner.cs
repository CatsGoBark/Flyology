using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy1;
    private float spawnTimer = 5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //instantiate new enemies every 5 seconds
		if(Time.time > spawnTimer) {
            Vector2 pos = new Vector2(0, 0);
            Instantiate(enemy1, pos, Quaternion.identity);
            spawnTimer += Time.time;
        }
	}
}
