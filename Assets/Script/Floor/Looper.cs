using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {
	Vector3 loopPos;
	public float speed = 0.01f;
	public float loopMax = 0.32f;
	// Use this for initialization
	void Start () {
		loopPos = transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (transform.position.x - speed,transform.position.y,transform.position.z);
		if (transform.position.x < loopPos.x) {
			transform.position = new Vector3 (transform.position.x + loopMax,transform.position.y,transform.position.z);
		}
	}
}
