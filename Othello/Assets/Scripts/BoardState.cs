using UnityEngine;
using System.Collections;

public class BoardState : MonoBehaviour {

    private Pieces[,] board;
    public enum Pieces { empty, white, black };

    public void Start()
    {
        ResetBoard();
    }

    // Fix this up
    public bool ValidMove(int i, int j)
    {
        if (board[i, j] == Pieces.empty)
        {
            if ((i - 1 >= 0) && (board[i - 1, j] != Pieces.empty))
            {                
                return true;
            }
            else if ((i + 1 <= 7) && (board[i + 1, j] != Pieces.empty))
            {                
                return true;
            }
            else if ((j - 1 >= 0) && (board[i, j - 1] != Pieces.empty))
            {                
                return true;
            }
            else if ((j + 1 <= 7) && (board[i, j + 1] != Pieces.empty))
            {
                return true;
            }
        }
        return false;
    }

    public void PlacePiece(int i, int j)
    {
        if(gameObject.GetComponent<Game>().IsBlacksTurn())
        {
            board[i, j] = Pieces.black;
        }
        else
        {
            board[i, j] = Pieces.white;
        }
        
    }

    public void ResetBoard()
    {
        board = new Pieces[8, 8];

        board[3, 3] = Pieces.black;
        board[3, 4] = Pieces.white;
        board[4, 3] = Pieces.white;
        board[4, 4] = Pieces.black;

    }
}
