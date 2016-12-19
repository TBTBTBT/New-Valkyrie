using UnityEngine;
using System.Collections;
public class Enemy10: EnemyBase {
	int actTime = 0;
	float maxspd;
	Vector2 aim;
	int atmax = 0;
	public GameObject bullet;
	//Enemy04Animation anm;
	// Use this for initialization
	protected override void OverrideStart () {
		//anm = GetComponent<Enemy04Animation> ();
		//level = 5;
		maxspd = level/2f;
		atmax = 60 - level * 3;
		ChangeDirectionToPlayer ();
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
			StartCoroutine ("Shot");
		}

	}
	void Stop(){
		rg.velocity = new Vector2 (0, 0);
	}
	void Move(){
		
		rg.velocity = new Vector2(maxspd*(aim.x/aim.magnitude),maxspd*(aim.y/aim.magnitude));
	}

	IEnumerator Shot(){
		for(int i=0;i<1;i++){
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (transform.position.x,transform.position.y+0.1f,2),Quaternion.identity);
			yield return new WaitForSeconds (0.15f * level);
		}
	}
}
