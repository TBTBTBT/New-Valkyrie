using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Boss03Bullet : EnemyBase {
	int actTime = 0;
	int actNum = 0;
	int dir = 0;
	float spd = 0.1f;
	//Enemy04Animation anm;

	// Use this for initialization
	public void Direction(bool d,float sd){
		if (d == true) {
			spd = sd;
		} else {
			spd = -sd;
		}
	}
	protected override void OverrideStart () {
		maxHp += level*50;
		hp = maxHp;
		atk += 2 +level;
		//level = 5;
		//if (spd > 0)
			//spd += (level-1) * 0.5f;
		//if(spd<0)spd -= (level-1)*0.5f;
		rg.velocity = new Vector2 (spd,-Mathf.Abs(spd/2));
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (transform.position.x < -2.5f || transform.position.x > 2.5f||transform.position.y<-1.1f||transform.position.y>1.1f) 
			Destroy (this.gameObject);
		
		rg.velocity = new Vector2 (spd,rg.velocity.y+0.15f * level);

	}


}
