using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinText : MonoBehaviour {

    public GameObject info;

    public void Update()
    {
        if(info.GetComponent<Game>().gameFinished)
        {
            if(info.GetComponent<BoardState>().blackPieces > info.GetComponent<BoardState>().whitePieces)
            {
                GetComponent<Text>().text = "Black wins!";
            }
            else if(info.GetComponent<BoardState>().whitePieces > info.GetComponent<BoardState>().blackPieces)
            {
                GetComponent<Text>().text = "White wins!";
            }
            else
            {
                GetComponent<Text>().text = "Draw!";
            }
        }
    }

}
