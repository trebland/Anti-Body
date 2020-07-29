using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

    public GameObject bacteria;
    public GameObject virus;
    private int enemiesLeft;
    private int enemiesToSpawn;

    private void Update()
    {
        // if we're in action phase, not building phase, spawn enemies
        if(!MenuScript.instance().WeAreInBuildPhase())
        {
            
        }
        // otherwise, we're in build phase so don't spawn stuff
        else
        {

        }
    }

    private void NewLevel()
    {
        enemiesToSpawn += 5;
    }


}
