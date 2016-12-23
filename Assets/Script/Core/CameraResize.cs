using UnityEngine;
using System.Collections;

public class CameraResize : MonoBehaviour {

	private Camera cam;
	// 画像のサイズ
	void Awake () {
		// カメラコンポーネントを取得します
		cam = GetComponent<Camera> ();
		//Debug.Log ((float)Screen.width/Screen.height);

		//Debug.Log (Screen.width+"aa"+Screen.height);
		if (SystemInfo.deviceModel.Contains ("iPad")) {
			//cam = GetComponent<Camera> ();
			// カメラのorthographicSizeを設定
			cam.orthographicSize = 1f;
			cam.rect = new Rect (0f, 0f, 1f, 0.75f);
		} else {
			if (Screen.height * 16 - Screen.width * 9>200) {
				Debug.Log (((float)Screen.width*9) /((float)Screen.height * 16));
			//	Debug.Log (Screen.width * 9);

				cam.rect = new Rect (0f, 0f, 1f,((float)Screen.width*9) /((float)Screen.height * 16));
			}
		}
	
	}
}
