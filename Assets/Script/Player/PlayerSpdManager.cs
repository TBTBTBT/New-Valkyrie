using UnityEngine;
using System.Collections;

public class PlayerSpdManager : MonoBehaviour {
	Player player;
	TextMesh text;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		EventManager.OnUpSpd.AddListener (Text);
		text = GetComponent<TextMesh> ();
		Text ();
	}

	// Update is called once per frame
	void Text () {
		text.text = ""+ player.RetSpdLevel();
	}
}
