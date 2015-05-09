using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour{


    public player currentPlayer;
    public enum player {black, white};

    public void Start()
    {
        currentPlayer = player.black;
    }
    
    public void flipPlayers()
    {
        if(currentPlayer == player.black)
        {
            currentPlayer = player.white;
        }
        else
        {
            currentPlayer = player.black;
        }

        if(GetComponent<BoardState>().AvailableMoves(IsBlacksTurn()).Count == 0)
        {
            flipPlayers();
        }
    }

    public bool IsBlacksTurn()
    {
        if(currentPlayer == player.black)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
