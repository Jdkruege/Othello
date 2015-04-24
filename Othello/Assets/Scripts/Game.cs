using UnityEngine;
using System.Collections;

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
