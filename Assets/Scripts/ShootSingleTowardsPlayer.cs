using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSingleTowardsPlayer : MonoBehaviour {

    public float fireRate;          // Seconds between shots (Lower is faster)
    public float range;             // How close the player has to be to start firing
    public float bulletSpeed;       // How fast the bullet moves

    public GameObject bullet;       // The bullet being fired
    public GameObject player;       // Reference to the player

    private float nextFire;

	// Use this for initialization
	void Start ()
    {
        nextFire = 0;
	}
	
	void FixedUpdate ()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > range)
            return;
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject shot = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            shot.transform.up = player.transform.position - shot.transform.position;
        }
	}
}
