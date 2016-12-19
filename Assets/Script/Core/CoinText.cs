using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinText : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		Statics.coin = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "<color=#ffff00>coin: </color>" + Statics.coin;
	}
}
