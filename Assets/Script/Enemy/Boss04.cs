using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(Boss02Animation))]
//hpslime
public class Boss04 : EnemyBase {
	int actTime = 0;
	float angle;
	float aimX;
	//int actNum = 0;
	public GameObject effect;
	int angry = 0;
	//Boss02Animation anm;
	public GameObject bullet;
	//public GameObject bullet2;
	// Use this for initialization
	protected override void OverrideStart () {
//		anm = GetComponent<Boss02Animation> ();
		Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
		Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
		Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
		maxHp += 4000*level;
		hp = maxHp;
		atk += 10*level;
		angle = 0;
		//angry = 2;
		aimX = transform.position.x;
	//	level = 5;
	//	angry = 1;
	//	hp = 1;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		ChangeDirectionToPlayer ();
		if (hp < 2000)
			angry = 1;
		if (hp < 1000)
			angry = 2;
		if (Mathf.Abs (aimX - transform.position.x) < 0.4f) {
			angle += 0.5f + angry;
			actTime++;
		}
		if (actTime > 120 - angry * 20) {
			actTime = 0;
			int ra = Random.Range (0, 2 + angry);
			// ra = 0;
			if(ra==0)StartCoroutine (Shot ());
			if(ra==1)aimX = -1.2f + Random.Range (0, 2)*2.4f;
			if (ra == 2) {
				if(angry <= 1)StartCoroutine (Shot2 ());
				else StartCoroutine (Shot4 ());
			}
			if(ra==3)StartCoroutine (Shot3 ());

		}
		Move ();

	}
	void Move(){
		transform.position = new Vector3 (transform.position.x + (aimX - transform.position.x)/(80 - angry * 10),Mathf.Sin(angle*Mathf.PI/180)*0.6f,transform.position.z);
	}
	protected override void OverrideDestroy(){
		GameObject o = (GameObject)Instantiate (effect,transform.position,Quaternion.identity);
		EventManager.InvokeGameObjectArg (ref EventManager.OnChangeBoss, o);
		EventManager.Invoke (ref EventManager.OnDestroyBoss04);
	}
	IEnumerator Shot(){
		for(int i=0;i<2;i++){
			//anm.Attack ();
			EventManager.Invoke(ref EventManager.OnShotBoss);
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (direction == true?transform.position.x +0.2f:transform.position.x -0.2f,transform.position.y,0),Quaternion.identity);
			yield return new WaitForSeconds (0.5f-0.03f * level);
		}
	}
	IEnumerator Shot2(){
		for(int i=0;i<2;i++){
			//anm.Attack ();
			EventManager.Invoke(ref EventManager.OnShotBoss);
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (Random.Range(-1.2f,1.2f),-1f + Random.Range (0, 2)*2f,0),Quaternion.identity);
			yield return new WaitForSeconds (0.15f-0.02f * level);
		}
	}
	IEnumerator Shot3(){
		int d = -1 + Random.Range(0,2)*2;
		for(int i=0;i<5;i++){
			//anm.Attack ();
			EventManager.Invoke(ref EventManager.OnShotBoss);
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (-d * 1.5f +d*0.4f * i,1f,0),Quaternion.identity);
			yield return new WaitForSeconds (0.1f-0.02f * level);
		}
	}
	IEnumerator Shot4(){
		int d = -1 + Random.Range(0,2)*2;
		for(int i=0;i<5;i++){
			//anm.Attack ();
			EventManager.Invoke(ref EventManager.OnShotBoss);
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (-1.8f + Random.Range(0,2) * 3.6f ,-d * 1f +d*0.4f * i,0),Quaternion.identity);
			yield return new WaitForSeconds (0.1f-0.02f * level);
		}
	}
}
