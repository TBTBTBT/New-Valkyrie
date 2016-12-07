using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Enemy06 : EnemyBase {
	int actTime = 0;
	Enemy04Animation anm;
	float maxspd;
	float spd = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		anm = GetComponent<Enemy04Animation> ();
		maxHp *= 2;
		hp *= 2;
		spd = level * 0.05f;
		maxspd = level * 0.1f;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		actTime++;
		if (actTime > 80) {
			actTime = 0;
			Jump ();
		}
		Move ();
		Grav ();
	}
	void Jump(){
		anm.Jump ();
		rg.velocity = new Vector2(rg.velocity.x,1.5f);
	}
	void Grav(){
		if(rg.velocity.y>-2f)rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.1f);
	}
	void Move(){
		ChangeDirectionToPlayer ();
		if (transform.position.x > player.transform.position.x) {
			if(rg.velocity.x>-maxspd)rg.velocity = new Vector2(rg.velocity.x - spd,rg.velocity.y);
		}
		if (transform.position.x < player.transform.position.x) {
			if(rg.velocity.x<maxspd)rg.velocity = new Vector2(rg.velocity.x + spd,rg.velocity.y);
		}
	}
	void Lander(){
		anm.Land ();
			rg.velocity = new Vector2(rg.velocity.x,0);
	}
	protected override void OverrideOnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Land") {
			Lander ();
		}
	}
}
