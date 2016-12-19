using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Boss02Animation))]
//hpslime
public class Boss03 : EnemyBase {
	int actTime = 0;
	//int actNum = 0;
	int dir = 0;
	float ang = 0f;
	float maxspd = 0;
	int spddir = 0;
	float updown = 0;
	int angry = 0;
	Boss02Animation anm;
	public GameObject bullet;
	public GameObject bullet2;
	public GameObject breakobj;
	Vector3 pos;
	// Use this for initialization
	protected override void OverrideStart () {
		anm = GetComponent<Boss02Animation> ();
		maxHp += 1500*level;
		hp = maxHp;
	//	hp = 1;
		atk += 10*level;
		pos = transform.position;
	//	level = 5;
	//	angry = 1;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		ChangeDirectionToPlayer ();
		if (hp < 450 * level)
			angry = 1;
		actTime++;
		if (actTime > 120 - level * 5 - 60 * angry) {
			
			actTime = 0;

			//else if (actTime == 0)
			int ra = Random.Range(0,2);
			if(ra == 1)StartCoroutine ("Shot");
			if (ra == 0)Jump ();
				ang = 1;
		}
		Move ();
		Grav ();


	}
	void Jump(){
		
		StartCoroutine ("Shot2");
		if (updown == 0) {
			updown = 1;
			dir = 0;
			maxspd = Random.Range(3.5f,4.5f);
			if (transform.position.x <= 0)
				spddir = 1;
				
			if (transform.position.x > 0)
				spddir = -1;
		}
		//if (transform.position.x <= 0)
		//maxspd = Random.Range(0,1f + 0.5f * level);
		//if (transform.position.x > 0)
		//	maxspd = Random.Range(-1f - 0.5f * level,0);
		//Debug.Log (maxspd);
	//	aim = -1.2f;
		anm.Jump ();
		if((int)Random.Range(0,2) == 0)rg.velocity = new Vector2(maxspd ,4.4f + 0.5f * (level-1));
	}
	void Grav(){
		rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.05f -0.1f* level);
	}
	void Move(){
				rg.velocity = new Vector2 (spddir * maxspd, rg.velocity.y);

		if (maxspd > 0) {
			maxspd -= 0.1f;
			if (maxspd < 0)
				maxspd = 0;
		}
	}
	void Lander(){
		//
		if (updown > 0) {
			//
			updown = 0f;
			anm.Land ();

		}
		//transform.position = new Vector2 (transform.position.x, transform.position.y );

		rg.velocity = new Vector2(rg.velocity.x,0);
	}
	protected override void OverrideOnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Land") {
			//Debug.Log ("aa");
			Lander ();
		}
	}
	protected override void OverrideDestroy(){
	//	EventManager.Invoke (ref EventManager.OnDestroyBoss);
		GameObject o = (GameObject)Instantiate (breakobj, transform.position, Quaternion.identity);
		EventManager.InvokeGameObjectArg (ref EventManager.OnChangeBoss, o);
		EventManager.Invoke (ref EventManager.OnDestroyBoss03);
	}
	IEnumerator Shot(){
		for(int i=0;i<4 + level;i++){
			anm.Attack ();
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (direction == true?transform.position.x +0.2f:transform.position.x -0.2f,transform.position.y,0),Quaternion.identity);
			b.GetComponent<Boss03Bullet> ().Direction(direction,1+i);
			EventManager.Invoke (ref EventManager.OnFire);
			yield return new WaitForSeconds (0.25f-0.03f * level);
		}
	}
	IEnumerator Shot2(){
		for(int i=0;i<3 + level;i++){
			EventManager.Invoke (ref EventManager.OnFire);
			Instantiate (bullet2, new Vector3 (direction == true?transform.position.x +0.2f:transform.position.x -0.2f,transform.position.y,0),Quaternion.identity);
			//b.GetComponent<Boss02Bullet> ().Direction(direction);
			yield return new WaitForSeconds (0.3f-0.05f * level);
		}
	}
}
