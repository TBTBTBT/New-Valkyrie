using UnityEngine;
using System.Collections;

public class TouchSlideManager : MonoBehaviour {
	Camera cam;
	Vector3 touchPos;
	Vector3 touchPosOrigin;
	int touchNum;
	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		EventManager.OnTouchBegin.AddListener (SetTouchPos);
		EventManager.OnTouchMove.AddListener (MoveTouchPos);
		EventManager.OnTouchEnd.AddListener (EndTouch);
	}
	void SetTouchPos(int num){
		if (TouchInput.GetTouchWorldPosition (cam, num).x < 0) {
			touchPos = TouchInput.GetTouchWorldPosition (cam, num);
			touchPosOrigin = touchPos;
			touchNum = num;
		}
	}
	void EndTouch(int num){
		//|| num == 0 && Input.touchCount == 1
		if (touchNum == num) {
			transform.position = new Vector3 (-1.1f ,-0.8f, -5);
			touchNum = -1;
		}
	
	}
	void MoveTouchPos(int num){
		if (touchNum == num) {
			if (touchPosOrigin.x < 0) {//left of screen
				float length = TouchInput.GetTouchWorldPosition (cam,num).x - touchPos.x;
				if (length > 0.2f) {
					length = 0.2f;
					touchPos.x = TouchInput.GetTouchWorldPosition (cam, num).x - 0.2f;  
				}
				if (length < -0.2f) {
					length = -0.2f;
					touchPos.x = TouchInput.GetTouchWorldPosition (cam, num).x + 0.2f;  
				}
				transform.position = new Vector3 (-1.1f + length, -0.8f, -5);
			}
		}
	}
	// Update is called once per frame
}
