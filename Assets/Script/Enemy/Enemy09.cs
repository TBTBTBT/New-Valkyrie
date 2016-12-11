using UnityEngine;
using System.Collections;
public class Enemy09: EnemyBase {
	int actTime = 0;
	float maxspd;
	Vector2 aim;
	int atmax = 0;
	//Enemy04Animation anm;
	// Use this for initialization
	protected override void OverrideStart () {
		//anm = GetComponent<Enemy04Animation> ();
		//level = 5;
		maxspd = level;
		atmax = 30 - level * 3;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		actTime++;
		if (actTime < atmax) {
			if (actTime == atmax - 1) {
				aim = player.transform.position;
				Vector2 d = transform.position;
				d = aim - d;
				aim = d;
			}
			ChangeDirectionToPlayer ();
			//Jump ();
			Stop();
		} else {
			Move ();
		}
		if (actTime > atmax*(3 - level * 0.25f)) {
			actTime = 0;

		}

	}
	void Stop(){
		rg.velocity = new Vector2 (0, 0);
	}
	void Move(){
		
		rg.velocity = new Vector2(maxspd*(aim.x/aim.magnitude),maxspd*(aim.y/aim.magnitude));
	}


}
