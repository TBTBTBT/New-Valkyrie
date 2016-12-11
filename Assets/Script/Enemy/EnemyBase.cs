using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBase : MonoBehaviour {
	public GameObject hit;
	protected int hp = 2;
	public int value = 0;
	protected int maxHp = 2;
	protected int hittime = 0;
	protected Player player;
	protected bool isHit = false;
	protected bool direction;
	protected Rigidbody2D rg;
	protected SpriteRenderer sprite;
	Transform child;
	protected List<int> id;
	public int score = 100;
	[System.NonSerialized]public int atk = 1;
	bool alive = true;
	protected int level=1;
	// Use this for initialization
	void Start () {
		id = new List<int>();
		rg=GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		sprite = GetComponent<SpriteRenderer> ();

		if(transform.childCount>0)child = transform.GetChild(0);
		sprite.color = new Color(0.5f,0.5f,0.5f);
		maxHp = (int)transform.position.z;
		hp = maxHp;
		level =  1 +(int)(transform.position.z/20f);
		if (level > 5)
			level = 5;
		//level = 5;
		atk =1 + (int)(transform.position.z/5f);
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		ChangeDirectionToPlayer ();
		OverrideStart ();

	}
	protected virtual void OverrideStart(){}
	protected virtual void OverrideUpdate(){}
	// Update is called once per frame
	void FixedUpdate () {
		if (hittime > 0) {
			
			hittime++;
			if (hittime > 5) {
				sprite.color = new Color(0.5f,0.5f,0.5f);
			}
			if(hittime>30){
				hittime = 0;
				id.Clear ();
			}

		}
		//if (hp <= 0) {
			
		//}
		OverrideUpdate ();
	
	}
	protected virtual void OverrideOnTriggerStay2D(Collider2D c){}
	void OnTriggerStay2D(Collider2D c){
		if (c.tag == "Bullet"&&alive == true){//&& hittime == 0) {
			bool isnot = true;
				foreach (int n in id) {
					if (c.GetInstanceID () == n)
						isnot = false;
				}
			if (isnot == true) {
				id.Add (c.GetInstanceID());
				c.GetComponent<BulletBase> ().HitEnemy ();
				EventManager.Invoke (ref EventManager.OnEnemyHit);
				hp -= player.RetAtk ();
				hittime = 1;
				if (hp > 0) {
					sprite.color = Color.red;

				} else {
					c.GetComponent<BulletBase> ().DestroyEnemy (value);
					EventManager.InvokeIntArg (ref EventManager.OnDestroyEnemy, score);
					Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
					Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
					Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
					Destroy (this.gameObject);
					alive = false;
				}
			}

		}
		OverrideOnTriggerStay2D (c);
	}
	void OnTriggerExit2D(Collider2D c){
		if (c.tag == "Bullet") {
			int ind = -1;
			for (int n = 0; n < id.Count; n++) {
				if (c.GetInstanceID () == id [n]) {
					if (ind == -1)
						ind = n;
					else
						Debug.Log ("InsID Error");
				}
			}
				Debug.Log (ind);
			if (ind != -1 && id.Count > ind) {
				id.RemoveAt (ind);
			}
		}
	}
	public int RetHP(){
		return hp;
	}
	public int RetMaxHP(){
		return maxHp;
	}
	protected void ChangeDirection(bool t){
		if (t == true) {
			transform.localScale = new Vector2 (2,2);
			direction = true;
			if(transform.childCount>0)child.localScale = new Vector2 (1,1);
		} else {
			transform.localScale = new Vector2 (-2,2);
			direction = false;
			if(transform.childCount>0)child.localScale = new Vector2 (-1,1);
		}
	}
	protected void ChangeDirectionToPlayer(){
		if (player.transform.position.x > transform.position.x) {
			transform.localScale = new Vector2 (2,2);
			if(transform.childCount>0)child.localScale = new Vector2 (1,1);
			direction = true;
		} else {
			transform.localScale = new Vector2 (-2,2);
			if(transform.childCount>0)child.localScale = new Vector2 (-1,1);
			direction = false;
		}
	}
}
