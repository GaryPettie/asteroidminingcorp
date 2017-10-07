using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] float lifetime;
	[SerializeField] float damage;

	void Start () {
		//Destroys the projectile after the alloted lifetime. 
		Destroy (gameObject, lifetime);
	}

	public float GetDamage() {
		return damage;
	}
}
