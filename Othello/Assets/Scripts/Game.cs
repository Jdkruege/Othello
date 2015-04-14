using UnityEngine;
using System.Collections;

public static class Game {


    public static player currentPlayer;
    public enum player {white, black};

    public static void flipPlayers()
    {
        if(currentPlayer == player.white)
        {
            currentPlayer = player.black;
        }
        else
        {
            currentPlayer = player.white;
        }
    }

}
