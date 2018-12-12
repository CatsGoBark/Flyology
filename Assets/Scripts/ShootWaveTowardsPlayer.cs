using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Script that shoots a single wave of bullets towards a player.
 */
public class ShootWaveTowardsPlayer : MonoBehaviour {

    public float fireRate = 2;      // Seconds between shots (Lower is faster)
    public float range = 20;        // How close the player has to be to start firing
    public float bulletSpeed = 5;   // How fast the bullet moves
    public float numInWave = 5;     // How many bullets are fired in a burst
    public float waveSpacing = 10;  // How many degrees each bullet in a wave should be spaced out

    public GameObject bullet;       // The bullet being fired
    public GameObject player;       // Reference to the player

    private float nextFire;
    private bool isFiring;

    // Use this for initialization
    void Start () {
        nextFire = 0;
        isFiring = false;
        if (player == null)
            player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
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

            for (int i=1; i<numInWave+1; i++)
            {
                GameObject shot = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
                shot.transform.up = player.transform.position - shot.transform.position;
                shot.transform.Rotate(0, 0, (waveSpacing * Mathf.Round(i/2) * Mathf.Pow(-1, i)), Space.World);
                shot.GetComponent<Rigidbody2D>().velocity = shot.transform.up * bulletSpeed;
            }
        }
    }

}
