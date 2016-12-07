using UnityEngine;
using System.Collections;

public class Enemy02 : EnemyBase{
	int stopTime;
	float speed = 0;
	float aimY = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		stopTime = 360;
		speed = 3;
		aimY = 0;
	}
	
	// Update is called once per frame
	protected override void OverrideUpdate () {
		stopTime++;
		if (stopTime > 180 - 15 * level) {
			stopTime = 0;
			speed = 1.5f * (level+1) ;
			aimY = -1;
		}
		if (stopTime > 100- 7 * level) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + (aimY- transform.position.y)/(20-level*2), transform.position.z);
		}

		speed -=1.5f * (level+1) / (150 / (level+1));
		if (speed <= 0) {
			speed = 0;
			if (aimY <= -1) {
				int aim = Random.Range (0, 5);
				aimY = aim * 0.2f - 0.3f;
			}
			ChangeDirectionToPlayer();
		}
		if(direction ==true)rg.velocity = new Vector2 (speed,0);
		else rg.velocity = new Vector2 (-speed,0);
	}
}
