using UnityEngine;
using System.Collections;
//hpslime
public class Enemy24 : EnemyBase {
	int actTime = 0;
	int jnum = 0;
	float maxspd;
	float spd = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		maxHp *= 2;
		hp *= 2;
		ChangeDirectionToPlayer ();
		maxspd = 0.8f+level * 0.5f;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (transform.position.x < -3.5f || transform.position.x > 3.5f)
			Destroy (this.gameObject);
		Move ();
		actTime++;
	//	Grav ();
		if (transform.position.y<-1.1f)
			Destroy (this.gameObject);
	}
	void Grav(){
		if(rg.velocity.y>-2f)rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.1f);
	}
	void Move(){
		if (transform.position.y > player.transform.position.y) {
			if (rg.velocity.y > -(level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y - (0.03f*level));
		}
		if (transform.position.y < player.transform.position.y) {
			if (rg.velocity.y < (level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y + (0.03f*level));
		}
		if (actTime > 120) {
			if(maxspd>spd)spd += 0.1f;
			if (direction == true)
				rg.velocity = new Vector2 (spd, rg.velocity.y);
			if (direction == false)
				rg.velocity = new Vector2 (-spd, rg.velocity.y);
		} else {
			ChangeDirectionToPlayer ();
		}
	}

}
