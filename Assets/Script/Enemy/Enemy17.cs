using UnityEngine;
using System.Collections;
//badbat
public class Enemy17 : EnemyBase {

	int acttime = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		//anm = GetComponent<Enemy04Animation> ();
		transform.position = new Vector2 (transform.position.x,-0.8f);
		atk += 4 + level;
		maxHp += 3 * level;
		hp = maxHp;
		ChangeDirectionToPlayer ();
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
			Move ();
		acttime++;
		if (acttime > 45 - level * 5) {
			acttime = 0;
		}
			
	}
	void Move(){
		ChangeDirectionToPlayer ();
		if (transform.position.x > player.transform.position.x) {
			if (rg.velocity.x > -(level *0.5f+ 1.5f))
				rg.velocity = new Vector2 (rg.velocity.x - (0.06f*level), rg.velocity.y);
		}
		if (transform.position.x < player.transform.position.x) {
			if (rg.velocity.x < (level *0.5f+ 1.5f))
				rg.velocity = new Vector2 (rg.velocity.x + (0.06f*level), rg.velocity.y);
		}
		if (transform.position.y > player.transform.position.y) {
			if (rg.velocity.y > -(level *0.5f+ 1.5f))
				rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y - (0.06f*level));
		}
		if (transform.position.y < player.transform.position.y) {
			if (rg.velocity.y < (level *0.5f+ 1.5f))
				rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y + (0.06f*level));
		}
	}

}
