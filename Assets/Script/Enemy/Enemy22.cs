using UnityEngine;
using System.Collections;
//hpslime
public class Enemy22 : EnemyBase {
	int actTime = 0;
	int jnum = 0;
	float maxspd;
	float spd = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		maxHp *= 2;
		hp *= 2;

		maxspd = 0.8f+level * 0.5f;
		spd = Random.Range(0.1f, maxspd );
		ChangeDirectionToPlayer ();
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		Move ();
		Grav ();
		if (transform.position.y<-1.1f)
			Destroy (this.gameObject);
	}
	void Grav(){
		if(rg.velocity.y>-2f)rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.1f);
	}
	void Move(){
		if(direction == true)
			rg.velocity = new Vector2(spd ,rg.velocity.y);
		if(direction == false)
			rg.velocity = new Vector2(-spd ,rg.velocity.y);
	}
	void Lander(){
		

		if (jnum >= 0) {
			ChangeDirectionToPlayer ();
			if (jnum < 5) {
				
				spd = Random.Range (0.1f, maxspd);
				rg.velocity = new Vector2 (rg.velocity.x, 1.5f);
			} else {
				spd = Random.Range (0.1f, maxspd);
				jnum = -2;
				rg.velocity = new Vector2 (rg.velocity.x, 3f);
			}
			jnum += 1;
		}

	}

	protected override void OverrideOnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Land") {
			Lander ();
		}
	}
}
