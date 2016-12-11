using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Enemy13Bullet : EnemyBase {

	//Enemy04Animation anm;

	// Use this for initialization
	protected override void OverrideStart () {

		maxHp += level*50;
		hp = maxHp;
		atk += 1*level;
		//level = 5;

		rg.velocity = new Vector2 (0,3f+1f*(level-1));
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (transform.position.x < -2.5f || transform.position.x > 2.5f||transform.position.y<-1.1f)
			Destroy (this.gameObject);
		
		rg.velocity = new Vector2 (0,rg.velocity.y-0.1f * level);

	}


}
