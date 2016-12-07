using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemy04Animation : MonoBehaviour {
	public List<Sprite>normal;
	public List<Sprite>jump;
	// Use this for initialization
	SpriteRenderer sprite;
	int num;
	int time;
	[System.NonSerialized]public int animationNum;
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
		if(animationNum == 0)Animation (normal,true);
		if(animationNum == 1)Animation (jump,false);
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
	public void Land(){
		if(animationNum!=0)ChangeAnimation (0,normal);
	}
	public void Jump(){
		ChangeAnimation (1,jump);
	}
	void ChangeAnimation(int anum,List<Sprite> s){
		animationNum = anum;
		num = 0;
		time = timeMax;
		if (s.Count > num) {
			sprite.sprite = s [0];
		}
	}
}
