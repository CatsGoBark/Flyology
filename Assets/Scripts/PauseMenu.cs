using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenuUI;

	// Use this for initialization
	void Start () {
        pauseMenuUI.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
            if(GameController.instance.currentStage == GameController.Level.Paused) {
                Resume();
            } else {
                Debug.Log("paused");
                Pause();
            }
        }
	}

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameController.instance.currentStage = GameController.Level.Playing;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameController.instance.currentStage = GameController.Level.Paused;
    }

    public void LoadMenu() {
        Time.timeScale = 1f; ;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
