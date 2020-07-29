using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPieceScript : MonoBehaviour {

    // used for pathfinding algorithm
    private int weight;

    public int GetTileWeight()
    {
        return weight;
    }

    public void BuildSomethingHere()
    {
        weight = 1;
    }

    private void Start()
    {
        weight = 0;
    }

}
