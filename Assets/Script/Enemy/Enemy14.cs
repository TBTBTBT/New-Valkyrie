using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Enemy04Animation))]
public class Enemy14 : EnemyBase {
	int actTime = 0;
	float maxspd;
	float spd = 0;
	int spddir = 0;
	bool land = false;
	Enemy04Animation anm;
	// Use this for initialization
	protected override void OverrideStart () {
		anm = GetComponent<Enemy04Animation> ();
		spd =  1.8f + level*0.5f;
		ChangeDirectionToPlayer ();
		//maxspd = level * 0.4f;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		actTime++;
		if (actTime > 60||(land == true && Mathf.Abs(transform.position.x - player.transform.position.x)<0.8f)) {
			spd = 1 + level;
			actTime = 0;
			if (transform.position.x > player.transform.position.x)
				spddir = -1;
			else
				spddir = 1;
			if(land == true&&Mathf.Abs(transform.position.x - player.transform.position.x)<0.8f)Jump ();
		}
		Move ();
		Grav ();
	}
	void Jump(){
		land = false;
		anm.Jump ();
		rg.velocity = new Vector2(rg.velocity.x,3f);
	}
	void Grav(){
		if(rg.velocity.y>-2f)rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.2f);
	}
	void Move(){
		if(spd>0)spd -= 0.05f * level;
		ChangeDirectionToPlayer ();
		rg.velocity = new Vector2(spd * spddir,rg.velocity.y);
	}
	void Lander(){
		land = true;
		anm.Land ();
			rg.velocity = new Vector2(rg.velocity.x,0);
	}
	protected override void OverrideOnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Land") {
			Lander ();
		}
	}
}
