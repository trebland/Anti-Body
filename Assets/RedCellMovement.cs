using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCellMovement : MonoBehaviour {

	float force;

	GameObject thisObject;
	Vector3 downWards = new Vector3 (2f, 0f, 0f);
	Vector3 upWards = new Vector3 (2f, 0f, 0f);

	// Use this for initialization
	void Start () {
		
		thisObject = this.gameObject;
		if (thisObject.transform.position.y > 10)
			force = -2f;
		else
			force = 2f;

		thisObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, force);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (thisObject.transform.position.y);

		if (thisObject.transform.position.y < 10 && thisObject.transform.position.y > 9) {
			DirectionToSend (downWards);
		} 
		else if (thisObject.transform.position.y < 8 && thisObject.transform.position.y > 7)
		{
			DirectionToSend (upWards);
		}
	}

	void DirectionToSend (Vector3 Direction)
	{
		if (thisObject.transform.position.y < 10 || thisObject.transform.position.y > 7) 
		{
			Debug.Log (Direction);
			thisObject.GetComponent<Rigidbody2D> ().velocity = Direction;
		}
	}
}
