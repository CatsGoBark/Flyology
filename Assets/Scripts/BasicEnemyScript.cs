using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Basic script that all enemies should have. Tracks health, point value, and basic bullet collison. 
 */
public class BasicEnemyScript : MonoBehaviour {

    public float enemyHealth = 50;  // Enemy lose 10 health per hit
    public int pointValue = 1000;

    public AudioClip hitSound;
    public AudioClip explosionSound;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		if (enemyHealth <= 0)
        {
            // Add score and destroy
            GameController.instance.playerScore += pointValue;
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
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
            source.pitch = Random.Range(0.8f, 1.0f);
            source.PlayOneShot(hitSound, 1.0f);
        }
    }
}
