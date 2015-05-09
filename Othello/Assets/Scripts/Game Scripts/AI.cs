using UnityEngine;
using System.Collections;

public static class AI {

    // Checks first level and makes final call
	public static Vector2 MakeDecision(BoardState board, int depth)
    {
        depth--;
        double maxScore = double.MinValue;
        Vector2 bestMove = new Vector2(0, 0);

        ArrayList moves = board.AvailableMoves(false);

        foreach (Vector2 move in moves)
        {
            BoardState newBoard = board.CreateCopy();
            newBoard.AIEnabled = true;

            newBoard.PlacePiece((int)move.x, (int)move.y, false);

            double score = Evaluation.EvaluateBoard(newBoard, BoardState.Pieces.white, BoardState.Pieces.black);

            if(depth > 0)
            {
                score += SearchDepth(newBoard, true, -1 , depth);
            }

            if (score > maxScore)
            {
                maxScore = score;
                bestMove = move;
            }

            GameObject.Destroy(newBoard.gameObject);
        }
       
        return bestMove;
    }

    private static double SearchDepth(BoardState board, bool isBlack, int miniMaxVal, int depth)
    {
        depth--;
        if(depth<25 )Debug.Log(depth);
        double maxScore = int.MinValue;

        BoardState.Pieces myPiece;
        BoardState.Pieces opponentPiece;

        ArrayList moves = board.AvailableMoves(isBlack);

        if(isBlack)
        {
            myPiece = BoardState.Pieces.black;
            opponentPiece = BoardState.Pieces.white;
        }
        else
        {
            myPiece = BoardState.Pieces.white;
            opponentPiece = BoardState.Pieces.black;
        }

        foreach (Vector2 move in moves)
        {
            BoardState newBoard = board.CreateCopy();
            newBoard.AIEnabled = true;

            newBoard.PlacePiece((int)move.x, (int)move.y, isBlack);

            double score = Evaluation.EvaluateBoard(newBoard, myPiece, opponentPiece);

            if (depth > 0)
            {
                score += SearchDepth(newBoard, !isBlack, -1 * miniMaxVal, depth);
            }

            if (score > maxScore)
            {
                maxScore = score;
            }

            GameObject.Destroy(newBoard.gameObject);
        }

        return miniMaxVal * maxScore;
    }

   
}
