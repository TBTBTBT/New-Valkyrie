using UnityEngine;
using System.Collections;

public class InfoManager : MonoBehaviour {
	TextMesh text;
	int time = 0;
	// Use this for initialization
	void Start () {
		time = 60;
		text = GetComponent<TextMesh> ();
		EventManager.OnPlayerMissed.AddListener (GameOver);
	}
	
	// Update is called once per frame
	void Update () {
		if (time > 0) {
			time--;

		} else {
			text.text = "";
		}
	}
	void GameOver(){
		text.color = Color.red;
		time = 180;
		text.text = "Game Over";
	}
}
