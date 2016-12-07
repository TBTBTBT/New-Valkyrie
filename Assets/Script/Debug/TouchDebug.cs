using UnityEngine;
using System.Collections;

public class TouchDebug : MonoBehaviour {

	Camera cam;
	int touchNum = -1;

	TextMesh text;
	// Use this for initialization
	void Start () {
		EventManager.OnTouchBegin.AddListener(BeginTouchButton);
		EventManager.OnTouchEnd.AddListener(EndTouchButton);
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		text = GetComponent<TextMesh> ();
		text.text = "";
	}
	// Update is called once per frame
	void BeginTouchButton (int num) {
		text.text += num;

	}
	void MoveTouchButton (int num) {


	}
	void EndTouchButton (int num){
		text.text += num;
	}
}
