using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	void Start () {
		//EventManager.OnTouchBegin.AddListener(StartGame);
		Statics.Reset();
		Statics.Load ();
	}

	// Update is called once per frame
	public void StartGame (int num) {
		if (!Application.isShowingSplashScreen) {
			//スプラッシュ表示後
			if (Statics.isWatchOpening == false) {
				Statics.isWatchOpening = true;
				Application.LoadLevel ("Opening");
			} else {
				Application.LoadLevel ("Stage01");
			}
		}
	}
	public void GoRanking (int num) {
		if (!Application.isShowingSplashScreen) {
			//スプラッシュ表示後
			Application.LoadLevel ("Ranking");
		}
	}
}
