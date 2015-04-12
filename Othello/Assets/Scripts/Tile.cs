using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public GameObject piece;

    public void OnMouseDown()
    {
        GameObject spawnedPiece = Instantiate(piece);

        spawnedPiece.transform.position = this.transform.position;

        spawnedPiece.transform.Translate(new Vector3(0, 2, 0));
    }

}
