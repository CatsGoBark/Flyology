using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple script that automatically destroys a game object after a set amount of time.
 */
public class DestroyByTime : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifetime);
    }
}
