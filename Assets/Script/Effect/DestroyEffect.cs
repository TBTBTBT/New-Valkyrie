using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {
	int time =0;
	public float spd= 1.6f;
	float angle = 0;
	float r = 0;
	Rigidbody2D rg;
	// Use this for initialization
	void Start () {
		time =0;
		angle = Random.Range (0, 360);
		rg = GetComponent<Rigidbody2D> ();
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		r += 20;
		transform.rotation = Quaternion.AngleAxis(r,new Vector3(0,0,1));
		time++;
		if (spd > 0)
			spd -= 0.1f;
		rg.velocity= new Vector2 (spd*Mathf.Cos (angle*Mathf.PI/180),spd*Mathf.Sin (angle*Mathf.PI/180));
		if (time > 10)
			Destroy (this.gameObject);
	}
}
