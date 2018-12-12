using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public float playerHealth = 100;        // Player health. Game over at 0 
    public float playerHealthRegen = 1;     // How much health to regenerate per second

    public float playerEnergy = 100;        // Player energy. Cannot boost or shoot at 0
    public float playerEnergyRegen = 10;    // How much energy to regenerate per second

    public int playerScore = 0;             // Score

    public GameObject player;               // Reference to player
    public GameObject scoreText;                  // Reference to UI score text
    public GameObject healthSlider;             // Reference to UI health slider
    public GameObject gameOverText;             // Reference to UI game over text

    public WorldController worldController; // Reference to the world
    public EnemySpawner enemySpawner;       // Reference to the enemy spawner

    public enum Level { MainMenu, Playing, Paused, GameOver };

    public Level currentStage;             // Dictates what stage the game is currently at

    public string mainMenuLevel = "MainMenu";

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
    void Start()
    {
        currentStage = Level.Playing;
        enemySpawner.startSpawning = false;
        gameOverText.SetActive(false);

    }

    void Update()
    {
        //If game is over, display game over text and stop movement
        if (currentStage == Level.GameOver)
        {
            scoreText.SetActive(false);
            healthSlider.SetActive(false);
            gameOverText.SetActive(true);

            enemySpawner.startSpawning = false;
            PlayerController.isAlive = false;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene(mainMenuLevel);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
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
            if (playerHealthRegen != 0 && playerHealth < healthSlider.GetComponent<Slider>().maxValue)
            {
                playerHealth += playerHealthRegen * Time.deltaTime;
            }

            // Update score and sliders
            playerScore++;
            Debug.Log(playerScore);
            scoreText.GetComponent<Text>().text = "Score: " + playerScore.ToString().PadLeft(9, '0');
            healthSlider.GetComponent<Slider>().value = playerHealth;

            if (playerHealth <= 0)
            {
                currentStage = Level.GameOver;

                //Update game over score text to current score
                Text gameOverScoreText = gameOverText.GetComponentsInChildren<Text>()[1];
                gameOverScoreText.text = "Score: " + playerScore;
                Debug.Log("GAME OVER");
            }
        }
    }
}