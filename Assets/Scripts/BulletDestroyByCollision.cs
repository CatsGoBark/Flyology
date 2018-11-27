using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to destroy the connected GameObject if it collides with something
 */
public class BulletDestroyByCollision : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

    // Collide Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collide with wall
        if (other.tag == "Boundary")
        {
            Destroy(gameObject);
            return;
        }

        // Collide with enemy
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            return;
        }
    }
}
