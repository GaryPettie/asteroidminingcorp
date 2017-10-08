using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetingAssist : MonoBehaviour {

	[SerializeField] Image reticule;
	//TODO Link the targetting distance to the projectile speed and lifetime
	[SerializeField] float targetingDistance;

	void Update () {
		TargetAssist();
	}

	/// <summary>
	/// Changes the reticule alpha when an astroid is in range and sits within the center of the screen
	/// </summary>
	void TargetAssist () {
		Ray ray = new Ray();
		if (Physics.Raycast(ray.origin, transform.forward, targetingDistance)) {
			Color32 tempColor = reticule.color;
			tempColor.a = 135;
			reticule.color = tempColor;
		}
		else {
			Color32 tempColor = reticule.color;
			tempColor.a = 35;
			reticule.color = tempColor;
		} 
	}
}
