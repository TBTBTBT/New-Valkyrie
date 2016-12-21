using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Enemy04Animation))]
public class Enemy11 : EnemyBase {
	int actTime = 0;
	float maxspd;
	float spd = 0;
	Enemy04Animation anm;
	// Use this for initialization
	protected override void OverrideStart () {
		anm = GetComponent<Enemy04Animation> ();
		maxspd =  1f + level *0.5f;
		maxHp = 10 * level;
		hp = maxHp;
		atk += level * 2;
		ChangeDirectionToPlayer ();
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		actTime++;
		if (actTime < 60) {
			anm.Land ();
			ChangeDirectionToPlayer ();
				spd = maxspd;
			rg.velocity = new Vector2(0,rg.velocity.y);
		}
		if (actTime >= 60) {
			if(actTime == 60)Jump ();
			Move ();
		}
		if (actTime >= 120)actTime = 0;
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
		if (spd > 0)
			spd -= 0.01f * level;
		else spd =0f;
		if(direction ==true)rg.velocity = new Vector2(spd,rg.velocity.y);
		if(direction ==false)rg.velocity = new Vector2(-spd,rg.velocity.y);


	}
	void Lander(){
		
			rg.velocity = new Vector2(rg.velocity.x,0);
	}
	protected override void OverrideOnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Land") {
			Lander ();
		}
	}
}
