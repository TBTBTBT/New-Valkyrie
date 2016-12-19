using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyNormalAnimation : MonoBehaviour {
	public List<Sprite>normal;
	public List<Sprite>action;
	// Use this for initialization
	SpriteRenderer sprite;
	int num;
	int time;
	int animationNum;
	public int timeMax = 4;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		num = 0;
		time = 0;
		animationNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Animation (normal,true);
	}
	void Animation(List<Sprite> s,bool loop){
		if (time < timeMax)
			time++;
		if (time >= timeMax) {
			time = 0;
			if (s.Count <= num) {
				if (loop == true)
					num = 0;
				else
					num = s.Count - 1;
			}
			if (s.Count > num) {
				sprite.sprite = s [num];
			}
			num++;
		}
	}
}
