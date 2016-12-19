using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Enemy20 : EnemyBase {
	int actTime = 0;
	Enemy04Animation anm;
	public GameObject bullet;
	float maxspd;
	float spd = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		anm = GetComponent<Enemy04Animation> ();
		maxHp *= 2;
		hp *= 2;
		spd = 1f+level * 0.5f;
		maxspd = 0.3f+level * 0.5f;
		ChangeDirectionToPlayer ();
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
		ChangeDirectionToPlayer ();
		spd = maxspd;
		rg.velocity = new Vector2(rg.velocity.x,1.2f);
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
	protected override void OverrideDestroy(){
		Instantiate (bullet, new Vector3 (transform.position.x -0.2f,transform.position.y+0.1f,2),Quaternion.identity);
		Instantiate (bullet, new Vector3 (transform.position.x +0.2f,transform.position.y+0.1f,2),Quaternion.identity);

	}
	protected override void OverrideOnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Land") {
			Lander ();
		}
	}

}
