using UnityEngine;
using System.Collections;

public class PlayerHpManager : MonoBehaviour {
	Player player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector2 (40 * (float)player.RetHP() /(float)player.RetMaxHP(),transform.localScale.y);
	}
}
