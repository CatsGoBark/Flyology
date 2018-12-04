using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemyList;      // List of potential enemies to spawn
    public float spawnTime = 10;        // Time inbetween enemy spawns
    public bool startSpawning = true;   // Determines if spawning should begin

    public GameObject player;           // Reference to player object
    public WorldController World;       // Reference to world

    private float nextSpawn;

    private float upperBoundary;        // Upper limit to where an enemy can spawn based on the world
    private float lowerBoundary;        // Lower limit to where an enemy can spawn based on the world

	// Use this for initialization
	void Start () {
        nextSpawn = 0;

        // TODO Maybe find a way to do this automatically?
        upperBoundary = 14;             // Hardcoded
        lowerBoundary = -14;            // Hardcoded
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!startSpawning)
            return;

        if (Time.time < nextSpawn)
            return;

        // Randomly spawn enemy left or right of the player outside the camera
        int randInt = Random.Range(0, 2);
        float xPos;
        if (randInt == 0)
        {
            xPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
            xPos -= Random.Range(0, 20);
        }
        else
        {
            xPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
            xPos += Random.Range(0, 20);
        }
        Vector2 pos = new Vector2(xPos, Random.Range(upperBoundary, lowerBoundary));
        GameObject enemy = Instantiate(enemyList[0]);
        enemy.transform.position = pos;
        nextSpawn = Time.time + spawnTime;
    }
}
