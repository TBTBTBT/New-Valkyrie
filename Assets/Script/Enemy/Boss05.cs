using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(Boss02Animation))]
//hpslime
public class Boss05 : EnemyBase {
	int actTime = 0;
	float aimX;
	//int actNum = 0;

	int angry = 0;
	int aimtime = 0;
	bool canMove = true;
	//Boss02Animation anm;
	public GameObject effect;
	public GameObject bullet;
	public GameObject bullet2;
	//public GameObject bullet2;
	Vector3 pos;
	// Use this for initialization
	protected override void OverrideStart () {
//		anm = GetComponent<Boss02Animation> ();
	//	Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
	//	Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
	//	Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
		maxHp += 4000*level;
		hp = maxHp;
		atk += 10*level;
		pos = transform.position;
		//angle = 0;
		pos = transform.position;
		//angry = 2;
		aimX = 1.4f;
	//	level = 5;
		//angry = 2;
	//	hp = 1;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		
		ChangeDirectionToPlayer ();
		if (hp < 2000)
			angry = 1;
		//if (hp < 1000)
		//	angry = 2;
	//		angle += 1.5f + angry;
			actTime++;
		if (aimtime >= 1) {
			aimtime++;
			aimX = player.transform.position.x;
			if (aimtime > 100) {
				aimtime = 0;
				aimX = 1.4f;
			}
		}
		if (actTime > 150-angry*30) {
			actTime = 0;
			int ra = Random.Range(0,2+angry);
			// ra = 0;
			if(ra==0)StartCoroutine (Shot ());
			if (ra == 1)
				aimtime = 1;
			if (ra == 2)
				StartCoroutine (Shot2 ());
			//if(ra==3)StartCoroutine (Shot3 ());

		}
		if (canMove == true) {
			MoveY ();
			MoveX ();
			pos = transform.position;
		}
		else {
			rg.velocity = new Vector2 (0, 0);
			Tilt ();
		}

	}
	void Tilt(){
		
		transform.position = pos + new Vector3 (Random.Range (-0.05f, 0.05f), Random.Range (-0.05f, 0.05f),0);
	}
	void MoveX(){
		
		if (transform.position.x > aimX) {
			if (rg.velocity.x > -(level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x - (0.1f*level), rg.velocity.y);
		}
		if (transform.position.x < aimX) {
			if (rg.velocity.x < (level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x + (0.1f*level), rg.velocity.y);
		}
	}
	void MoveY(){
		/*if (transform.position.x > player.transform.position.x) {
			if (rg.velocity.x > -(level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x - (0.02f*level), rg.velocity.y);
		}
		if (transform.position.x < player.transform.position.x) {
			if (rg.velocity.x < (level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x + (0.02f*level), rg.velocity.y);
		}*/
		if (transform.position.y > player.transform.position.y) {
			if (rg.velocity.y > -(level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y - (0.04f*level+0.02f * angry));
		}
		if (transform.position.y < player.transform.position.y) {
			if (rg.velocity.y < (level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y + (0.04f*level+0.02f * angry));
		}
		//transform.position = new Vector3 (transform.position.x + (aimX - transform.position.x)/(80 - angry * 10),Mathf.Sin(angle*Mathf.PI/180)*0.6f,transform.position.z);
	}
	protected override void OverrideDestroy(){
		GameObject o = (GameObject)Instantiate (effect,transform.position,Quaternion.identity);
		EventManager.InvokeGameObjectArg (ref EventManager.OnChangeBoss, o);
		EventManager.Invoke (ref EventManager.OnDestroyBoss05);
	//	EventManager.Invoke (ref EventManager.OnDestroyBoss);
	}
	IEnumerator Shot(){
		canMove = false;
		yield return new WaitForSeconds (0.5f-0.03f * level);
		for(int i=0;i<1;i++){
			EventManager.Invoke(ref EventManager.OnLaser);
			//anm.Attack ();
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (direction == true?transform.position.x +0.2f:transform.position.x -0.2f,transform.position.y,0),Quaternion.identity);
			b.GetComponent<Boss05Bullet> ().Direction (direction);
			yield return new WaitForSeconds (0.5f-0.03f * level);
		}
		canMove = true;
	}
	IEnumerator Shot2(){
		canMove = false;
		for(int i=0;i<5;i++){
			EventManager.Invoke(ref EventManager.OnShotBoss);
			//anm.Attack ();
			GameObject b = (GameObject)Instantiate (bullet2, new Vector3 (direction == true?transform.position.x +0.2f:transform.position.x -0.2f,transform.position.y,0),Quaternion.identity);
			b.GetComponent<Boss05Bullet2> ().SetAim (new Vector2((direction == true?+1f:-1f) * Mathf.Cos(i*30*Mathf.PI/180),(- 1) * Mathf.Sin(i*30*Mathf.PI/180)));
			yield return new WaitForSeconds (0.15f-0.02f * level);
		}
		yield return new WaitForSeconds (0.15f-0.02f * level);
		for(int i=0;i<5;i++){
			EventManager.Invoke(ref EventManager.OnShotBoss);
			//anm.Attack ();
			GameObject b = (GameObject)Instantiate (bullet2, new Vector3 (direction == true?transform.position.x +0.2f:transform.position.x -0.2f,transform.position.y,0),Quaternion.identity);
			b.GetComponent<Boss05Bullet2> ().SetAim (new Vector2((direction == true?+1f:-1f) * Mathf.Cos(i*30*Mathf.PI/180),(1) * Mathf.Sin(i*30*Mathf.PI/180)));
			yield return new WaitForSeconds (0.15f-0.02f * level);
		}
		canMove = true;
	}
	/*
	IEnumerator Shot3(){
		int d = -1 + Random.Range(0,2)*2;
		for(int i=0;i<5;i++){
			//anm.Attack ();

			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (-d * 1.5f +d*0.4f * i,1f,0),Quaternion.identity);
			yield return new WaitForSeconds (0.1f-0.02f * level);
		}
	}
	IEnumerator Shot4(){
		int d = -1 + Random.Range(0,2)*2;
		for(int i=0;i<5;i++){
			//anm.Attack ();

			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (-1.8f + Random.Range(0,2) * 3.6f ,-d * 1f +d*0.4f * i,0),Quaternion.identity);
			yield return new WaitForSeconds (0.1f-0.02f * level);
		}
	}*/
}
