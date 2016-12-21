using UnityEngine;
using System.Collections;

public class ThankYou : MonoBehaviour {
	public WhiteFade wf;
	bool isFadeIn = false;
	// Use this for initialization
	void Start () {
		
	}
	public void End(){
		Debug.Log ("aa");
		if (isFadeIn == true) {
			wf.FadeOutCoroutineFast (()=>{Application.LoadLevel ("RankingEntry");});
		}
	}
	// Update is called once per frame
	void Update () {
		if (wf.color > 0 && isFadeIn == false) {
			wf.FadeIn (3);
		} else {
			isFadeIn = true;

		}
	}
}
