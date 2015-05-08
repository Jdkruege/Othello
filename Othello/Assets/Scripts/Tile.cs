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
        if(info.GetComponent<BoardState>().ValidMove(i, j))
        {
            GameObject spawnedPiece = Instantiate(info.GetComponent<Resources>().Piece);

            if(info.GetComponent<Game>().IsBlacksTurn())
            {
                spawnedPiece.transform.Rotate(0, 0, 180);
            }

            Vector3 pos = this.transform.position;

            pos.y += 2;

            spawnedPiece.transform.position = pos;

            info.GetComponent<Board>().PlacePiece(i, j, spawnedPiece);
            info.GetComponent<BoardState>().PlacePiece(i, j);

            info.GetComponent<Game>().flipPlayers();

            gameObject.SetActive(false);
        }

        else
        {
            Debug.Log("Invalid Move");
        }
        
    }

}
