using UnityEngine;
using System.Collections;
//badbat
[RequireComponent(typeof(Enemy04Animation))]
public class Enemy15 : EnemyBase {

	bool chase = false;
	// Use this for initialization
	Enemy04Animation anm;
	// Use this for initialization
	protected override void OverrideStart () {
		anm = GetComponent<Enemy04Animation> ();
		//anm = GetComponent<Enemy04Animation> ();
		transform.position = new Vector2 (transform.position.x,-0.8f);
		atk += 10 * level;
		maxHp += 3 * level;
		hp = maxHp;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
			Move ();
		if (Mathf.Abs (transform.position.x - player.transform.position.x) < 0.8f) {
			Grav ();
		}
		if (transform.position.y<-1.2f||transform.position.y>1.2f)
			Destroy (this.gameObject);
			
	}
	void Change(bool c){
		if (chase != c) {
			if(c == true)anm.Jump ();
			if(c == false)anm.Land ();
		}
		chase = c;
	}
	void Grav(){
		Change (true);
		if(rg.velocity.y>-2f)rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.1f);
	}
	void Move(){
		
		ChangeDirectionToPlayer ();
		if (transform.position.x > player.transform.position.x) {
			if (rg.velocity.x > -(level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x - (0.04f*level), rg.velocity.y);
		}
		if (transform.position.x < player.transform.position.x) {
			if (rg.velocity.x < (level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x + (0.04f*level), rg.velocity.y);
		}
		if (Mathf.Abs (transform.position.x - player.transform.position.x) >= 0.8f) {
			Change (false);
			if (transform.position.y > player.transform.position.y + 0.5f) {
				if (rg.velocity.y > -(level * 0.5f + 0.5f))
					rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y - (0.02f * level));
			}
			if (transform.position.y < player.transform.position.y + 0.5f) {
				if (rg.velocity.y < (level * 0.5f + 0.5f))
					rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y + (0.02f * level));
			}
		}

	}
}
