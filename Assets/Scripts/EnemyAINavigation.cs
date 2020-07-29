using UnityEngine;
using System.Collections;

public class EnemyAINavigation : MonoBehaviour {

	public static int movespeed = 3;
	public Vector3 userDirection = Vector3.right;

	public void Update()
	{
		transform.Translate(userDirection * movespeed * Time.deltaTime); 
	}


}