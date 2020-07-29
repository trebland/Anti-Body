using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public static int Rounds = 0;
	public Text waves;

	void Update ()
	{
		waves.text = "waves: " +
			Rounds;
	}

}