using UnityEngine;
using System.Collections;

public class Boss04Break : MonoBehaviour {
	public GameObject bossNext;
	public GameObject particle1;
	public GameObject  particle2;
	public GameObject  particle3;
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
			GameObject o = (GameObject)Instantiate (bossNext, transform.position, Quaternion.identity);
			Instantiate (particle1, transform.position + new Vector3(0,0.4f,0), Quaternion.identity);
			Instantiate (particle2, transform.position + new Vector3(-0.3f,0.2f,0), Quaternion.identity);
			Instantiate (particle3, transform.position + new Vector3(0.3f,0.4f,0), Quaternion.identity);
			EventManager.InvokeGameObjectArg (ref EventManager.OnChangeBoss, o);
			EventManager.Invoke (ref EventManager.OnDestroyBoss04Break);
			Destroy (this.gameObject);
		}
	}
}
