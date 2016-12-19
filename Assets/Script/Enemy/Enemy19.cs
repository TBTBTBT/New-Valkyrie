using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Boss02Animation))]
public class Enemy19 : EnemyBase {
	int actTime = 0;
	float maxspd;
	float spd = 0;
	float kb = 0;
	Boss02Animation anm;
	public GameObject bullet;
	int sw = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		anm = GetComponent<Boss02Animation> ();
		spd = level * 0.05f;
		maxspd = 1f+ level * 0.2f;
		ChangeDirectionToPlayer ();
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		actTime++;
		if (actTime > 120-level * 15) {
			actTime = 0;
			switch (sw) {
			case 0:
				Jump ();
				sw = 1;
				break;
			case 1:
				anm.Attack ();
				sw = 0;
				kb = 0.3f;
				StartCoroutine (Shot ());
				break;
			}
		}

		Move ();
		KB ();
		Grav ();
	}
	void Jump(){
		anm.Jump ();
		ChangeDirectionToPlayer ();
		spd = maxspd;
		rg.velocity = new Vector2(rg.velocity.x,3f);
	}
	void Grav(){
		if(rg.velocity.y>-2f)rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.1f);
	}
	void KB(){
		if (kb > 0) {
			kb -= 0.02f;
			if (direction == true)
				rg.velocity = new Vector2 (-kb, rg.velocity.y);
			if (direction == false)
				rg.velocity = new Vector2 (kb, rg.velocity.y);
		}
	}
	void Move(){
		if (spd > 0)
			spd -= 0.01f;
		if (spd < 0)
			spd = 0;
		if(direction == true)
		rg.velocity = new Vector2(spd ,rg.velocity.y);
		if(direction == false)
			rg.velocity = new Vector2(-spd ,rg.velocity.y);
	}
	void Lander(){
		anm.Land ();
			rg.velocity = new Vector2(0,0);
		spd = 0;
	}
	protected override void OverrideOnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Land") {
			Lander ();
		}
	}
	IEnumerator Shot(){
		for(int i=0;i<1;i++){
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (direction == true?transform.position.x +0.2f:transform.position.x -0.2f,transform.position.y+0.1f,2),Quaternion.identity);
			b.GetComponent<Enemy19Bullet> ().Direction(direction);
			yield return new WaitForSeconds (0.65f-0.1f * level);
		}
	}
}

