using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NewOption : MonoBehaviour {
	Player player;
	//GameObject parent;
	public GameObject bullet;

	public List<Sprite> attack;
	public List<Sprite> normal;
	SpriteRenderer sprite;
	int num;
	int animationNum;
	int time;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		sprite = GetComponent<SpriteRenderer> ();
		Animation (normal, true);
		animationNum = 0;
		EventManager.OnPlayerAttacked.AddListener (Attack);
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
	void ChangeAnimation(int anum,List<Sprite> s){
		animationNum = anum;
		num = 0;
		time = 12;
		if (s.Count > num) {
			sprite.sprite = s [0];
		}
	}
	void Animation(List<Sprite> s,bool loop,int next,List<Sprite> ns){
		if (time < 12)
			time++;
		if (time >= 12) {
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
	void Attack(){
		
		if(player.RetHP()>0){
			ChangeAnimation (1,attack);
			GameObject b = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
			int dir = transform.localScale.x>0?1:-1;
			if (b.GetComponent<BulletBase> ())
				b.GetComponent<BulletBase> ().SetPower (player.RetCharge(),dir);
		}
	}
	protected void ChangeDirectionToPlayer(){
		if (player.transform.position.x > transform.position.x) {
			transform.localScale = new Vector2 (2,2);
		} else {
			transform.localScale = new Vector2 (-2,2);
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (animationNum == 0)
			Animation (normal, true);
		if (animationNum == 1)
			Animation (attack,false,0,normal);
		ChangeDirectionToPlayer ();
		float dir = player.transform.localScale.x>0?-0.5f:0.5f;
		transform.position =new Vector2 (transform.position.x+((player.transform.position.x+dir) - transform.position.x)/20,transform.position.y);

	}
}
