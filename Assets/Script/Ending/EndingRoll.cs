using UnityEngine;
using System.Collections;

public class EndingRoll : MonoBehaviour {
	TextMesh text;
	string[] endroll = new string[]{
		"<size=350>Valkyrie's Axe</size>",
		"<size=350>CRESITS</size>\n",
		"<size=250>Planning</size>\n",
		"TBT",
		"\n<size=250>Graphic Design</size>\n",
		"TBT",
		"ton",
		"\n<size=250>Sound</size>\n",
		"TBT",
		"\n<size=250>Programming</size>\n",
		"TBT",
		"\n<size=250>Special Thanks</size>\n",
		"Kosuke",
		"Madoca",
		"Sagawa",
		"Senzaki",
		"Mizuki"
		
	};
	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh> ();
		text.text = "";
		for (int i = 0; i < endroll.Length; i++) {
			text.text += endroll [i] + "\n";
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector2 (transform.position.x,transform.position.y+0.005f);
	}
}
