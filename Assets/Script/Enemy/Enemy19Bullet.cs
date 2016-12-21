using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Enemy19Bullet : EnemyBase {
	int dir = -1;
	float spd = 0.1f;

	//Enemy04Animation anm;

	// Use this for initialization
	public void Direction(bool d){
		if (d == true) {
			dir = 1;
			ChangeDirection (true);
		} else {
			dir = -1;
			ChangeDirection (false);
		}
	}
	protected override void OverrideStart () {
		maxHp += level*50;
		hp = maxHp;
		atk += 2*level;
		//level = 5;

		spd = 1 + (level - 1) * 0.5f;
		rg.velocity = new Vector2 (spd,0);
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (transform.position.x < -2.5f || transform.position.x > 2.5f||transform.position.y<-1.1f)
			Destroy (this.gameObject);
		
		rg.velocity = new Vector2 (spd * dir,0);

	}


}
