using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;

    public float playerHealth = 100;        // Player health. Game over at 0 
    public float playerHealthRegen = 1;     // How much health to regenerate per second

    public float playerEnergy = 100;        // Player energy. Cannot boost or shoot at 0
    public float playerEnergyRegen = 10;    // How much energy to regenerate per second

    public int playerScore = 0;             // Score

    public GameObject player;               // Reference to player
    public Text scoreText;                  // Reference to UI score text
    public Slider healthSlider;             // Reference to UI health slider

    public WorldController worldController; // Reference to the world
    public EnemySpawner enemySpawner;       // Reference to the enemy spawner

    enum Level { MainMenu, Playing, GameOver};

    private Level currentStage;             // Dictates what stage the game is currently at

    // Do when game starts
    private void Awake()
    {
        // Set this as the GameController if it doesn't already exist
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        currentStage = Level.Playing;
        enemySpawner.startSpawning = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // Show main menu
        if (currentStage == Level.MainMenu)
        {
            player.transform.position = new Vector2(0, 0);
        }
        else if (currentStage == Level.Playing)
        {
            enemySpawner.startSpawning = true;

            // Regen player health
            if (playerHealthRegen != 0 && playerHealth < healthSlider.maxValue)
            {
                playerHealth += playerHealthRegen * Time.deltaTime;
            }

            // Update score and sliders
            playerScore++;
            scoreText.text = "Score: " + playerScore.ToString().PadLeft(9, '0');
            healthSlider.value = playerHealth;

            if (playerHealth <= 0)
            {
                currentStage = Level.GameOver;
                Debug.Log("GAME OVER");
            }
        }
        else if (currentStage == Level.GameOver)
        {

        }
	}

    // Restart the game
    void Restart()
    {
        // Reset numerical values
        playerHealth = 100;
        playerScore = 0;

        // Clear enemies

        // Reset playing field

        // Restart game
    }
}
