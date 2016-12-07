using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {
	int time = 0;
	float o = 0;
	SpriteRenderer r ;
	// Use this for initialization
	void Start () {
		time = 0;
		r = GetComponent<SpriteRenderer> ();
		r.color = new Color (1,1,1,0);
		o = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Application.isShowingSplashScreen) {
			time++;
			if (time < 30) {
				if (o < 1)
					o += 0.05f;
				if (o > 1)
					o = 1;
			
			}
			if (time > 90) {
				if (o > 0)
					o -= 0.05f;
				if (o < 0)
					o = 0;

			}
			r.color = new Color (1, 1, 1, o);
			if (time > 120) {
				Application.LoadLevel ("Title");
			}
		}
	}
}
