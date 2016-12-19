using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Enemy10Bullet : EnemyBase {
	int dir = 0;
	float spd = 0.1f;
	float angle;
	//Enemy04Animation anm;
	Vector2 aim;
	// Use this for initialization
	protected override void OverrideStart () {
		transform.localScale = new Vector3 (2, 2, 1);
		maxHp += level*50;
		hp = maxHp;
		atk += 1*level;
		//level = 5;
		spd = 1.5f + (level-1)*0.5f;
		aim = player.transform.position;
		Vector2 d = transform.position;
		d = aim - d;
		aim = d;
		angle = Mathf.Atan2 (d.y, d.x) *180/ Mathf.PI;
		transform.rotation = Quaternion.AngleAxis (angle,new Vector3(0,0,1));
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (transform.position.x < -2.5f || transform.position.x > 2.5f||transform.position.y<-1.1f||transform.position.y>1.1f)
			Destroy (this.gameObject);
		
		rg.velocity = new Vector2 (spd*(aim.x/aim.magnitude),spd*(aim.y/aim.magnitude));

	}

}
