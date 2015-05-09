using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    public bool hasAI;

    public void OnMouseDown()
    {
        if(hasAI)
        {
            StaticInfo.AIEnabled = true;
        }
        else
        {
            StaticInfo.AIEnabled = false;
        }

        Application.LoadLevel("Game");
    }
}
