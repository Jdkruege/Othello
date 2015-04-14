using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public int i, j;

    public void OnMouseDown()
    {
        if(Board.ValidMove(i, j))
        {
            GameObject spawnedPiece;
            Master master = GameObject.Find("Master").GetComponent<Master>();

            if(Game.currentPlayer == Game.player.white)
            {
                spawnedPiece = Instantiate(master.whitePiece);
            }
            else
            {
                spawnedPiece = Instantiate(master.blackPiece);
                
            }

            Vector3 pos = this.transform.position;

            pos.y += 2;

            spawnedPiece.transform.position = pos;

            Game.flipPlayers();

            gameObject.SetActive(false);
        }

        else
        {
            Debug.Log("Invalid Move");
        }
        
    }

}
