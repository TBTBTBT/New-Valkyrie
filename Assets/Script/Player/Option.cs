using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Option : MonoBehaviour {
	Player player;
	GameObject parent;
	List<Vector2> pos;
	List<float> scale;
	int max = 15;
	int dir = 1;
	int num = 0;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		pos = new List<Vector2>();
		scale = new List<float>();
		while (true) {
			GameObject f = GameObject.Find ("Option" + num);
			if (f == null)
				break;
			num++;
		}
		if (num != 0) {
			parent = GameObject.Find ("Option" + (num - 1));
			transform.position = new Vector3 (parent.transform.position.x,parent.transform.position.y, 0);
		} else {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, 0);
		}
		max = 15;
		this.gameObject.name = "Option" + num;


		EventManager.OnPlayerAttacked.AddListener (Attack);
	}

	void Attack(){
		if(player.RetHP()>0){
			GameObject b = (GameObject)Instantiate (player.bullet, transform.position, Quaternion.identity);
			if (b.GetComponent<BulletBase> ())
				b.GetComponent<BulletBase> ().SetPower (player.RetCharge(),dir);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (player.isMove == true) {
			if (num == 0) {
				pos.Add (new Vector2 (player.transform.position.x, player.transform.position.y));
				scale.Add (player.transform.localScale.x);
			} else {
				pos.Add (new Vector2 (parent.transform.position.x, parent.transform.position.y));
				scale.Add (parent.transform.localScale.x);
			}
			if (pos.Count > max) {
				transform.position = pos [0];
				if (scale [0] < 0)
					dir = -1;
				else
					dir = 1;
				transform.localScale= new Vector2(scale [0],2);
				pos.RemoveAt (0);
				scale.RemoveAt (0);
			}
		}
	}
}
