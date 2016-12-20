using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FireBullet : BulletBase {
	// Use this for initialization
	public List<Sprite>normal;
	int num;
	int time;
	void Animation(List<Sprite> s,bool loop){
		if (time < 4)
			time++;
		if (time >= 4) {
			time = 0;
			if (s.Count <= num) {
				if (loop == true)
					num = 0;
				else
					num = s.Count - 1;
			}
			if (s.Count > num) {
				sprite.sprite = s [num];
			}
			num++;
		}
	}
	protected override void Grav(){
		rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y + 0.1f);
	}
	protected override void OverrideStart () {
		num = 0;
		time = 0;
	//	sprite = GetComponent<SpriteRenderer> ();
	}
	protected override void OverrideFixedUpdate(){
		Animation (normal, true);
		Refrect ();
		if (transform.position.y > 1.1f) {
			Destroy (this.gameObject);
			EventManager.Invoke (ref EventManager.OnEndCombo);
		}

	}
	void LateUpdate(){
		if (transform.position.y < -0.4f)
			transform.position = new Vector3 (transform.position.x,-0.4f,transform.position.z);
	}
	protected override void OverrideSetVelocity(int dir){
		if(dir == 1)rg.velocity = new Vector2 (0.5f+pow/2,-pow*0.4f);
		else rg.velocity = new Vector2 (-0.5f-pow/2,-pow*0.4f);

	}
	public override void OverrideHitEnemy(){
		if (rg.velocity.y > -2f) {
			rg.velocity = new Vector2 (rg.velocity.x, -2f);

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
	void Refrect(){
		if (transform.position.x <= -1.7f) {
			transform.position = new Vector3(-1.7f,transform.position.y,transform.position.z);
			if(rg.velocity.x < 0){
				if(rg.velocity.y < 1f)rg.velocity = new Vector2 (-rg.velocity.x,-1f);
				else rg.velocity = new Vector2 (-rg.velocity.x,rg.velocity.y);
			}

		}
		if (transform.position.x >= 1.7f) {
			transform.position = new Vector3(1.7f,transform.position.y,transform.position.z);
			if (rg.velocity.x > 0) {
				if (rg.velocity.y < 1f)
					rg.velocity = new Vector2 (-rg.velocity.x, -1f);
				else
					rg.velocity = new Vector2 (-rg.velocity.x, rg.velocity.y);
			}
		}
	}
}
