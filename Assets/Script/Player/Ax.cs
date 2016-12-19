using UnityEngine;
using System.Collections;

public class Ax : BulletBase {
	float angle;
	// Use this for initialization
	protected override void OverrideStart () {
		angle = 0;
	}
	protected override void OverrideFixedUpdate(){
		angle -= 10;
		transform.rotation = Quaternion.AngleAxis (angle,new Vector3(0,0,1));
		Refrect ();
		if (transform.position.y < -1.1f) {
			Destroy (this.gameObject);
			EventManager.Invoke (ref EventManager.OnEndCombo);
		}
	}
	protected override void OverrideSetVelocity(int dir){
		if(dir == 1)rg.velocity = new Vector2 (0.5f+pow/2,pow*1.2f);
		else rg.velocity = new Vector2 (-0.5f-pow/2,pow*1.2f);

	}
	public override void OverrideHitEnemy(){
		if (rg.velocity.y < 2f) {
			rg.velocity = new Vector2 (rg.velocity.x, 2f);

		} else {
			rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y);
		}
		if (player) {
			if (player.transform.position.x < transform.position.x && rg.velocity.x > 0||
				player.transform.position.x > transform.position.x && rg.velocity.x < 0) {
				rg.velocity = new Vector2 (-rg.velocity.x, rg.velocity.y);
			}
		}

	}
	protected override void Grav(){
		rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.1f);
	}
	void Refrect(){
		if (transform.position.x <= -1.7f) {
			transform.position = new Vector3(-1.7f,transform.position.y,transform.position.z);
			if(rg.velocity.x < 0){
				if(rg.velocity.y < 1f)rg.velocity = new Vector2 (-rg.velocity.x,1f);
				else rg.velocity = new Vector2 (-rg.velocity.x,rg.velocity.y);
			}

		}
		if (transform.position.x >= 1.7f) {
			transform.position = new Vector3(1.7f,transform.position.y,transform.position.z);
			if (rg.velocity.x > 0) {
				if (rg.velocity.y < 1f)
					rg.velocity = new Vector2 (-rg.velocity.x, 1f);
				else
					rg.velocity = new Vector2 (-rg.velocity.x, rg.velocity.y);
			}
		}
	}
}
