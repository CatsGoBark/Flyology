using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Basic script that all enemies should have. Tracks health, point value, and basic bullet collison. 
 */
public class BasicEnemyScript : MonoBehaviour {
    public GameObject playerShip;

    public float enemyHealth = 50;  // Enemy lose 10 health per hit
    public int pointValue = 1000;
    public int speed = 5;

    //public GameController gameController;

    private void Start()
    {
        playerShip = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {

        Debug.Log(playerShip.transform.position);
        transform.LookAt(playerShip.transform.position);
        transform.Rotate(new Vector2(0, -90), Space.Self);

        //move towards the player
        if (Vector3.Distance(transform.position, playerShip.transform.position) > 1f)
        {//move if distance from target is greater than 1
            Debug.Log("moving");
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }

        if (enemyHealth <= 0)
        {
            // Add score and destroy
           GameController.instance.playerScore += pointValue;
            Destroy(gameObject);
        }
	}

    // Lose health when hit by a bullet
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            enemyHealth -= 10;
        }
    }
}
