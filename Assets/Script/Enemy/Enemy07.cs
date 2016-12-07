using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Enemy04Animation))]
//size
public class Enemy07 : EnemyBase {
	int actTime = 0;
	int actnum = 0;
	//int level=1;
	Enemy04Animation anm;
	// Use this for initialization
	protected override void OverrideStart () {
		//anm = GetComponent<Enemy04Animation> ();
		anm = GetComponent<Enemy04Animation> ();
		transform.position = new Vector2 (transform.position.x,0.8f);
		atk += 7 * level;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (actnum == 0) {
			Move ();
		}
		if (actnum == 1) {
			Down ();
		}
		if (transform.position.y < -1.5f) {
			Destroy (this.gameObject);
		}
	}
	void Move(){
		ChangeDirectionToPlayer ();
		if (transform.position.x > player.transform.position.x) {
			if(rg.velocity.x>-level * 1f)rg.velocity = new Vector2(rg.velocity.x - (0.1f),rg.velocity.y);
		}
		if (transform.position.x < player.transform.position.x) {
			if(rg.velocity.x<level * 1f)rg.velocity = new Vector2(rg.velocity.x + (0.1f),rg.velocity.y);
		}
		if (Mathf.Abs (transform.position.x - player.transform.position.x) < 0.2f) {
			actnum = 1;
			anm.Jump ();
		}
	}
	void Down(){
		rg.velocity = new Vector2(0,rg.velocity.y-level/20f);
	}
}
