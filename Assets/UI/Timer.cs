using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	[SerializeField] float closeTimer;

	
	void Update () {
		if (Time.time > closeTimer)	{
			gameObject.SetActive(false);
		}
	}
}
