using UnityEngine;
using System.Collections;

public class ButtonGamePlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GamePlayClick()
    {
        print("nect ");
        Application.LoadLevel("Level01");
    }
}
