using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script that fires a single shot towards the player in set intervals if they are within range
 */
public class ShootSingleTowardsPlayer : MonoBehaviour {

    public float fireRate = 2;      // Seconds between shots (Lower is faster)
    public float range = 20;        // How close the player has to be to start firing
    public float bulletSpeed = 5 ;  // How fast the bullet moves

    public GameObject bullet;       // The bullet being fired
    public GameObject player;       // Reference to the player

    private float nextFire;

	// Use this for initialization
	void Start ()
    {
        nextFire = 0;
        if (player == null)
            player = GameObject.Find("Player");
    }

    void FixedUpdate ()
    {
        //Don't fire if game is over
        if (GameController.instance.currentStage == GameController.Level.GameOver)
        {
            return;
        }

        // Checks if player is within firing range
        if (Vector3.Distance(transform.position, player.transform.position) > range)
            return;

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject shot = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            shot.transform.up = player.transform.position - shot.transform.position;
            shot.GetComponent<Rigidbody2D>().velocity = shot.transform.up * bulletSpeed;
        }
	}

    public void updateFireRate(float rate)
    {
        fireRate = Mathf.Min(fireRate + rate, 1.5f);
    }
    public void updateBulletSpeed(float rate)
    {
        bulletSpeed = Mathf.Max(bulletSpeed + rate, 7.5f);
    }
}
