using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	
	public int lives = 3;
	public int score = 000000;
	public int coins = 00;
	public int level = 0;

	public Text livesText;
	public Text scoreText;
	public Text coinsText;
	public Text levelText;

	public KeyCode left;

	public static GM instance = null;
	
	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	void checkGameOver() {
		if (lives == -1)
			Application.LoadLevel ("GameOverScene");
	}

	public void checkCoins() {
		if (coins > 99) {
			coins = 0;
			lives++;
		}
	}

	public void collectCoin() {
		coins++;
		score++;
		scoreText.text = "mario " + score.ToString("D6");
		coinsText.text = "*" + coins.ToString("D2");
		checkCoins();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (left)) {
			collectCoin ();
		}
	}
}
