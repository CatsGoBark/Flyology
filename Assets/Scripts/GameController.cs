using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;

    public float playerHealth = 100;        // Player health. Game over at 0 
    public float playerHealthRegen = 5;     // How much health to regenerate per second

    public float playerEnergy = 100;        // Player energy. Cannot boost or shoot at 0
    public float playerEnergyRegen = 10;    // How much energy to regenerate per second

    public int playerScore = 0;             // Score

    public GameObject player;               // Reference to player
    public Text scoreText;                  // Reference to UI score text
    public Slider healthSlider;             // Reference to UI health slider
    public Slider energySlider;             // Reference to UI energy slider

    public WorldController worldController; // Reference to the world

    enum Level { MainMenu, Playing, GameOver};

    private Level currentStage;             // Dictates what stage the game is currently at

    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        currentStage = Level.MainMenu;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // Show main menu
        if (currentStage == Level.MainMenu)
        {

        }

        // Play game

        // Regen player health
        if (playerHealthRegen != 0 && playerHealth < healthSlider.maxValue)
        {
            playerHealth += playerHealthRegen * Time.deltaTime;
        }

        // Regen player energy
        if (playerEnergyRegen != 0 && playerEnergy < healthSlider.maxValue)
        {
            playerEnergy += playerEnergyRegen * Time.deltaTime; 
        }

        // Update score and sliders
        playerScore++;
        scoreText.text = "Score: " + playerScore.ToString().PadLeft(9, '0');
        healthSlider.value = playerHealth;
        energySlider.value = playerEnergy;

        if (playerHealth <= 0)
        {
            Debug.Log("GAME OVER");
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
