using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour{

    public GameObject[,] board;

    public GameObject piece33;
    public GameObject piece34;
    public GameObject piece43;
    public GameObject piece44;

    public void Start()
    {
        ResetBoard();
    }

    public void PlacePiece(int i, int j, GameObject toPlace)
    {
        board[i, j] = toPlace;
    }

    public void FlipPiece(int i, int j)
    {
        board[i, j].transform.Rotate(0, 0 , 180);
    }

    public void ResetBoard()
    {
        board = new GameObject[8,8];

        board[3, 3] = piece33;
        board[3, 4] = piece34;
        board[4, 3] = piece43;
        board[4, 4] = piece44;

    }
}
