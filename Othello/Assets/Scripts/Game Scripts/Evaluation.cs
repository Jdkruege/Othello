using UnityEngine;
using System.Collections;


public static class Evaluation{

    // Evaluation criteria adpated from: https://kartikkukreja.wordpress.com/2013/03/30/heuristic-function-for-reversiothello/

    public static double EvaluateBoard(BoardState board, BoardState.Pieces myPiece, BoardState.Pieces opponentPiece)
    {
        int my_tiles = 0, opp_tiles = 0, i, j, k, my_front_tiles = 0, opp_front_tiles = 0, x, y;
	    double p = 0, c = 0, l = 0, m = 0, f = 0, d = 0;

	    int[] X1 = {-1, -1, 0, 1, 1, 1, 0, -1};
	    int[] Y1 = {0, 1, 1, 1, 0, -1, -1, -1};

	    int[,] V = new int[8, 8]
        {
	    {20, -3, 11, 8, 8, 11, -3, 20},
    	{-3, -7, -4, 1, 1, -4, -7, -3},
    	{11, -4, 2, 2, 2, 2, -4, 11},
    	{8, 1, 2, -3, -3, 2, 1, 8},
    	{8, 1, 2, -3, -3, 2, 1, 8},
    	{11, -4, 2, 2, 2, 2, -4, 11},
    	{-3, -7, -4, 1, 1, -4, -7, -3},
    	{20, -3, 11, 8, 8, 11, -3, 20},
        };


        // Piece difference, frontier disks and disk squares
        for (i = 0; i < 8; i++)
            for (j = 0; j < 8; j++)
            {
                if (board.board[i, j] == myPiece)
                {
                    d += V[i, j];
                    my_tiles++;
                }
                else if (board.board[i, j] == opponentPiece)
                {
                    d -= V[i, j];
                    opp_tiles++;
                }
                if (board.board[i, j] != BoardState.Pieces.empty)
                {
                    for (k = 0; k < 8; k++)
                    {
                        x = i + X1[k]; y = j + Y1[k];
                        if (x >= 0 && x < 8 && y >= 0 && y < 8 && board.board[i, j] == BoardState.Pieces.empty)
                        {
                            if (board.board[i, j] == myPiece) my_front_tiles++;
                            else opp_front_tiles++;
                            break;
                        }
                    }
                }
            }
        if (my_tiles > opp_tiles)
            p = (100.0 * my_tiles) / (my_tiles + opp_tiles);
        else if (my_tiles < opp_tiles)
            p = -(100.0 * opp_tiles) / (my_tiles + opp_tiles);
        else p = 0;

        if (my_front_tiles > opp_front_tiles)
            f = -(100.0 * my_front_tiles) / (my_front_tiles + opp_front_tiles);
        else if (my_front_tiles < opp_front_tiles)
            f = (100.0 * opp_front_tiles) / (my_front_tiles + opp_front_tiles);
        else f = 0;

        // Corner occupancy
        my_tiles = opp_tiles = 0;
        if (board.board[0, 0] == myPiece) my_tiles++;
        else if (board.board[0, 0] == opponentPiece) opp_tiles++;
        if (board.board[0, 7] == myPiece) my_tiles++;
        else if (board.board[0, 7] == opponentPiece) opp_tiles++;
        if (board.board[7, 0] == myPiece) my_tiles++;
        else if (board.board[7, 0] == opponentPiece) opp_tiles++;
        if (board.board[7, 7] == myPiece) my_tiles++;
        else if (board.board[7, 7] == opponentPiece) opp_tiles++;
        c = 25 * (my_tiles - opp_tiles);

        // Corner closeness
        my_tiles = opp_tiles = 0;
        if (board.board[0, 0] == BoardState.Pieces.empty)
        {
            if (board.board[0, 1] == myPiece) my_tiles++;
            else if (board.board[0, 1] == opponentPiece) opp_tiles++;
            if (board.board[1, 1] == myPiece) my_tiles++;
            else if (board.board[1, 1] == opponentPiece) opp_tiles++;
            if (board.board[1, 0] == myPiece) my_tiles++;
            else if (board.board[1, 0] == opponentPiece) opp_tiles++;
        }
        if (board.board[0, 7] == BoardState.Pieces.empty)
        {
            if (board.board[0, 6] == myPiece) my_tiles++;
            else if (board.board[0, 6] == opponentPiece) opp_tiles++;
            if (board.board[1, 6] == myPiece) my_tiles++;
            else if (board.board[1, 6] == opponentPiece) opp_tiles++;
            if (board.board[1, 7] == myPiece) my_tiles++;
            else if (board.board[1, 7] == opponentPiece) opp_tiles++;
        }
        if (board.board[7, 0] == BoardState.Pieces.empty)
        {
            if (board.board[7, 1] == myPiece) my_tiles++;
            else if (board.board[7, 1] == opponentPiece) opp_tiles++;
            if (board.board[6, 1] == myPiece) my_tiles++;
            else if (board.board[6, 1] == opponentPiece) opp_tiles++;
            if (board.board[6, 0] == myPiece) my_tiles++;
            else if (board.board[6, 0] == opponentPiece) opp_tiles++;
        }
        if (board.board[7, 7] == BoardState.Pieces.empty)
        {
            if (board.board[6, 7] == myPiece) my_tiles++;
            else if (board.board[6, 7] == opponentPiece) opp_tiles++;
            if (board.board[6, 6] == myPiece) my_tiles++;
            else if (board.board[6, 6] == opponentPiece) opp_tiles++;
            if (board.board[7, 6] == myPiece) my_tiles++;
            else if (board.board[7, 6] == opponentPiece) opp_tiles++;
        }
        l = -12.5 * (my_tiles - opp_tiles);

        // Mobility
        my_tiles = board.AvailableMoves((myPiece == BoardState.Pieces.black)).Count;
        opp_tiles = board.AvailableMoves((myPiece != BoardState.Pieces.black)).Count;
        if (my_tiles > opp_tiles)
            m = (100.0 * my_tiles) / (my_tiles + opp_tiles);
        else if (my_tiles < opp_tiles)
            m = -(100.0 * opp_tiles) / (my_tiles + opp_tiles);
        else m = 0;

        // final weighted score
        double score = (10 * p) + (801.724 * c) + (382.026 * l) + (78.922 * m) + (74.396 * f) + (10 * d);
        return score;
    }
}
