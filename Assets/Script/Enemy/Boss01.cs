using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Boss01 : EnemyBase {
	int actTime = 0;
	int actNum = 0;
	int dir = 0;
	float aim = 1.2f;
	float maxspd = 1.2f;
	float spd = 0.1f;
	float updown = 0;
	int angry = 0;
	Enemy04Animation anm;
	public GameObject bullet;
	// Use this for initialization
	protected override void OverrideStart () {
		anm = GetComponent<Enemy04Animation> ();
		maxHp += 500*level;
		hp = maxHp;
		atk += 7*level;
		//level = 5;
		//angry = 1;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (hp < 150 * level)
			angry = 1;
		actTime++;
		if (actTime > 180 - level * 10 - 90 * angry) {
			actTime = 0;
			actNum++;
			if (actNum % 2 == 1)
				Jump ();
			else if (actTime == 0)
				StartCoroutine ("Shot");
		}
		Move ();
		Grav ();


	}
	void Jump(){
		updown = 1;
		if (transform.position.x <= 0)
		maxspd = Random.Range(0,1f + 0.5f * level);
		if (transform.position.x > 0)
			maxspd = Random.Range(-1f - 0.5f * level,0);
		//Debug.Log (maxspd);
	//	aim = -1.2f;
		anm.Jump ();
		rg.velocity = new Vector2(rg.velocity.x,3 +1f * level);
	}
	void Grav(){
		rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.05f -0.1f* level);
	}
	void Move(){
		if (updown > 0) {
			ChangeDirectionToPlayer ();
			if (maxspd >= 0) {
				if(rg.velocity.x < maxspd)rg.velocity = new Vector2 (rg.velocity.x + spd, rg.velocity.y);
			}
			if (maxspd < 0) {
				if(rg.velocity.x > maxspd)rg.velocity = new Vector2 (rg.velocity.x - spd, rg.velocity.y);
			}
		}
	}
	void Lander(){
		anm.Land ();
		if (updown > 0) {
			updown = 0f;

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
	IEnumerator Shot(){
		for(int i=0;i<1 + level;i++){
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (direction == true?transform.position.x +0.2f:transform.position.x -0.2f,transform.position.y+0.25f,2),Quaternion.identity);
			b.GetComponent<Boss01Bullet> ().Direction(direction);
			yield return new WaitForSeconds (1f-0.15f * level);
		}
	}
}
