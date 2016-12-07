using UnityEngine;
using System.Collections;

public class UpEffect : MonoBehaviour {
	int time =0;
	float spd= 0.2f;

	Rigidbody2D rg;
	// Use this for initialization
	void Start () {
		time =0;
		rg = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time++;
		if (spd > 0)
			spd -= 0.01f;
		rg.velocity= new Vector2 (0,spd);
		if (time > 50)
			Destroy (this.gameObject);
	}
}
