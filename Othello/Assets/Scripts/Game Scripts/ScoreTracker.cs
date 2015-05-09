using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public GameObject info;
	
	// Update is called once per frame
	public void Update () {
        BoardState boardState = info.GetComponent<BoardState>();

        GetComponent<Text>().text = "Black: " + boardState.blackPieces + "\nWhite: " + boardState.whitePieces;
	}
}
