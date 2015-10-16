using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	
	public GameObject explotion;
	public GameObject playerExplotion;

	public int scoreValue;

	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Boundary") || other.CompareTag("Enemy")) {
			return;
		}

		if (explotion != null) {
			Instantiate (explotion, transform.position, transform.rotation);
		}

		Destroy (other.gameObject);
		Destroy (gameObject);

		if (other.CompareTag ("Player")) {
			Instantiate (playerExplotion, transform.position, transform.rotation);
			gameController.GameOver();
		} else {
			gameController.AddScore(scoreValue);
		}
	}
}
