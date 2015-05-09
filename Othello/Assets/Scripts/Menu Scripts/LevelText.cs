using UnityEngine;
using System.Collections;

public class LevelText : MonoBehaviour {
	
    void Start()
    {
        GetComponent<MeshRenderer>().sortingLayerName = "Text";
    }

	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = "AI Level: " + StaticInfo.AILevel;
	}
}
