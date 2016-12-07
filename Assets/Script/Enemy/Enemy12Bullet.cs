using UnityEngine;
using System.Collections;
//[RequireComponent(typeof(Enemy04Animation))]
//hpslime
public class Enemy12Bullet : EnemyBase {
	int dir = 0;
	float spd = 0.1f;
	float angle;
	//Enemy04Animation anm;

	// Use this for initialization
	public void Direction(bool d){
		if (d == true) {
			spd = 1;
		} else {
			spd = -1;
		}
	}
	protected override void OverrideStart () {
		angle = 0;
		maxHp += level*50;
		hp = maxHp;
		atk += 1*level;
		//level = 5;
		if (spd > 0)
			spd += (level-1) * 0.5f;
		if(spd<0)spd -= (level-1)*0.5f;
		rg.velocity = new Vector2 (spd,2f+1f*(level-1));
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		angle -= 10;
		transform.rotation = Quaternion.AngleAxis (angle,new Vector3(0,0,1));
		if (transform.position.x < -2.5f || transform.position.x > 2.5||transform.position.y<-1.1f)
			Destroy (this.gameObject);
		
		rg.velocity = new Vector2 (spd,rg.velocity.y-0.1f * level);

	}
	protected override void OverrideOnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Land") {
			//Debug.Log ("aa");
			//rg.velocity = new Vector2 (spd,4f+1f*(level-1));
		}
	}

}
