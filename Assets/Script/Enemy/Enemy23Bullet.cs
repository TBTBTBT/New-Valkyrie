using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Enemy23Bullet : EnemyBase {

	//Enemy04Animation anm;
	float spd=0;
	// Use this for initialization
	protected override void OverrideStart () {

		maxHp += level*50;
		hp = maxHp;
		atk += 1*level;
		//level = 5;
		spd = Random.Range(-level*0.8f,level*0.8f);
		rg.velocity = new Vector2 (0,3f+1f*(level-1));
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (transform.position.x < -2.5f || transform.position.x > 2.5f||transform.position.y<-1.1f)
			Destroy (this.gameObject);
		
		rg.velocity = new Vector2 (spd,rg.velocity.y-0.1f * level);

	}


}
