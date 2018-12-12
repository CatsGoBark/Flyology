using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string playGameLevel;

	// Function to Play Game
	public void playGame () {
        Debug.Log("pressed");
        SceneManager.LoadScene(playGameLevel);
	}
}
