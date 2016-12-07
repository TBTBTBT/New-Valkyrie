using UnityEngine;
using System.Collections;

public class EnemyEffectManager : MonoBehaviour {

	public GameObject hit;
	// Use this for initialization
	void Start () {
		EventManager.OnJump.AddListener (Hit);
	}

	// Update is called once per frame
	void Hit () {
		Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
		Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
		Instantiate (hit,new Vector3(transform.position.x,transform.position.y,0),Quaternion.identity);
	}
}
