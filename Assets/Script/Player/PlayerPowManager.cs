using UnityEngine;
using System.Collections;

public class PlayerPowManager : MonoBehaviour {

	Player player;
	TextMesh text;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		EventManager.OnUpPower.AddListener (Hp);
		text = GetComponent<TextMesh> ();
		Hp ();
	}

	// Update is called once per frame
	void Hp () {
		text.text =   ""+player.RetPowLevel();
	}
}
