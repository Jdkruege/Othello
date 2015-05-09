using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoardState : MonoBehaviour {

    public Pieces[,] board;
    public enum Pieces { empty, white, black };

    public bool AIEnabled;

    public int whitePieces = 2, blackPieces = 2;

    public void Start()
    {
        ResetBoard();
    }

    public ArrayList AvailableMoves(bool isBlack)
    {
        ArrayList arr = new ArrayList();

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if ((board[i, j] == Pieces.empty) &&                    // Check if the position is even empty, if not we are already done
                   (
                   (i - 1 > -1 && (board[i - 1, j] != Pieces.empty)) ||  // North
                   (j + 1 < 8 && (board[i, j + 1] != Pieces.empty)) ||  // East
                   (i + 1 < 8 && (board[i + 1, j] != Pieces.empty)) ||  // South
                   (j - 1 > -1 && (board[i, j - 1] != Pieces.empty)) ||  // West

                   (i - 1 > -1 && j + 1 < 8 && (board[i - 1, j + 1] != Pieces.empty))  ||        // NE
                   (i + 1 < 8 && j + 1 < 8 && (board[i + 1, j + 1] != Pieces.empty))  ||        // SE
                   (i + 1 < 8 && j - 1 > -1 && (board[i + 1, j] != Pieces.empty))      ||        // SW
                   (i - 1 > -1 && j - 1 > -1 && (board[i - 1, j - 1] != Pieces.empty))) &&        // NW

                   ValidMove(i, j, isBlack))                                                             // If any of those were true, check if the move would be valid
                {
                    arr.Add(new Vector2(i, j));
                }
            }
        }
            return arr;
    }

    // Short Circuit evaluation is fun.
    public bool ValidMove(int i, int j, bool isBlack)
    {
        return ((board[i, j] == Pieces.empty)   &&
                (CheckNorth(i, j, isBlack)      ||
                CheckEast(i, j, isBlack)        ||
                CheckSouth(i, j, isBlack)       ||
                CheckWest(i, j, isBlack)        ||
                CheckNorthEast(i, j, isBlack)   ||
                CheckSouthEast(i, j, isBlack)   ||
                CheckSouthWest(i, j, isBlack)   ||
                CheckNorthWest(i, j, isBlack)));
    }

    #region Check Positions
    public bool CheckNorth(int i, int j, bool isBlack)
    {
        bool foundWhite = false, foundBlack = false;
        for (j-- ; j >= 0; j--)
        {
            if (board[i, j] == Pieces.empty) return false;
            foundBlack = foundBlack || (board[i, j] == Pieces.black);
            foundWhite = foundWhite || (board[i, j] == Pieces.white);

            if (isBlack && (foundBlack && !foundWhite)) return false;
            else if (!isBlack && (foundWhite && !foundBlack)) return false;
            else if (foundWhite && foundBlack) return true;
        }

        return false;
    }

    public bool CheckEast(int i, int j, bool isBlack)
    {
        bool foundWhite = false, foundBlack = false;
        for (i++ ; i < 8; i++)
        {
            if (board[i, j] == Pieces.empty) return false;
            foundBlack = foundBlack || (board[i, j] == Pieces.black);
            foundWhite = foundWhite || (board[i, j] == Pieces.white);

            if (isBlack && (foundBlack && !foundWhite)) return false;
            else if (!isBlack && (foundWhite && !foundBlack)) return false;
            else if (foundWhite && foundBlack) return true;
        }

        return false;
    }

    public bool CheckSouth(int i, int j, bool isBlack)
    {
        bool foundWhite = false, foundBlack = false;
        for (j++ ; j < 8; j++)
        {
            if (board[i, j] == Pieces.empty) return false;
            foundBlack = foundBlack || (board[i, j] == Pieces.black);
            foundWhite = foundWhite || (board[i, j] == Pieces.white);

            if (isBlack && (foundBlack && !foundWhite)) return false;
            else if (!isBlack && (foundWhite && !foundBlack)) return false;
            else if (foundWhite && foundBlack) return true;
        }

        return false;
    }

    public bool CheckWest(int i, int j, bool isBlack)
    {
        bool foundWhite = false, foundBlack = false;
        for (i-- ; i >= 0; i--)
        {
            if (board[i, j] == Pieces.empty) return false;
            foundBlack = foundBlack || (board[i, j] == Pieces.black);
            foundWhite = foundWhite || (board[i, j] == Pieces.white);

            if (isBlack && (foundBlack && !foundWhite)) return false;
            else if (!isBlack && (foundWhite && !foundBlack)) return false;
            else if (foundWhite && foundBlack) return true;
        }

        return false;
    }

    public bool CheckNorthEast(int i, int j, bool isBlack)
    {
        bool foundWhite = false, foundBlack = false;
        for (j-- , i++ ; j >= 0 && i < 8; j--, i++)
        {
            if (board[i, j] == Pieces.empty) return false;
            foundBlack = foundBlack || (board[i, j] == Pieces.black);
            foundWhite = foundWhite || (board[i, j] == Pieces.white);

            if (isBlack && (foundBlack && !foundWhite)) return false;
            else if (!isBlack && (foundWhite && !foundBlack)) return false;
            else if (foundWhite && foundBlack) return true;
        }

        return false;
    }

    public bool CheckSouthEast(int i, int j, bool isBlack)
    {
        bool foundWhite = false, foundBlack = false;
        for (j++, i++; j < 8 && i < 8; j++, i++)
        {
            if (board[i, j] == Pieces.empty) return false;
            foundBlack = foundBlack || (board[i, j] == Pieces.black);
            foundWhite = foundWhite || (board[i, j] == Pieces.white);

            if (isBlack && (foundBlack && !foundWhite)) return false;
            else if (!isBlack && (foundWhite && !foundBlack)) return false;
            else if (foundWhite && foundBlack) return true;
        }

        return false;
    }

    public bool CheckSouthWest(int i, int j, bool isBlack)
    {
        bool foundWhite = false, foundBlack = false;
        for (j++, i--; j < 8 && i >= 0; j++, i--)
        {
            if (board[i, j] == Pieces.empty) return false;
            foundBlack = foundBlack || (board[i, j] == Pieces.black);
            foundWhite = foundWhite || (board[i, j] == Pieces.white);

            if (isBlack && (foundBlack && !foundWhite)) return false;
            else if (!isBlack && (foundWhite && !foundBlack)) return false;
            else if (foundWhite && foundBlack) return true;
        }

        return false;
    }

    public bool CheckNorthWest(int i, int j, bool isBlack)
    {
        bool foundWhite = false, foundBlack = false;
        for (j--, i--; j >= 0 && i >= 0; j--, i--)
        {
            if (board[i, j] == Pieces.empty) return false;
            foundBlack = foundBlack || (board[i, j] == Pieces.black);
            foundWhite = foundWhite || (board[i, j] == Pieces.white);

            if (isBlack && (foundBlack && !foundWhite)) return false;
            else if (!isBlack && (foundWhite && !foundBlack)) return false;
            else if (foundWhite && foundBlack) return true;
        }

        return false;
    }
    #endregion

    #region Flip Positions
    public void FlipNorth(int i, int j, bool isBlack)
    {
        for (j--; j >= 0; j--)
        {
            if (isBlack && board[i, j] == Pieces.black) return;
            if (!isBlack && board[i, j] == Pieces.white) return;
            
            if(!AIEnabled) GetComponent<Board>().FlipPiece(i, j);
            FlipPiece(i, j);
        }
    }

    public void FlipEast(int i, int j, bool isBlack)
    {
        for (i++; i < 8; i++)
        {
            if (isBlack && board[i, j] == Pieces.black) return;
            if (!isBlack && board[i, j] == Pieces.white) return;

            if (!AIEnabled) GetComponent<Board>().FlipPiece(i, j);
            FlipPiece(i, j);
        }
    }

    public void FlipSouth(int i, int j, bool isBlack)
    {
        for (j++; j < 8; j++)
        {
            if (isBlack && board[i, j] == Pieces.black) return;
            if (!isBlack && board[i, j] == Pieces.white) return;

            if (!AIEnabled) GetComponent<Board>().FlipPiece(i, j);
            FlipPiece(i, j);
        }
    }

    public void FlipWest(int i, int j, bool isBlack)
    {
        for (i--; i >= 0; i--)
        {
            if (isBlack && board[i, j] == Pieces.black) return;
            if (!isBlack && board[i, j] == Pieces.white) return;

            if (!AIEnabled) GetComponent<Board>().FlipPiece(i, j);
            FlipPiece(i, j);
        }
    }

    public void FlipNorthEast(int i, int j, bool isBlack)
    {
        for (j--, i++; j >= 0 && i < 8; j--, i++)
        {
            if (isBlack && board[i, j] == Pieces.black) return;
            if (!isBlack && board[i, j] == Pieces.white) return;

            if (!AIEnabled) GetComponent<Board>().FlipPiece(i, j);
            FlipPiece(i, j);
        }
    }

    public void FlipSouthEast(int i, int j, bool isBlack)
    {
        for (j++, i++; j < 8 && i < 8; j++, i++)
        {
            if (isBlack && board[i, j] == Pieces.black) return;
            if (!isBlack && board[i, j] == Pieces.white) return;

            if (!AIEnabled) GetComponent<Board>().FlipPiece(i, j);
            FlipPiece(i, j);
        }
    }

    public void FlipSouthWest(int i, int j, bool isBlack)
    {
        for (j++, i--; j < 8 && i >= 0; j++, i--)
        {
            if (isBlack && board[i, j] == Pieces.black) return;
            if (!isBlack && board[i, j] == Pieces.white) return;

            if (!AIEnabled) GetComponent<Board>().FlipPiece(i, j);
            FlipPiece(i, j);
        }
    }

    public void FlipNorthWest(int i, int j, bool isBlack)
    {
        for (j--, i--; j >= 0 && i >= 0; j--, i--)
        {
            if (isBlack && board[i, j] == Pieces.black) return;
            if (!isBlack && board[i, j] == Pieces.white) return;

            if (!AIEnabled) GetComponent<Board>().FlipPiece(i, j);
            FlipPiece(i, j);
        }
    }
    #endregion

    public void PlacePiece(int i, int j, bool isBlack)
    {
        if(isBlack)
        {
            board[i, j] = Pieces.black;
            blackPieces++;
        }
        else
        {
            board[i, j] = Pieces.white;
            whitePieces++;
        }

        if(CheckNorth(i, j, isBlack)) FlipNorth(i, j, isBlack);
        if(CheckEast(i, j, isBlack)) FlipEast(i, j, isBlack);
        if(CheckSouth(i, j, isBlack)) FlipSouth(i, j, isBlack);
        if(CheckWest(i, j, isBlack)) FlipWest(i, j, isBlack);

        if(CheckNorthEast(i, j, isBlack)) FlipNorthEast(i, j, isBlack);
        if(CheckSouthEast(i, j, isBlack)) FlipSouthEast(i, j, isBlack);
        if(CheckSouthWest(i, j, isBlack)) FlipSouthWest(i, j, isBlack);
        if(CheckNorthWest(i, j, isBlack)) FlipNorthWest(i, j, isBlack);
    }

    public void FlipPiece(int i, int j)
    {
        if(board[i, j] == Pieces.black)
        {
            board[i, j] = Pieces.white;
            whitePieces++;
            blackPieces--;
        }
        else if (board[i, j] == Pieces.white)
        {
            board[i, j] = Pieces.black;
            blackPieces++;
            whitePieces--;
        }
    }

    public void ResetBoard()
    {
        board = new Pieces[8, 8];

        board[3, 3] = Pieces.white;
        board[3, 4] = Pieces.black;
        board[4, 3] = Pieces.black;
        board[4, 4] = Pieces.white;

    }

    public BoardState CreateCopy()
    {
        BoardState copy = Instantiate(GetComponent<BoardState>()); ;
        
        copy.ResetBoard();

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                copy.board[i, j] = board[i, j];
            }
        }

        copy.whitePieces = whitePieces;
        copy.blackPieces = blackPieces;

        return copy;
    }
}
