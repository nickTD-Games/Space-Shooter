using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public float fireRateInSeconds;
	public Boundary boundary;

	public GameObject shot;
	public Transform transformOfShotSpawn;

	private Rigidbody rb;

	private float nextFireAt;
	private bool autoFire;

	void Start() {
		nextFireAt = 0.0f;
		autoFire = false;

		rb = GetComponent<Rigidbody> ();
	}

	void Update() {
		if (Input.GetKeyUp (KeyCode.V)) {
			autoFire = !autoFire;
		}

		if (Fire () && Time.time > nextFireAt) {
			nextFireAt = Time.time + fireRateInSeconds;
			Instantiate (shot, transformOfShotSpawn.position, transformOfShotSpawn.rotation);
		}
	}

	bool Fire() {
		return autoFire || Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.Mouse0);
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.velocity = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed;
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
