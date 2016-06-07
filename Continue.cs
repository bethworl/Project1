using UnityEngine;
using System.Collections;

public class Continue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("tab"))
        {
            NextLevelGo();
        }
	}

    void NextLevelGo()
    {
        Application.LoadLevel(1);
    }
}
