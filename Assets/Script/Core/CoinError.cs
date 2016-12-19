using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinError : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if(Statics.coin<10 )text.text = "コインが足りません";
		else text.text = "";
	}
}
