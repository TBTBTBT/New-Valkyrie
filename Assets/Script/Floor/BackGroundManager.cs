using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackGroundManager : MonoBehaviour {
	public List<GameObject>BGList;
	List<GameObject>BGInsList;
	//GameObject floor;
	//GameObject floornext;
	//GameObject bg;
	//GameObject bgnext;
	int bgNum = 0;
	int bgNumBefore = 0;
	bool isChange = false;
	// Use this for initialization
	void Start () {
		BGInsList = new List<GameObject>();
		for (int i = 0; i < BGList.Count; i++) {
			GameObject b = (GameObject)Instantiate (BGList [i]);
			BGInsList.Add (b);
			if (i != bgNum)
				RendererStop (BGInsList [i]);
		}
		//StartChange ();
	}
	void RendererStop(GameObject g){
		g.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,0);
		foreach(Transform c in g.transform){
			c.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,0);
		}
	}
	void RendererStart(GameObject g){
		g.GetComponent<SpriteRenderer> ().color +=new Color(0,0,0,0.01f);
		if (g.GetComponent<SpriteRenderer> ().color.a >= 1) {
			g.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		}
		foreach(Transform c in g.transform){
			c.GetComponent<SpriteRenderer> ().color +=new Color(0,0,0,0.01f);
			if (c.GetComponent<SpriteRenderer> ().color.a >= 1) {
				c.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,1);
			}
		}
	}
	void RendererFade(GameObject g){
		g.GetComponent<SpriteRenderer> ().color -=new Color(0,0,0,0.01f);
		if (g.GetComponent<SpriteRenderer> ().color.a <= 0) {
			g.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
		}
		foreach(Transform c in g.transform){
			c.GetComponent<SpriteRenderer> ().color -=new Color(0,0,0,0.01f);
			if (c.GetComponent<SpriteRenderer> ().color.a <= 0) {
				c.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,0);
				isChange = false;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if (isChange == true) {
			RendererStart (BGInsList [bgNum]);
			RendererFade (BGInsList [bgNumBefore]);
		}
	}
	public void StartChange(int i) {
		if ((BGList.Count) > i && i != bgNum) {
			BGInsList [i].transform.position -= new Vector3 (0, 0, 1);
			bgNumBefore = bgNum;
			bgNum=i;
			isChange = true;
		}

	}
}
