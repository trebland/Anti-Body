using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManagerScript : MonoBehaviour {

	public GameObject[] buildingList = new GameObject[2];
	GameObject currentTile;
	Vector2 buildPosition;

	bool buildButtonA;
	bool buildButtonB;

	Quaternion buildingRotation;
	int buildingArrayPosition;

	// Use this for initialization
	void Start () {
		buildButtonA = false;
		buildButtonB = false;
		buildingArrayPosition = 0;
	}

    // Update is called once per frame

    void Update()
    {

        CheckPlayerInput();
        currentTile = PlayerInputScript.instance().GetCurrentTile();

        //If the player is allowed to build
        if (buildButtonA && currentTile != null)
        {
            //If build-button is pressed
            
            if (Shop.PurchaseMachine())
            {
	            if (currentTile.transform.position.y > 6)
	            {
	                buildingRotation.SetLookRotation(new Vector3(0f, 0f, 180f), Vector3.down);
	            }
	            else
	            {
	                buildingRotation.SetLookRotation(new Vector3(0f, 0f, 0f), Vector3.up);
	            }

	            BuildOnTile(0);
			}
        }
		else if (buildButtonB && currentTile != null)
			{
				//If build-button is pressed

				if (Shop.PurchaseRedTurret())
				{
					if (currentTile.transform.position.y > 6)
					{
						buildingRotation.SetLookRotation(new Vector3(0f, 0f, 180f), Vector3.down);
					}
					else
					{
						buildingRotation.SetLookRotation(new Vector3(0f, 0f, 0f), Vector3.up);
					}

					BuildOnTile(1);
				}
			}
	}

	void CheckPlayerInput ()
	{
		buildButtonA = PlayerInputScript.instance ().IsAPressed ();
		buildButtonB = PlayerInputScript.instance ().IsBPressed ();
	}

	void BuildOnTile (int whichBuilding)
	{
		//Checks to see if our currentTile has a building already
		int buildable = currentTile.GetComponent<BoardPieceScript>().GetTileWeight();
		if (buildable == 0) {
			//Based on our current position in the building array we will use that gameobject
			GameObject thisBuilding = buildingList [whichBuilding];
			//Tells the tile there is a building there now
			currentTile.GetComponent<BoardPieceScript>().BuildSomethingHere();

			//Instantiates the building at the target tile

			thisBuilding = Instantiate (thisBuilding, currentTile.transform.position, buildingRotation);
			thisBuilding.transform.SetParent (currentTile.transform);

			GameObject turret = thisBuilding.transform.GetChild (0).gameObject;
			int newForce = turret.GetComponent<TurretScript>().force;
			if (newForce > 0 && thisBuilding.transform.position.y > 6)
				turret.GetComponent<TurretScript> ().force = (newForce * -1);
		}
	}
}
