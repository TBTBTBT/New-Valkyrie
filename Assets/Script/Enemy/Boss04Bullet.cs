using UnityEngine;
using System.Collections;

public class Boss04Bullet : EnemyBase {

	float spd = 0.1f;
	float angle;
	float acttime = 0;

	//Enemy04Animation anm;
	Vector2 aim;
	// Use this for initialization2
	protected override void OverrideStart () {
		transform.localScale = new Vector3 (2, 2, 1);
		Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
		Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
		Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
		Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
		maxHp += level*50;
		hp = maxHp;
		atk += 2 + 1*level;
		//level = 5;
		spd = 1f + (level-1)*0.5f;
		aim = player.transform.position;
		Vector2 d = transform.position;
		d = aim - d;
		aim = d;
		angle = Mathf.Atan2 (d.y, d.x) *180/ Mathf.PI;
		//if (d.x < 0)
			//angle -= 180;
		transform.rotation = Quaternion.AngleAxis (angle,new Vector3(0,0,1));
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		acttime++;
		if (acttime < 60) {

			aim = player.transform.position;
			Vector2 d = transform.position;
			d = aim - d;
			aim = d;
			angle = Mathf.Atan2 (d.y, d.x) *180/ Mathf.PI;
			//if (d.x < 0)
			//	angle -= 180;
			transform.rotation = Quaternion.AngleAxis (angle,new Vector3(0,0,1));
		}
		if (acttime > 60) {
			if (transform.position.x < -2.5f || transform.position.x > 2.5f || transform.position.y < -1.5f || transform.position.y > 1.5f)
				Destroy (this.gameObject);

			rg.velocity = new Vector2 (spd * (aim.x / aim.magnitude), spd * (aim.y / aim.magnitude));
			spd += 0.1f;
		}
	}

}
