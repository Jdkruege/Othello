using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public int i, j;

    private GameObject info;

    public void Start()
    {
        info = GameObject.Find("Info");
    }

    public void OnMouseDown()
    {
        bool isBlack = info.GetComponent<Game>().IsBlacksTurn();

        if(info.GetComponent<BoardState>().ValidMove(i, j, isBlack))
        {
            SpawnPiece(isBlack);

            info.GetComponent<Game>().FlipPlayers();
        }

        else
        {
            Debug.Log("Invalid Move");
        }
        
    }

    public void SpawnPiece(bool isBlack)
    {
        GameObject spawnedPiece = Instantiate(info.GetComponent<Resources>().Piece);

        if (isBlack)
        {
            spawnedPiece.transform.Rotate(0, 0, 180);
        }

        Vector3 pos = this.transform.position;

        pos.y += 0.5f;

        spawnedPiece.transform.position = pos;

        info.GetComponent<Board>().PlacePiece(i, j, spawnedPiece);
        info.GetComponent<BoardState>().PlacePiece(i, j, isBlack);

        gameObject.SetActive(false);
    }

}
