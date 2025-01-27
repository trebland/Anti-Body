using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour {

	//Singleton
	private static PlayerInputScript instance_;

	private PlayerInputScript () { }

	// USE THIS METHOD to access this object. (as in, MenuScript.instance().whatever())
	public static PlayerInputScript instance()
	{
		if (instance_ == null)
			instance_ = GameObject.FindObjectOfType<PlayerInputScript> ();
		return instance_;
	}

	public bool IsAPressed() { return AButtonPressed; }
	public bool IsBPressed() { return BButtonPressed; }
	public GameObject GetCurrentTile() { return currentGameObject; }
	public Color GetStartColor() { return new Color (1F, 1F, 1F, 1F);}

	public static float timerConstant = 0.15f;
	float timeLeft;

	Vector2 cursorPosition;
	Vector2 cursorStartPosition;


	//Colors
	Color selectedColor = new Color (1F, 1F, 1F, 0.6F);
	Color noColor = new Color (0F, 0F, 0F, 0F);

	//Materials that our selected game object will change into
	Renderer currentRenderer;
	public Material selectedMaterial;
	Material preselectedMaterial;

	//Our Gameobjects
	GameObject previousGameObject;
	GameObject currentGameObject;

	bool gameStarted;
	//Player-Input Variables
	int moveHorizontal;
	int moveVertical;
	bool AButtonPressed;
	bool BButtonPressed;
	bool StartButtonPressed;
	bool RightBumperPressed;
	bool LeftBumperPressed;

	// Use this for initialization
	void Start () {

		//Initializes our cursor positions
		cursorStartPosition = new Vector2 (0f, 0f);
		cursorPosition = cursorStartPosition;

		previousGameObject = null;

		//Sets our initial cursor
		cursorPosition = new Vector2 (1.0f, 4.0f);
		currentGameObject = BoardManagerScript.auxGameObjectBoard [1, 4];
		ChangeColor (currentGameObject);

		timeLeft = -1;
	}
	
	// Update is called once per frame
	void Update () {
		//Timer between cursor movement
		timeLeft -= Time.deltaTime;

		//Player-input axes
		int moveHorizontal = (int) Input.GetAxis ("Horizontal");
		int moveVertical = (int) Input.GetAxis ("Vertical");
		AButtonPressed = Input.GetButtonDown ("Fire1");
		BButtonPressed = Input.GetButtonDown ("Fire2");
		StartButtonPressed = Input.GetButtonDown ("Start");

		//Checks if we are able to move, and if the player wants to move the cursor
		if ((moveHorizontal > 0 || moveHorizontal < 0 || moveVertical > 0 || moveVertical < 0) && ( (timeLeft < 0) )) 
		{
			TrackCursor (moveHorizontal, moveVertical);
			timeLeft = timerConstant;
		}

	}



	void TrackCursor(int thisHorizontal, int thisVertical)
	{
		GameObject thisGameObject;

		cursorPosition = changePosition (thisHorizontal, thisVertical, (int) cursorPosition.x, (int) cursorPosition.y);

		thisGameObject = BoardManagerScript.auxGameObjectBoard [(int) cursorPosition.x, (int) cursorPosition.y];

		//Checks to see if this is our first tile or not
		if (currentGameObject == null)
			currentGameObject = thisGameObject;
		else 
		{
			previousGameObject = thisGameObject;
			currentGameObject = thisGameObject;
		}

		ChangeColor (currentGameObject);
	}

	/*
	 * Modifies our cursor position based on the input from the player
	 * deltaX and deltaY represents our player input
	 * initialX and initialY are our current Vector2 positions
	 */
	Vector2 changePosition(int deltaX, int deltaY, int initialX, int initialY)
	{
		Vector2 newLocation;

		//Our change in x and y
		int x = initialX, y = initialY;

		//Direction of our player axis
		if (deltaX > 0)
			x += 1;
		else if (deltaX < 0)
			x -= 1;

		if (deltaY > 0)
			y += 1;
		else if (deltaY < 0)
			y -= 1;

		//Ensures our cursor does not exceed the board values
		if (initialY == 5 && deltaY > 0)
		{
			y = 11;
		}
		else if (initialY == 11 && deltaY < 0)
		{
			y = 5;
		}
		x = Mathf.Clamp (x, 1, BoardManagerScript.row - 2);
		//y = Mathf.Clamp (y, 4, BoardManagerScript.col - 2);
		y = Mathf.Clamp (y, 4, 12);

		//Our new location on the grid
		newLocation = new Vector2 (x, y);

		return newLocation;
				
	}

	void ChangeColor (GameObject thisGameObject)
	{
		if (previousGameObject == null) {
			//Grabs the renderer of the tile we are currently on
			currentRenderer = thisGameObject.GetComponent<Renderer> ();

			//Saves our material that was previously here
			preselectedMaterial = currentRenderer.material;
			//Overwrites the material with a new material
			currentRenderer.material = selectedMaterial;
		}
		else 
		{
			//Reverts our last tile to its original material
			currentRenderer.material = preselectedMaterial;

			//Grabs the renderer of the tile we are currently on
			currentRenderer = thisGameObject.GetComponent<Renderer> ();

			//Saves our material that was previously here
			preselectedMaterial = currentRenderer.material;
			//Overwrites the material with a new material
			currentRenderer.material = selectedMaterial;
		}

	}
}
