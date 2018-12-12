﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToPlayer : MonoBehaviour {

    public GameObject playerShip;
    public float speed = 5f;

    void Start()
    {
        if(!playerShip) playerShip = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update () {
        if(GameController.instance.currentStage == GameController.Level.GameOver) {
            return;
        }

        if (GameController.instance.playerScore % 750 == 0) {
            speed = Mathf.Max(speed + 0.5f, 7.75f);
        }

        transform.LookAt(playerShip.transform.position);
        transform.Rotate(new Vector2(0, -90), Space.Self);

        //move towards the player
        if (Vector3.Distance(transform.position, playerShip.transform.position) > 1f)
        {//move if distance from target is greater than 1
            Debug.Log("moving");
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
    }
}
