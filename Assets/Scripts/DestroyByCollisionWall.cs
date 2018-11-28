using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to destroy the connected GameObject if it collides with a wall
 */
public class DestroyByCollisionWall : MonoBehaviour {

    // Collide Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collide with wall
        if (other.tag == "Boundary")
        {
            Destroy(gameObject);
            return;
        }
    }
}
