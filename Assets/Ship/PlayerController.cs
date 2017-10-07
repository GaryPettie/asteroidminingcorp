using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Movement")]
	[SerializeField] float rotationSpeed;

	[Header("Weapons")]
	[SerializeField] GameObject leftGun;
	[SerializeField] GameObject rightGun;
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] float projectileSpeed;
	[SerializeField] float timeBetweenShots;

	float lastShotTime;
	GameObject projectileContainer;

	void Start () {
		projectileContainer = GameObject.Find("ProjectileContainer");
	}

	void Update () {
		PlayerMovement();
		FirePrimaryWeapon();
	}

	void PlayerMovement () {
		//Up
		if (Input.GetKey(KeyCode.W)) {
			Camera.main.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
		}

		//Left
		if (Input.GetKey(KeyCode.A)) {
			Camera.main.transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
		}

		//Down
		if (Input.GetKey(KeyCode.S)) {
			Camera.main.transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
		}

		//Right
		if (Input.GetKey(KeyCode.D)) {
			Camera.main.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
		}
	}

	void FirePrimaryWeapon () {
		//Primary Fire
		if (Input.GetKey(KeyCode.Space)) {
			if (Time.time - lastShotTime > timeBetweenShots) {

				GameObject leftProjectile = (GameObject)Instantiate(projectilePrefab, leftGun.transform.position, leftGun.transform.rotation, projectileContainer.transform);
				leftProjectile.GetComponent<Rigidbody>().velocity = leftGun.transform.forward * projectileSpeed;

				GameObject rightProjectile = (GameObject)Instantiate(projectilePrefab, rightGun.transform.position, rightGun.transform.rotation, projectileContainer.transform);
				rightProjectile.GetComponent<Rigidbody>().velocity = rightGun.transform.forward * projectileSpeed;

				lastShotTime = Time.time;
			}
			
		}
	}
}
