using UnityEngine;
using System.Collections;
//badbat
public class Enemy16 : EnemyBase {

	public GameObject bullet;
	int acttime = 0;
	// Use this for initialization
	protected override void OverrideStart () {
		//anm = GetComponent<Enemy04Animation> ();
		transform.position = new Vector2 (transform.position.x,-0.8f);
		atk += 5 * level;
		maxHp += 3 * level;
		hp = maxHp;
	}
	// Update is called once per frame
	protected override void OverrideUpdate () {
			Move ();
		acttime++;
		if (acttime > 45 - level * 5) {
			StartCoroutine("Shot");
			acttime = 0;
		}
			
	}
	void Move(){
		ChangeDirectionToPlayer ();
		if (transform.position.x > player.transform.position.x) {
			if (rg.velocity.x > -(level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x - (0.03f*level), rg.velocity.y);
		}
		if (transform.position.x < player.transform.position.x) {
			if (rg.velocity.x < (level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x + (0.03f*level), rg.velocity.y);
		}
		if (transform.position.y > player.transform.position.y) {
			if (rg.velocity.y > -(level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y - (0.03f*level));
		}
		if (transform.position.y < player.transform.position.y) {
			if (rg.velocity.y < (level *0.5f+ 0.5f))
				rg.velocity = new Vector2 (rg.velocity.x, rg.velocity.y + (0.03f*level));
		}
	}
	IEnumerator Shot(){
		for(int i=0;i<1;i++){
			GameObject b = (GameObject)Instantiate (bullet, new Vector3 (transform.position.x,transform.position.y+0.1f,2),Quaternion.identity);
			yield return new WaitForSeconds (0.15f * level);
		}
	}
}
