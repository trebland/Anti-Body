using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAdjuster : MonoBehaviour {

	public GameObject OurSprite;
	public Material weakened;
	public Material nearDeath;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (MenuScript.instance ().playerHealth);

		if (MenuScript.instance ().playerHealth < 1) 
		{
			Destroy (GameObject.Find ("BackgroundHealthy"));
		}
		else if (MenuScript.instance().playerHealth < 3)
		{
			Destroy (GameObject.Find ("BackgroundWeakened"));
		}
	}
}
