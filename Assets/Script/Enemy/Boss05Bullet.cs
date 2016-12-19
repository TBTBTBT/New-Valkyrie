using UnityEngine;
using System.Collections;

public class Boss05Bullet : EnemyBase {
	int dir = 1;
	float spd = 0.1f;
	float angle;
	float acttime = 0;
	float acc = 0;
	//Enemy04Animation anm;
	Vector2 aim;
	public void Direction(bool d){
		if (d == true) {
			dir = 1;
		} else {
			dir = -1;
		}
	}
	// Use this for initialization
	protected override void OverrideStart () {
		transform.localScale = new Vector3 (0, 2, 1);
		maxHp += level*50;
		hp = maxHp;
		atk += 5 + 10*level;
		//level = 5;
		//if (d.x < 0)
			//angle -= 180;
	
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		if (transform.localScale.y > 0) {
			
			transform.localScale += new Vector3 (0.15f, -acc,0);
			acc += 0.001f;
			transform.position += new Vector3 (dir * 0.045f, 0,0);
		} else {
			Destroy (this.gameObject);
		}
	}

}
