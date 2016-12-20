using UnityEngine;
using System.Collections;

public class EndingRoll : MonoBehaviour {
	TextMesh text;
	public WhiteFade wf;
	public AudioClip er;
	AudioSource audioSource; 
	bool isEnd = false;
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
		"Kousuke",
		"Madoca",
		"Sagawa",
		"Senzaki",
		"Mizuki",
		"Aika"
		
	};
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = er;
		audioSource.volume = 0.5f;
		audioSource.loop = true;
		audioSource.Play();
		text = GetComponent<TextMesh> ();
		text.text = "";
		for (int i = 0; i < endroll.Length; i++) {
			text.text += endroll [i] + "\n";
		}
	}
	public void Fade(){
		if (isEnd == false) {
			isEnd = true;
			wf.FadeOutCoroutine(()=>{Application.LoadLevel ("RankingEntry");});
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector2 (transform.position.x,transform.position.y+0.005f);

		if (transform.position.y > 7){
			if (audioSource.volume > 0)
				audioSource.volume -= 0.02f;
			if (audioSource.volume <= 0)
				audioSource.volume = 0;
			if (isEnd == false) {
				isEnd = true;

				wf.FadeOutCoroutine (() => {
					Application.LoadLevel ("RankingEntry");
				});
			}
		}
	}
}
