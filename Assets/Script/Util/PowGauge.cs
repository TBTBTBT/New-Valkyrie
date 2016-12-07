using UnityEngine;
using System.Collections;

public class PowGauge : MonoBehaviour {
	Player player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (40 * player.RetPow() / 3f,1,1);
	}
}
