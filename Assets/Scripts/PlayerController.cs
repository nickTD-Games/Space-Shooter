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
	public Boundary boundary;

	public WeaponSystem[] weapons;

	private int currentWeaponLevel;

	private Rigidbody rb;
	
	private bool autoFire;

	public void UpgradeWeaponWithScore(int score) {
		int weaponLevel = currentWeaponLevel;
		for (int i = 0; i < weapons.Length; i++) {
			if (i > currentWeaponLevel && score > weapons[i].requiredScore) {
				weaponLevel = i;
			}
		}

		currentWeaponLevel = weaponLevel;
	}

	void Start() {
		autoFire = false;

		currentWeaponLevel = 0;

		rb = GetComponent<Rigidbody> ();
	}

	void Update() {
		if (Input.GetKeyUp (KeyCode.V)) {
			autoFire = !autoFire;
		} else if (Input.GetKeyUp (KeyCode.P)) {
			Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		}

		if (ShouldFire ()) {
			Fire ();
		}
	}

	void Fire() {
		weapons [currentWeaponLevel].Fire ();
	}

	bool ShouldFire() {
		return ShouldAutoFire() || Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.Mouse0);
	}

	bool ShouldAutoFire() {
		return autoFire && GameObject.FindWithTag("Enemy");
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
