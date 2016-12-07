using UnityEngine;
using System.Collections;

public class TouchInvoke : MonoBehaviour {
	
	void Update () {
		int touchNum = 1;
		#if UNITY_EDITOR
		# else

		touchNum = Input.touchCount;

		#endif
		for(int i = 0;i < touchNum; i++){
			if (TouchInput.GetTouch(i) == TouchInfo.Began)EventManager.InvokeIntArg  (ref EventManager.OnTouchBegin,TouchInput.GetID(i));
			if (TouchInput.GetTouch(i) == TouchInfo.Moved)EventManager.InvokeIntArg  (ref EventManager.OnTouchMove,TouchInput.GetID(i));
			if (TouchInput.GetTouch(i) == TouchInfo.Ended)EventManager.InvokeIntArg  (ref EventManager.OnTouchEnd,TouchInput.GetID(i));
			}
	}
}
