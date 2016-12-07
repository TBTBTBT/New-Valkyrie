using UnityEngine;
using System.Collections;

public class PlayerEffector : MonoBehaviour {
	public GameObject jump;
	public GameObject cat;
	public GameObject hp;
	public GameObject pow;
	public GameObject spd;
	public GameObject siz;

	// Use this for initialization
	void Start () {
		EventManager.OnJump.AddListener (Jump);
		EventManager.OnUpPower.AddListener (POW);
		EventManager.OnUpHp.AddListener (HP);
		EventManager.OnUpSpd.AddListener (SPD);
		EventManager.OnCatch.AddListener (Catch);
		EventManager.OnUpSize.AddListener (SIZ);
	}
	
	// Update is called once per frame
	void Jump () {
		Instantiate (jump,new Vector3(transform.position.x+0.1f,transform.position.y-0.1f,1),Quaternion.identity);
		Instantiate (jump,new Vector3(transform.position.x-0.1f,transform.position.y-0.1f,-1),Quaternion.identity);
	
	}
	void Catch () {
		Instantiate (cat,new Vector3(transform.position.x,transform.position.y+0.2f,0),Quaternion.identity);

	}
	void POW () {
		Instantiate (pow,new Vector3(transform.position.x,transform.position.y+0.2f,0),Quaternion.identity);

	}
	void HP () {
		Instantiate (hp,new Vector3(transform.position.x,transform.position.y+0.2f,0),Quaternion.identity);

	}
	void SIZ() {
		Instantiate (siz,new Vector3(transform.position.x,transform.position.y+0.2f,0),Quaternion.identity);

	}
	void SPD () {
		Instantiate (spd,new Vector3(transform.position.x,transform.position.y+0.2f,0),Quaternion.identity);

	}
}
