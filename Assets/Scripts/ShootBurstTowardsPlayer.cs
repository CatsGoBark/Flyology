using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Script that causes a GameObject to fire bullets towards the player in a burst
 */
public class ShootBurstTowardsPlayer : MonoBehaviour {

    public float fireRate = 2;      // Seconds between shots (Lower is faster)
    public float range = 20;        // How close the player has to be to start firing
    public float bulletSpeed;       // How fast the bullet moves
    public float burstRate = 0.2f;  // How close each bullet is to each other in a burst
    public float numInBurst = 3;    // How many bullets are fired in a burst

    public GameObject bullet;       // The bullet being fired
    public GameObject player;       // Reference to the player

    private float nextFire;
    private float nextFireBurst;
    private float currentShotNum;
    private bool isFiring;

    // Use this for initialization
    void Start()
    {
        nextFire = 0;
        currentShotNum = 0;
        isFiring = false;
    }

    void FixedUpdate()
    {
        // Continue burst if started
        if (isFiring)
        {
            if (currentShotNum >= numInBurst)
            {
                isFiring = false;
                nextFire = Time.time + fireRate;
                currentShotNum = 0;
            }
            else
            {
                if (Time.time < nextFireBurst)
                    return;
                nextFireBurst = Time.time + burstRate;
                GameObject shot = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
                shot.transform.up = player.transform.position - shot.transform.position;
                currentShotNum++;
            }
        }

        // Skip if player is too far away
        if (Vector3.Distance(transform.position, player.transform.position) > range)
            return;

        // Begin firing burst
        if (Time.time >= nextFire)
        {
            isFiring = true;
        }
    }
}
