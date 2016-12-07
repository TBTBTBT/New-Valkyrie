using UnityEngine;
using System.Collections;

public class TouchAttackButtonManager : MonoBehaviour {
	Camera cam;
	int touchNum = -1;
	public Sprite buttonNormal;
	public Sprite buttonPush;
	SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		EventManager.OnTouchBegin.AddListener(BeginTouchButton);
		EventManager.OnTouchEnd.AddListener(EndTouchButton);
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		sprite = GetComponent<SpriteRenderer> ();
		sprite.sprite = buttonNormal;
	}
	
	// Update is called once per frame
	void BeginTouchButton (int num) {
		Vector2 touchPos = TouchInput.GetTouchWorldPosition (cam, num);
		if (touchPos.x < transform.position.x + 0.24f && touchPos.x > transform.position.x - 0.24f) {
			EventManager.Invoke (ref EventManager.OnAtkBegin);
			touchNum = num;
			sprite.sprite = buttonPush;
		}

	}
	void EndTouchButton (int num){
		if (num == touchNum) {
			EventManager.Invoke (ref EventManager.OnAtkEnd);
			touchNum = -1;
			sprite.sprite = buttonNormal;
		}

	}
}
