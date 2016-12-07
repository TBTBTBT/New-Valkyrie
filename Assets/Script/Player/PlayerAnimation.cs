using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerAnimation : MonoBehaviour {
	public List<Sprite>normal;
	public List<Sprite>jump;
	public List<Sprite>charge;
	public List<Sprite>attack;
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
		EventManager.OnJump.AddListener (Jump);
		EventManager.OnLand.AddListener (Land);
		EventManager.OnAtkBegin.AddListener (Charge);
		EventManager.OnAtkEnd.AddListener (Attack);
	}

	// Update is called once per frame
	void Update () {
		if(animationNum == 0)Animation (normal,true);
		if(animationNum == 1)Animation (jump,false);
		if(animationNum == 2)Animation (charge,false);
		if(animationNum == 3)Animation (attack,false,0,normal);
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
	void Animation(List<Sprite> s,bool loop,int next,List<Sprite> ns){
		if (time < timeMax)
			time++;
		if (time >= timeMax) {
			time = 0;
			if (s.Count <= num) {
				if (loop == true)
					num = 0;
				else {
					num = s.Count - 1;
					ChangeAnimation (next,ns);
				}
			}
			if (s.Count > num) {
				sprite.sprite = s [num];
			}
			num++;
		}
	}
	void Land(){
		if(animationNum!=2)ChangeAnimation (0,normal);
	}
	void Jump(){
		ChangeAnimation (1,jump);
	}
	void Charge(){
		ChangeAnimation (2,charge);
	}
	void Attack(){
		ChangeAnimation (3,attack);
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
