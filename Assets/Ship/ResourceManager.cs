using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

	[SerializeField] Text oreText;

	float currentOre = 0;

	public void AddOre (float amount) {
		currentOre += Mathf.Round(amount * 100f) / 100f;
		oreText.text = "Ore: " + currentOre;
	}

	public float GetOre () {
		return currentOre;
	} 
}
