using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	void Start () {
		EventManager.OnTouchBegin.AddListener(StartGame);
	}

	// Update is called once per frame
	void StartGame (int num) {
		if (!Application.isShowingSplashScreen) {
			//スプラッシュ表示後
			Application.LoadLevel ("Stage01");
		}
	}
}
