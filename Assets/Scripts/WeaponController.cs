using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRateInSeconds;
	public float firstDelay;

	void Start ()
	{
		InvokeRepeating ("Fire", firstDelay, fireRateInSeconds);
	}
	
	void Fire ()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
	}
}
