using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    // Singleton
    private static MenuScript instance_;

    private MenuScript() { }

    // USE THIS METHOD to access this object. (as in, MenuScript.instance().whatever())
    public static MenuScript instance()
    {
        if (instance_ == null)
            instance_ = GameObject.FindObjectOfType<MenuScript>();
        return instance_;
    }

    public Text healthText;

    public void DeductHealth()
    {
        playerHealth--;
        healthText.text = "Health: " + playerHealth;
    }

    // State handling
    private bool weAreInBuildPhase;
    private float buildTimer;
    private bool shouldResetTimer;

    public int playerHealth;
    public bool WeAreInBuildPhase() { return weAreInBuildPhase; }
    public void GoToBuildPhase() { weAreInBuildPhase = true; }

	//Player Start-Button
	bool gameStarted = false;

    // May have bug with repeated instantiation on restart
    private void Awake()
    {
        if (GameObject.Find("TransitionManager") != null) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    // called by button in start menu
    public void StartGame()
    {
        ScoreScript.scoreValue = 20;
        playerHealth = 5;
        //healthText.text = "Health: " + playerHealth;
        SceneManager.LoadSceneAsync("MainScene");
        weAreInBuildPhase = true;
        shouldResetTimer = true;
    }

    // should be called when game should end
    public void GameOver()
    {
        SceneManager.LoadSceneAsync("MenuScene");
        playerHealth = 5;
    }

    int times = 1;
    float TiredOfThisShitTimer = 5f;
    public GameObject EndTEXT;

    private void Update()
    {
        /*
            NOTE: should set build time to true again when all enemies
                  in wave have been defeated
        */

        if (playerHealth < 0)
        {
            if (times == 1)
            {
                Instantiate(EndTEXT, new Vector2(10f,7.2f), Quaternion.identity);
                times = 2;
            }
            TiredOfThisShitTimer -= Time.deltaTime;
            
            if(TiredOfThisShitTimer < 0f)
            {
                GameOver();
            }
        }
        if (!gameStarted)
			CheckForStart ();

        if(weAreInBuildPhase)
        {
            // sets timer at beginning of build phase
            if (shouldResetTimer == true)
            {
                shouldResetTimer = false;
                buildTimer = 30f;
            }
            // counting down each frame
            buildTimer -= Time.deltaTime;
            // if time is up, end build phase and enable timer reset
            if (buildTimer < 0)
            {
                weAreInBuildPhase = false;
                shouldResetTimer = true;
            }
        }

    }

	private void CheckForStart ()
	{
		if(Input.GetButtonDown("Start"))
		{
			gameStarted = true;
			StartGame ();
		}
	}
}
