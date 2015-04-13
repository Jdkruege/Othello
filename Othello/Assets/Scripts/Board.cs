using UnityEngine;
using System.Collections;

public class Board {

    public pieces[,] board;
    public enum pieces {white, black};

    public void start()
    {
        ResetBoard();
    }
    
    public void update()
    {

    }

    public void AvailableMoves()
    {

    }

    public void ResetBoard()
    {
        board = new pieces[8,8];

        board[3, 3] = pieces.black;
        board[3, 4] = pieces.white;
        board[4, 3] = pieces.white;
        board[4, 4] = pieces.black;
    }
}
