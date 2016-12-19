using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManagerEntry : MonoBehaviour {
//	int score;
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = ""+Statics.score;
	}

}
