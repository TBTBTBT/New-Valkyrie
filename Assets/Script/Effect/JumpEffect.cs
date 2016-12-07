using UnityEngine;
using System.Collections;

public class JumpEffect : MonoBehaviour {
	int time =0;
	float spd= 1.6f;
	bool rev = false;
	Rigidbody2D rg;
	// Use this for initialization
	void Start () {
		time =0;
		rg = GetComponent<Rigidbody2D> ();
		if (transform.position.z < 0) {
			transform.localScale = new Vector2 (-2, 2);
			rev = true;
		}
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time++;
		if (spd > 0)
			spd -= 0.1f;
		if(rev == false)rg.velocity = new Vector2 (spd, 0);
		else rg.velocity = new Vector2 (-spd, 0);
		if (time > 10)
			Destroy (this.gameObject);
	}
}
