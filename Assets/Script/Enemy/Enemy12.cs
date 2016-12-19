using UnityEngine;
using System.Collections;
public class Enemy12: EnemyBase {
	int actTime = 0;
	float maxspd;
	float spd = 0;
	//Enemy04Animation anm;
	public GameObject bullet;
	// Use this for initialization
	protected override void OverrideStart () {
		//anm = GetComponent<Enemy04Animation> ();
		spd = level * 0.05f;
		maxspd = level * 0.3f;
		ChangeDirectionToPlayer ();
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		actTime++;
		if (actTime > 60) {
			actTime = 0;
			StartCoroutine ("Shot");
			//Jump ();
		}
		Move ();
		Grav ();
	}
	void Jump(){
	//	anm.Jump ();
	//	rg.velocity = new Vector2(rg.velocity.x,1.5f);
	}
	void Grav(){
		if(rg.velocity.y>-2f)rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.1f);
	}
	void Move(){
		ChangeDirectionToPlayer ();
		if (transform.position.x > player.transform.position.x) {
			if(rg.velocity.x>-maxspd)rg.velocity = new Vector2(rg.velocity.x - spd ,rg.velocity.y);
		}
		if (transform.position.x < player.transform.position.x) {
			if(rg.velocity.x<maxspd)rg.velocity = new Vector2(rg.velocity.x + spd,rg.velocity.y);
		}
	}
	void Lander(){
		//anm.Land ();
			rg.velocity = new Vector2(rg.velocity.x,0);
	}
	protected override void OverrideOnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Land") {
			Lander ();
		}
	}
	IEnumerator Shot(){
		for(int i=0;i<1;i++){
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (transform.position.x,transform.position.y,2),Quaternion.identity);
			b.GetComponent<Enemy12Bullet> ().Direction(direction);
			yield return new WaitForSeconds (0.15f * level);
		}
	}
}
