using UnityEngine;
using System.Collections;
//0 hp
//1 charge+atk
//2 spd
//3 size
//4 option
//5 muteki special
public class BulletBase : MonoBehaviour {
	protected Rigidbody2D rg;
	protected GameObject player;
	protected float pow = 0;
	int cantCatchTime = 0;
	int level;
	int value;
	protected SpriteRenderer sprite;
	// Use this for initialization
	protected virtual void OverrideStart (){}
	void Awake () {
		rg = GetComponent<Rigidbody2D> ();


	}
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		sprite = GetComponent<SpriteRenderer> ();
		OverrideStart ();
		level = 0;
		float size = player.GetComponent<Player>().RetSize();
		transform.localScale = new Vector2 (size, size);
	//	if(Statics.combo>=25)transform.localScale = new Vector2 (6+size, 6+size);
	//	else if(Statics.combo>=20)transform.localScale = new Vector2 (5+size, 5+size);
	//	else if(Statics.combo>=15)transform.localScale = new Vector2 (4+size, 4+size);
	//	else if(Statics.combo>=10)transform.localScale = new Vector2 (3+size, 3+size);
		value = -1;//Random.Range (0, 3);
	}
	protected virtual void OverrideFixedUpdate(){}
	protected virtual void OverrideSetVelocity(int dir){}
	public void HitEnemy(){
		/*
		if(level<5)level++;
		//if (level > 5)
		//	level = 5;
		//float c =level * 0.1f;
		//if(value == 0)sprite.color = new Color(0.1f + c,0.3f + c*2,0.1f + c); 
		//if(value == 1)sprite.color = new Color(0.3f + c * 2,0.1f + c,0.1f + c); 
		//if(value == 2)sprite.color = new Color(0.1f + c,0.1f + c,0.3f + c * 2); 
		*/
		//if(level<5)level++;
		//if (level > 5)level = 5;


		OverrideHitEnemy ();
	}
	public void DestroyEnemy(int v){
		cantCatchTime = 20;
		if(level<5)level++;
		if (level > 5)
			level = 5;
		if(v!=-1)value = v;
		float c =level * 0.1f;
		if(value == 0)sprite.color = new Color(0.4f - c/1.25f,0.5f + c * 2,0.4f - c/1.25f); 
		if(value == 1)sprite.color = new Color(0.5f + c*2,0.4f - c/1.25f,0.4f - c/1.25f); 
		if(value == 2)sprite.color = new Color(0.4f - c/1.25f,0.4f - c/1.25f,0.5f + c * 2);
		if(value == 3)sprite.color = new Color(0.5f + c * 2,0.5f + c * 2,0.4f - c/1.25f);
		if(value == 4)sprite.color = new Color(0.4f - c/1.25f,0.4f - c/1.25f,0.4f - c/1.25f);
		/*if(value == 0)sprite.color = new Color(0.4f,1f ,0.4f); 
		if(value == 1)sprite.color = new Color(1f,0.4f ,0.4f); 
		if(value == 2)sprite.color = new Color(0.4f,0.4f ,1f);
		if(value == 3)sprite.color = new Color(1f,1f ,0.4f);*/
	}
	public virtual void OverrideHitEnemy(){}
	// Update is called once per frame
	void FixedUpdate () {
		if(cantCatchTime <25)cantCatchTime++;
		Grav ();
		OverrideFixedUpdate ();
	}

	protected virtual void Grav(){}
	public void SetPower(float p,int dir){
		pow = p;
		OverrideSetVelocity (dir);
	}
	void OnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Player" && cantCatchTime >= 20) {
			c.GetComponent <Player>().HitBullet(value,level);
			Destroy (this.gameObject);
		}
	}
}
