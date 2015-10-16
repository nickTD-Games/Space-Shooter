using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject[] hazards;
	public Vector3 spawnValues;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	public int hazardCount;
	public float startWaitTime;
	public float spawnWaitTime;
	public float waveWaitTime;

	private int score;

	private bool gameOver;
	private bool restart;

	public void AddScore (int deltaScore) {
		score += deltaScore;
		updateScoreText ();
	}

	public void GameOver() {
		gameOverText.text = "Game Over!";
		gameOver = true;

		restartText.text = "Press 'R' for Restart";
		restart = true;
	}

	void Update() {
		if (restart && Input.GetKey (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void Start () {
		score = 0;
		updateScoreText ();

		gameOver = false;
		restart = false;

		restartText.text = "";
		gameOverText.text = "";

		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWaitTime);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];
				float x = Random.Range (-spawnValues.x, spawnValues.x);
				Vector3 spawnPostion = new Vector3 (x, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazard, spawnPostion, spawnRotation);

				yield return new WaitForSeconds (spawnWaitTime);
			}

			yield return new WaitForSeconds (waveWaitTime);

			if (gameOver)
			{
				break;
			}
		}
	}

	void updateScoreText() {
		scoreText.text = "Score: " + score;
	}
}
