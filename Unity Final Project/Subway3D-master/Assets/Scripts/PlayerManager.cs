using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour {
	public static bool gameOver;
	public GameObject gameOverPanel;
	public static bool isGameStarted;
	public GameObject startingText;
	public static int numberOfCoins;
	public Text coinsText, scoreText, playerName, highestScore;
	int highest;
	private static int currentScore;
	//string yy = "ahm";
	void Start () {
		gameOver = false;
		Time.timeScale = 1;
		isGameStarted = false;
		numberOfCoins = 0;
		currentScore = 0;
		playerName.text = "Player: " + PlayerPrefs.GetString("name");
		highest = PlayerPrefs.GetInt(PlayerPrefs.GetString("name"));

	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
			Time.timeScale = 0;
			gameOverPanel.SetActive(true);
			playerName.enabled = false;
		}
        if (Input.GetKeyDown(KeyCode.Space))
        {
			isGameStarted = true;
			Destroy(startingText);
        }
		int x = PlayerController.pos;

		if (isGameStarted) currentScore = x;
		if (highest < currentScore) highest = currentScore;
		PlayerPrefs.SetInt(PlayerPrefs.GetString("name"), highest);
		//Debug.Log(PlayerPrefs.GetInt(playerName.text));
		//Debug.Log(playerName.text);
		coinsText.text = "Coins: " + numberOfCoins;
		scoreText.text = "Score: " + currentScore;
		highestScore.text = "Highest: " + highest;
		//playerName.text = "Player: " + PlayerPrefs.GetString("name");
		//Debug.Log(PlayerPrefs.GetString("name"));
	}
	
}
