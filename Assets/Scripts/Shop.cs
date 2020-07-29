using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public static bool PurchaseMachine ()
	{
		if (ScoreScript.scoreValue < 20) {
			Debug.Log ("You broke cunt");
            return false;
        }
		ScoreScript.scoreValue = ScoreScript.scoreValue - 20;
        return true;
	}

	public static bool PurchaseRedTurret ()
	{
		if (ScoreScript.scoreValue < 100) 
		{
			Debug.Log ("fAke!");
			return false;
		}

		ScoreScript.scoreValue = ScoreScript.scoreValue - 100;
		return true;
	}
}
