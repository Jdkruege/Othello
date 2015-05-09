using UnityEngine;
using System.Collections;

public class ChangeAILevel : MonoBehaviour {

    public bool increase;

    public void OnMouseDown()
    {
        if(increase)
        {
            StaticInfo.IncreaseLevel();
        }
        else
        {
            StaticInfo.DecreaseLevel();
        }
    }

    public void Update()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        if((increase && StaticInfo.AILevel == 10) || (!increase && StaticInfo.AILevel == 1))
        {
            color.a = 0.25f;        
        }
        else
        {
            color.a = 1;
        }

        GetComponent<SpriteRenderer>().color = color;
    }
}
