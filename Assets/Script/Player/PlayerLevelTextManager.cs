using UnityEngine;
using System.Collections;

public class PlayerLevelTextManager : MonoBehaviour {
	Player player;
	TextMesh text;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
//		EventManager.OnUpLevel.AddListener (UpLevel);
		text = GetComponent<TextMesh> ();
		UpLevel ();
	}
	
	// Update is called once per frame
	void UpLevel () {
	//	text.text = "" + player.RetLevel ();
	}
}
