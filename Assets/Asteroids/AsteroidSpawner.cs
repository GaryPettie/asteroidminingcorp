using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	[SerializeField] float timeBetweenSpawns;
	[SerializeField] GameObject asteroidPrefab;
	[SerializeField] float speed;
	[SerializeField] float minSize;
	[SerializeField] float maxSize;


	GameObject[] spawnPoints;
	GameObject[] targets;
	float lastAsteroidTime;

	// Use this for initialization
	void Start () {
		spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
		targets = GameObject.FindGameObjectsWithTag("Target");
	}
	
	// Update is called once per frame
	void Update () {
		SpawnNewAsteroid();
	}

	void SpawnNewAsteroid () {
		if(Time.time - lastAsteroidTime > timeBetweenSpawns) {
			//select a random spawn point
			int spawnIndex = Random.Range(0, spawnPoints.Length);

			//create the asteroid
			GameObject asteroid = (GameObject)Instantiate(asteroidPrefab, spawnPoints[spawnIndex].transform.position, Quaternion.identity, spawnPoints[spawnIndex].transform);

			//Change the shape to add variety
			asteroid.transform.localScale = new Vector3(Random.Range(minSize,maxSize), Random.Range(minSize,maxSize), Random.Range(minSize,maxSize));

			//Give it some health and resources
			asteroid.GetComponent<Asteroid>();
			asteroid.GetComponent<Asteroid>();
			asteroid.GetComponent<Asteroid>();

			//Point it at a chosen target
			int targetIndex = Random.Range(0, targets.Length);
			asteroid.transform.LookAt(targets[targetIndex].transform.position);

			//add some initial velocity and spin.
			Rigidbody asteroidRB = asteroid.GetComponent<Rigidbody>();
			asteroidRB.AddRelativeForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
			asteroidRB.angularVelocity = Vector3.right;

			//resets the timer
			lastAsteroidTime = Time.time;
		}
	} 
}
