using UnityEngine;
using System.Collections;

public class Enemy01 : EnemyBase{
	int stopTime;
	float speed = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		stopTime = 180;
		speed = level;
		atk += 1 * level;
		atk*=2;
		ChangeDirectionToPlayer ();
	}
	
	// Update is called once per frame
	protected override void OverrideUpdate () {
		stopTime++;
		if (stopTime > 180- 15 * level) {
			stopTime = 0;
			speed = 1.5f * level ;
		}
		speed -= 1.5f * level / (150 / level);
		if (speed <= 0 ) {
			speed = 0;
			ChangeDirectionToPlayer();
		}
		if(direction ==true)rg.velocity = new Vector2 (speed,0);
		else rg.velocity = new Vector2 (-speed,0);
	}
}
