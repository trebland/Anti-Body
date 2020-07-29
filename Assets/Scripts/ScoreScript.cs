using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreScript : MonoBehaviour {

	public static int scoreValue = 40;
	public Text score;
    public static float enemyHealthMultiplier;
    private float timer;

	void Start () {
        scoreValue = 80;
        timer = 20f;
        enemyHealthMultiplier = 1f;

		if (score != null)
        	score.text = "Cells: " + scoreValue;
    }

	void Update () {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            enemyHealthMultiplier += enemyHealthMultiplier * .5f;
            timer = 20f;
        }

		if (score != null)
			score.text = "Cells: " + scoreValue;
	}
}

