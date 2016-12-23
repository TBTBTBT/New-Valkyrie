using UnityEngine;
using System.Collections;

public class Boss05Break : MonoBehaviour {
	public GameObject hit;
	Player player;
	int actTime = 0;
	Vector2 pos;

	// Use this for initialization
	void Start () {
		actTime = 0;
		pos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		actTime++;
		transform.position = pos + new Vector2 (Mathf.Sin(actTime * 80*Mathf.PI/180)*0.1f,0);
		if (actTime > 120) {
			Instantiate (hit, transform.position + new Vector3(0,-0.04f,0), Quaternion.identity);
			Instantiate (hit, transform.position + new Vector3(0,-0.04f,0), Quaternion.identity);
			Instantiate (hit, transform.position + new Vector3(0,-0.04f,0), Quaternion.identity);
			EventManager.Invoke (ref EventManager.OnDestroyBoss05Break);
			Destroy (this.gameObject);
		}
	}
}
