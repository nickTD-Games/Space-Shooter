using UnityEngine;
using System.Collections;

public class RamdomRotator : MonoBehaviour {
	public float maximumTumble;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();

		rb.angularVelocity = Random.insideUnitSphere * maximumTumble;	
	}
}
