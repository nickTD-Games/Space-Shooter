using UnityEngine;
using System.Collections;

public class WeaponSystem : MonoBehaviour {

	public GameObject shot;
	public Transform[] weapons;
	public int requiredScore;

	public float fireRateInSeconds;
	private float nextFireAt;

	void Start () {
		nextFireAt = 0.0f;
	}

	public void Fire() {
		if (Time.time > nextFireAt) {
			nextFireAt = Time.time + fireRateInSeconds;
			for (int i =0; i < weapons.Length; i++) {
				Transform transformOfShotSpawn = weapons[i];
				Instantiate (shot, transformOfShotSpawn.position, transformOfShotSpawn.rotation);
			}
		}
	}
}
