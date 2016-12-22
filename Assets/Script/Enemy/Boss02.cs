using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Boss02Animation))]
//hpslime
public class Boss02 : EnemyBase {
	int actTime = 0;
	//int actNum = 0;
	float ang = 0f;
	float updown = 0;
	int angry = 0;
	Boss02Animation anm;
	public GameObject bullet;
	public GameObject bullet2;
	Vector3 pos;
	// Use this for initialization
	protected override void OverrideStart () {
		anm = GetComponent<Boss02Animation> ();
		maxHp += 1000*level;
		hp = maxHp;
		atk += 7*level;
		pos = transform.position;
		//level = 5;
		//angry = 1;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (hp < 350 * level)
			angry = 1;
		actTime++;
		if (actTime > 150 - level * 5 - 70 * angry) {
			actTime = 0;

			//else if (actTime == 0)
			int ra = Random.Range(0,3);
			if(ra == 1)StartCoroutine (Shot());
			if (ra == 0)Jump ();
			if (ra == 2)
				ang = 1;
		}
		Move ();
		Grav ();


	}
	void Jump(){
		updown = 1;
		//if (transform.position.x <= 0)
		//maxspd = Random.Range(0,1f + 0.5f * level);
		//if (transform.position.x > 0)
		//	maxspd = Random.Range(-1f - 0.5f * level,0);
		//Debug.Log (maxspd);
	//	aim = -1.2f;
		anm.Jump ();
		rg.velocity = new Vector2(rg.velocity.x,3 +1f * level);
	}
	void Grav(){
		rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.05f -0.1f* level);
	}
	void Move(){
		if (ang > 0){
			ang += 5;
			if (ang > 360)
				ang = 0;
			ChangeDirectionToPlayer ();
			transform.position = new Vector3 (Mathf.Sin(ang*Mathf.PI/180)*1.5f+pos.x,transform.position.y,transform.position.z);

		}

	}
	void Lander(){
		//
		if (updown > 0) {
			StartCoroutine ("Shot2");
			updown = 0f;
			anm.Land ();

		}
		//transform.position = new Vector2 (transform.position.x, transform.position.y );

			rg.velocity = new Vector2(0,0);
	}
	protected override void OverrideOnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Land") {
			//Debug.Log ("aa");
			Lander ();
		}
	}
	protected override void OverrideDestroy(){
		EventManager.Invoke (ref EventManager.OnDestroyBoss);
	}
	IEnumerator Shot(){
		for(int i=0;i<4 + level;i++){
			anm.Attack ();
			Instantiate (bullet, new Vector3 (direction == true?transform.position.x +0.2f:transform.position.x -0.2f,transform.position.y+0.25f,2),Quaternion.identity);
			//b.GetComponent<Boss02Bullet> ().Direction(direction);
			yield return new WaitForSeconds (0.65f-0.1f * level);
		}
	}
	IEnumerator Shot2(){
		for(int i=0;i<3 + level;i++){
			for(int j=0;j<2 + level;j++)Instantiate (bullet2, new Vector3 (Random.Range(-2f,2f),1.1f,0),Quaternion.identity);
			//b.GetComponent<Boss02Bullet> ().Direction(direction);
			yield return new WaitForSeconds (0.35f-0.05f * level);
		}
	}
}
