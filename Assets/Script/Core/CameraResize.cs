using UnityEngine;
using System.Collections;

public class CameraResize : MonoBehaviour {

	private Camera cam;
	// 画像のサイズ
	void Awake () {
		// カメラコンポーネントを取得します


		if(SystemInfo.deviceModel.Contains ("iPad")) {
			cam = GetComponent<Camera> ();
			// カメラのorthographicSizeを設定
			cam.orthographicSize = 1f;
			cam.rect = new Rect (0f,0f, 1f, 0.75f);
		}
	
	}
}
