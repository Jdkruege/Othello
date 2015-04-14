using UnityEngine;
using System.Collections;

public static class Board {

    private static pieces[,] board;
    public enum pieces {empty, white, black};

    public static void AvailableMoves()
    {

    }

    public static bool ValidMove(int i, int j)
    {
        if(board[i, j] == pieces.empty)
        {
            if((i-1 >= 0) && (board[i - 1, j] != pieces.empty))
            {
                board[i, j] = pieces.white;
                return true;
            }
            else if ((i+1 <= 7) && (board[i + 1, j] != pieces.empty))
            {
                board[i, j] = pieces.white;
                return true;
            }
            else if ((j-1 >= 0) && (board[i, j - 1] != pieces.empty))
            {
                board[i, j] = pieces.white;
                return true;
            }
            else if ((j+1 <= 7) && (board[i, j + 1] != pieces.empty))
            {
                board[i, j] = pieces.white;
                return true;
            }
        }

        return false;
    }

    public static void ResetBoard()
    {
        board = new pieces[8,8];

        board[3, 3] = pieces.black;
        board[3, 4] = pieces.white;
        board[4, 3] = pieces.white;
        board[4, 4] = pieces.black;

    }
}
