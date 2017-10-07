using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour {

	public static bool isDestroyed = false;
	bool gameEnded = false;
	GameObject resultsPanel;
	Text endText;
	string placeholder = "[x]";
	ResourceManager resourceManager;

	// Use this for initialization
	void Start () {
		resultsPanel = GameObject.Find("Results");
		endText = GameObject.Find("ResultText").GetComponent<Text>();
		resultsPanel.SetActive(false);
		resourceManager = FindObjectOfType<ResourceManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDestroyed && !gameEnded) {
			EndGame();
		}
	}

	void EndGame () {
		//Blow up the ship
		GameObject[] ship = GameObject.FindGameObjectsWithTag("Ship");
		foreach (GameObject part in ship) {
			part.transform.SetParent(null);
			part.GetComponent<BoxCollider>().isTrigger = false;
		}

		//Display end card. 
		if(resultsPanel.activeInHierarchy == false) {
			resultsPanel.SetActive(true);
		}

		//End Game (makes sure this block only gets called once)
		gameEnded = true;

		//TODO Add a restart option
	}
}
