using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnTracker : MonoBehaviour {

    public GameObject info;

    // Update is called once per frame
    void Update()
    {
        string turn;

        if(info.GetComponent<Game>().IsBlacksTurn())
        {
            turn = "Black";
        }
        else
        {
            turn = "White";
        }

        GetComponent<Text>().text = "Turn:\n" + turn;
    }

	
}
