using UnityEngine;
using System.Collections;

public class ComboManager : MonoBehaviour {
	//int combo = 0;
	float speed;
	TextMesh text;
	// Use this for initialization
	void Start () {
		speed = 0;
		Statics.combo = 0;
		text = GetComponent<TextMesh> ();
		text.text = "";
		EventManager.OnEnemyHit.AddListener (Hit);
		EventManager.OnEndCombo.AddListener (End);
	}

	void Hit(){
		Statics.combo++;
		text.text = "<size=180><color=#dd3300>" + Statics.combo + "</color></size>combo!!\n";
	//	if(Statics.combo>=25)text.text +="size <color=#ffaa22>x3.0</color>!!!";
	//	else if(Statics.combo>=20)text.text +="size <color=#ffaa22>x2.5</color>!!!";
	//	else if(Statics.combo>=15)text.text +="size <color=#ffaa22>x2.0</color>!!!";
	//	else if(Statics.combo>=10)text.text +="size <color=#ffaa22>x1.5</color>!!!";
		speed = 1;
		StartCoroutine ("Renew");
	}
	void End(){
		text.text = "";
		Statics.combo = 0;
	}
	IEnumerator Renew(){
		while(speed>0){
		speed -= 0.05f;
			transform.position = new Vector2 (transform.position.x,1.1f + speed/20);
			yield return new WaitForEndOfFrame();
		}
	}
}
