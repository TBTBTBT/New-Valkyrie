using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Enemy21 : EnemyBase {
	int actTime = 0;
	Enemy04Animation anm;
	float maxspd;
	float spd = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		anm = GetComponent<Enemy04Animation> ();
		maxHp *= 2;
		hp *= 2;

		maxspd = 0.3f+level * 0.5f;
		spd = Random.Range(-maxspd, maxspd );
		ChangeDirectionToPlayer ();
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		actTime++;
		if (actTime > 40) {
			actTime = 0;
			Jump ();
		}
		Move ();
		Grav ();
	}
	void Jump(){
		anm.Jump ();
		ChangeDirectionToPlayer ();
		spd = maxspd;
		rg.velocity = new Vector2(rg.velocity.x,1.5f);
	}
	void Grav(){
		if(rg.velocity.y>-2f)rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.1f);
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
}
