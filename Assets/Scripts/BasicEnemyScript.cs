using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Basic script that all enemies should have. Tracks health, point value, and basic bullet collison. 
 */
public class BasicEnemyScript : MonoBehaviour {

    public float enemyHealth = 50;  // Enemy lose 10 health per hit
    public int pointValue = 1000;
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0)
        {
            // Add score and destroy
            GameController.instance.playerScore += pointValue;
            Destroy(gameObject);
        }
	}

    // Lose health when hit by a bullet
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            enemyHealth -= 10;
        }
    }
}
