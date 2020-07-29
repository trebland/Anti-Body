using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.tag == "Enemy") {
            Destroy (col.gameObject);
        }

		if (col.gameObject.tag == "Projectile") 
		{
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "Resource") 
		{
			ScoreScript.scoreValue += 10;
			Debug.Log (ScoreScript.scoreValue);
			Destroy (col.gameObject);
		}
    }
}
