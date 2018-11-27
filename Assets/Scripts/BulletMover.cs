using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple script that gives an object movement once spawned
 */
public class BulletMover : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed * 100);
    }
}
