using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour {

    public GameObject[] objectsToActivate;

    public void activate()
    {
        foreach(GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
    }
}
