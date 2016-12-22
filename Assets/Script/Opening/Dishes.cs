using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class Dishes : MonoBehaviour {
	Rigidbody2D rg;
	float spd = 0;
	float angle = 0;
	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D> ();
		spd = Random.Range (0.8f, 1.5f);
		rg.velocity = new Vector2(spd,Random.Range(1.5f,2.5f));
	}
	
	// Update is called once per frame
	void Update () {
		angle -= 10;
		transform.rotation = Quaternion.AngleAxis (angle,new Vector3(0,0,1));
		//transform.localRotation = Quaternion.AngleAxis
		rg.velocity = new Vector2(spd,rg.velocity.y - 0.1f);
		if(transform.position.y<-1.2)Destroy(this.gameObject);
	}
}
