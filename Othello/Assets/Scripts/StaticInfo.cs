using UnityEngine;
using System.Collections;

public static class StaticInfo {

    public static bool AIEnabled = false;
    public static int AILevel = 1;

    public static void IncreaseLevel()
    {
        if(AILevel < 10)
        {
            AILevel++;
        }
    }

    public static void DecreaseLevel()
    {
        if(AILevel > 1)
        {
            AILevel--;
        }
    }
}
