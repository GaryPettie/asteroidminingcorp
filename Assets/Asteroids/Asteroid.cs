using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	[SerializeField] float minHealth;
	[SerializeField] float maxHealth;
	[SerializeField] float minOre;
	[SerializeField] float maxOre;

	float health;
	float ore;
	ResourceManager resourceManager;

	void Start () {
		resourceManager = FindObjectOfType<ResourceManager>();
		health = Random.Range(minHealth, maxHealth);
		ore = Random.Range(minOre, maxOre);
	}

	void OnTriggerEnter (Collider col) {
		//Takes damage when hit by a projectile
		if (col.gameObject.tag == "Projectile") {
			health -= col.GetComponent<Projectile>().GetDamage();

			Destroy(col.gameObject);

			//TODO Add an effect to the distruction of the asteroids, so they don't just blink out of existence. 
			if (health <= 0) {
				resourceManager.AddOre(ore);
				Destroy(gameObject);
			}
		}

		//Destroys the ship
		if (col.gameObject.tag == "Ship" && Ship.isDestroyed == false) {
			Ship.isDestroyed = true;
		}
	}
}
