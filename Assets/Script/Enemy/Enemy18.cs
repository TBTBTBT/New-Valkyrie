using UnityEngine;
using System.Collections;
//badbat
public class Enemy18 : EnemyBase {

	int acttime = 0;
	int angle = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		//anm = GetComponent<Enemy04Animation> ();
		transform.position = new Vector2 (transform.position.x,-0.8f);
		atk += 5 * level;
		maxHp += 3 * level;
		hp = maxHp;
		ChangeDirectionToPlayer ();
		if (transform.position.x > player.transform.position.x) {
				rg.velocity = new Vector2 (-(0.6f*level), rg.velocity.y);
		}
		if (transform.position.x <= player.transform.position.x) {
				rg.velocity = new Vector2 ((0.6f*level), rg.velocity.y);
		}
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
			Move ();
		acttime++;
		if (acttime > 45 - level * 5) {
			acttime = 0;
		}
			
	}
	void Move(){
		angle += 10 * level;
		transform.position = new Vector3 (transform.position.x,Mathf.Sin(angle*Mathf.PI/180)*0.5f,transform.position.z);

	}

}
