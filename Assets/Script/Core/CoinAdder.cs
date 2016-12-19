using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinAdder : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent < Text> ();
		Statics.coin+=(int)(Statics.score / 20000);
		text.text = "<color=#ffff00>coin</color><color=#44ccff> + " + (int)(Statics.score / 20000)+"</color>";
	}

}
