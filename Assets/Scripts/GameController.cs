using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float playerHealth;          // Player health. Game over at 0
    public int playerScore;             // Score

    public float playerRegenTime;       // Time inbetween health regen
    public float playerRegenAmount;     // How much health to regenerate

    public GameObject player;           // Reference to player
    public Text scoreText;              // Reference to UI score text
    public Slider healthSlider;         // Reference to UI health slider

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        playerScore++;
        scoreText.text = "Score: " + playerScore.ToString().PadLeft(9, '0');
        healthSlider.value = playerHealth;

        if (playerHealth <= 0)
        {
            Debug.Log("GAME OVER");
        }
	}

    // Restart the game
    void restart()
    {
        // Reset numerical values
        playerHealth = 100;
        playerScore = 0;

        // Clear enemies

        // Reset playing field

        // Restart game
    }
}
