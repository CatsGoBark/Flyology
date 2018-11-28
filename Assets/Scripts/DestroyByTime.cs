using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple script that automatically destroys a game object after a set amount of time.
 * Set to -1 to make it last forever
 */
public class DestroyByTime : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Start () {
        if (lifetime == -1)
            return;
        Destroy(gameObject, lifetime);
    }
}
