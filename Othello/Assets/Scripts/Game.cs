using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour{


    public player currentPlayer;
    public bool AIEnabled;
    public enum player {black, white};

    private int noMoveCount = 0;
    public bool gameFinished = false;
    public int depth = 1;
    public float AITurnDelay;
    public float elapsedTime;

    public void Start()
    {
        currentPlayer = player.black;
    }
    
    public void Update()
    {
        elapsedTime += Time.deltaTime;

        if(currentPlayer == player.white && AIEnabled && elapsedTime > AITurnDelay)
        {

            Vector2 move = AI.MakeDecision(GetComponent<BoardState>(), depth);

            if (move.x >= 0 && move.y >= 0)
            {
                GameObject.Find("Row " + move.x).transform.FindChild("Position " + move.y).GetComponent<Tile>().SpawnPiece(false);
            }

            FlipPlayers();        
        }
        
    }

    public void FlipPlayers()
    {
        if(noMoveCount > 1)
        {
            gameFinished = true;
            return;
        }

        if(currentPlayer == player.black)
        {
            currentPlayer = player.white;
            elapsedTime = 0;
        }
        else
        {
            currentPlayer = player.black;
        }

        if(GetComponent<BoardState>().AvailableMoves(IsBlacksTurn()).Count == 0)
        {
            noMoveCount++;
            FlipPlayers(); 
        }
        else
        {
            noMoveCount = 0;
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
