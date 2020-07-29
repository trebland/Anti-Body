﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 10f;

	public Text waveCountdownText;


	private int waveIndex = 0;

	void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			this.enabled = false;
		}

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		Vector2 newSpawnPoint = spawnPoint.position;

		for (int i = 0; i < wave.count; i++)
		{	
			newSpawnPoint.y = Random.Range (6.69f, 10.5f);
			SpawnEnemy(wave.enemy, newSpawnPoint);
			yield return new WaitForSeconds(1f / wave.rate);
		}


		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy, Vector2 spawn)
	{
		Instantiate(enemy, spawn, spawnPoint.rotation);
	}

}