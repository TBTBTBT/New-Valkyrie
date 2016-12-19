using UnityEngine;
using System.Collections;

public class Enemy23 : EnemyBase {
	int actTime = 0;
	float maxspd;
	float spd = 0;
	public GameObject bullet;
	// Use this for initialization
	protected override void OverrideStart () {
		spd = level * 0.4f;
		//maxspd =

		Move ();
		ChangeDirectionToPlayer ();
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
		actTime++;
		if (actTime > 40-level*5) {
			actTime = 0;
			StartCoroutine ("Shot");
		}
		if (transform.position.x < -3.5f || transform.position.x > 3.5f||transform.position.y<-1.1f)
			Destroy (this.gameObject);

		Grav ();
	}

	void Grav(){
		if(rg.velocity.y>-2f)rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.1f);
	}
	void Move(){
		ChangeDirectionToPlayer ();
		if (transform.position.x > player.transform.position.x) {
			rg.velocity = new Vector2(-spd ,rg.velocity.y);
		}
		if (transform.position.x < player.transform.position.x) {
			rg.velocity = new Vector2(spd,rg.velocity.y);
		}
	}
	void Lander(){
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
			yield return new WaitForSeconds (0.15f * level);
		}
	}
}
