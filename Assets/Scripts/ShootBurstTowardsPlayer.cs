using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBurstTowardsPlayer : MonoBehaviour {

    public float fireRate;          // Seconds between shots (Lower is faster)
    public float range;             // How close the player has to be to start firing
    public float bulletSpeed;       // How fast the bullet moves
    public float burstRate;         // How close each bullet is to each other in a burst
    public float numInBurst;        // How many bullets are fired in a burst

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
        nextFireBurst = 0;
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
            }
        }

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
