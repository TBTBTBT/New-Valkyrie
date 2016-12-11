using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Boss03Bullet2 : EnemyBase {
	int dir = 0;
	float spd = 0.1f;
	float angle;
	//Enemy04Animation anm;
	Vector2 aim;
	// Use this for initialization
	protected override void OverrideStart () {

		maxHp += level*50;
		hp = maxHp;
		atk += 1*level;
		//level = 5;
		spd = 0;
		aim = player.transform.position;
		Vector2 d = transform.position;
		d = aim - d;
		aim = d;

	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (transform.position.x < -2.5f || transform.position.x > 2.5f||transform.position.y<-1.1f||transform.position.y>1.1f)
			Destroy (this.gameObject);
		spd += 0.05f + (level-1)*0.05f;
		rg.velocity = new Vector2 (spd*(aim.x/aim.magnitude),spd*(aim.y/aim.magnitude));

	}

}
