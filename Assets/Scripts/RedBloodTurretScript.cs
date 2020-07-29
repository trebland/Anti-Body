using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodTurretScript : MonoBehaviour {

	public GameObject redBloodCell;
	GameObject currentTurret;

	public float timer;
	public float wait = 5f;

	// Use this for initialization
	void Start () {
		timer = 1f;
		currentTurret = this.gameObject;
	}

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (timer < 0) 
		{
			GenerateBloodCell ();
			timer = wait;
		}

	}

	void GenerateBloodCell ()
	{
		GameObject thisCell;

		thisCell = Instantiate (redBloodCell, currentTurret.transform.position, Quaternion.identity);
	}
}
