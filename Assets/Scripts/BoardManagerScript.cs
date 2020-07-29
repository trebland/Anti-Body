using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerScript : MonoBehaviour {

	//Constants defined
	public static int row = 21, col = 14;
	//public static int[,] board = new int[row, col];
	public static GameObject[,] auxGameObjectBoard = new GameObject[row, col];

	/*
	 * Splits our board pieces into the usable (i.e. center),
	 * and the unusable (i.e. edges)
	*/
	public GameObject usableBoardPiece;
	public GameObject unusableBoardPiece;

	Color startColor;
	//Holds our game objects to prevent clutter in the hierarchy
	Transform parentBoard;

	void Awake () {
		startColor = PlayerInputScript.instance().GetStartColor();
		LayoutBoard (usableBoardPiece, unusableBoardPiece);
	}

	void LayoutBoard(GameObject thisInnerPiece, GameObject thisOuterPiece)
	{
		parentBoard = new GameObject ("BoardHolder").transform;
		parentBoard.SetParent (this.transform);

		//Number of objects
		int numObjects = 0;

		//Our current object we're setting
		GameObject thisObject;

		//2D Board Array
		for (int x = 0; x < row; x++) 
		{
			float[] yArr = { 4.5f, 5.5f, 11.5f, 12.5f };

			//Checks for an edge on our grid, and places an unusable block there
			if ( !(x == 0 || x == (row-1)) )
			{
				for (int y = 0; y <= 3; y++) 
				{
					//Counter for the number of board pieces currently on the board
					numObjects++;

					thisObject = Instantiate (thisInnerPiece, new Vector2 (x, yArr[y]), Quaternion.identity);
					//thisObject.GetComponent<Renderer>().material.color = startColor;
					thisObject.name = "Piece " + numObjects;
					auxGameObjectBoard [x, (int) yArr[y]] = thisObject;
					thisObject.transform.SetParent (parentBoard);
				}
			}

		}
	}
}
/*
{
					thisObject = Instantiate (thisOuterPiece, new Vector3 (x, y, 0f), Quaternion.identity);

					//Names our current object by the number of piece placed
					thisObject.name = "Piece " + numObjects;
					//Adds our current gameobject to the gameobject array
					auxGameObjectBoard [x, y] = thisObject;
					//Helps handle the hierarchy
					thisObject.transform.SetParent (parentBoard);
				} 
				else 
*/