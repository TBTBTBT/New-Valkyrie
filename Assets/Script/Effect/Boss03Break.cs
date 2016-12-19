using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss03Break : MonoBehaviour {
	int actTime = 0;
	Vector2 pos;
	Player player;
	public GameObject option;
	public Sprite fall;
	public List<Sprite> normal;
	SpriteRenderer sprite;
	int num;
	int time;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		pos = transform.position;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		num = 0;
		time = 0;
	}
	protected void ChangeDirectionToPlayer(){
		if (player.transform.position.x > transform.position.x) {
			transform.localScale = new Vector2 (2,2);
		} else {
			transform.localScale = new Vector2 (-2,2);
		}
	}
	void Animation(List<Sprite> s,bool loop){
		if (time < 12)
			time++;
		if (time >= 12) {
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
	// Update is called once per frame
	void Update () {
		
		actTime++;
		if (actTime > 150 &&  170 > actTime) {
			transform.position =new Vector2 (pos.x+Mathf.Sin(actTime * 80*Mathf.PI/180)*0.03f,transform.position.y);
		}
		if (actTime > 170) {
			//sprite.sprite = normal[0];
			ChangeDirectionToPlayer ();
			Animation (normal,true);
		}
		if (actTime > 210) {
			Instantiate (option, transform.position, Quaternion.identity);
			EventManager.Invoke (ref EventManager.OnDestroyBoss03Break);
			Destroy (this.gameObject);
		}
	}
}
