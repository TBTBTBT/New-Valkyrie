using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
//	int score;
	TextMesh text;
	// Use this for initialization
	void Start () {
		Statics.score = 0;
		text = GetComponent<TextMesh> ();
		text.text = "0";
		EventManager.OnDestroyEnemy.AddListener (Score);
	}
	void Score(int s){
		if(Statics.score < 9999999999)Statics.score += (ulong)(s * Statics.combo);
		if (Statics.score > 9999999999)
			Statics.score = 9999999999;
		text.text = "" + Statics.score;
	}

}
