using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class TitleButtonManager : MonoBehaviour {
	public List<Texture> s;
	public Button start;
	public Button ranking;
	public Button normal;
	public Button hard;
	public Button extra;
	public Button back;
	public Text cointext;
	// Use this for initialization
	void CheckUnlock(){
		cointext.text = "";
		if (Statics.unlockHard == 1) {
			ColorBlock c = hard.GetComponent<Button> ().colors;
			c.normalColor = new Color (1f, 0.4f, 0.6f);
			hard.colors = c;
			hard.GetComponentInChildren<Text>().text = "Hard";
			hard.enabled = false;
			hard.enabled = true;
		}
		//if (Statics.unlockChara == 0) {
		//}
		//extra.GetComponentInChildren<RawImage> ().enabled = true;
		if (Statics.unlockChara == 1) {
			extra.GetComponentInChildren<Text> ().text = "";
		//	Debug.Log (Statics.charactor);
			if (Statics.charactor == 0) {
				extra.GetComponentInChildren<RawImage> ().enabled = true;
				extra.GetComponentInChildren<RawImage> ().texture = s [0];
				ColorBlock c = extra.GetComponent<Button> ().colors;
				c.normalColor =  new Color (1f, 1f, 1f);
				extra.colors = c;
				extra.enabled = false;
				extra.enabled = true;

			}
			if (Statics.charactor == 1) {
				extra.GetComponentInChildren<RawImage> ().enabled = true;
				extra.GetComponentInChildren<RawImage> ().texture = s [1];
				ColorBlock c = extra.GetComponent<Button> ().colors;
				c.normalColor = new Color (1f, 0.4f, 0.6f);
				extra.colors = c;
				//extra.GetComponentInChildren<Text> ().text = "";
				//Debug.Log (extra.colors.normalColor);
				extra.enabled = false;
				extra.enabled = true;
			}
		}
	}
	void Start () {
		//start.gameObject.SetActive (false);
	//	start.gameObject.SetActive (true);
		normal.gameObject.SetActive (false);
		hard.gameObject.SetActive (false);
		extra.gameObject.SetActive (false);
		back.gameObject.SetActive (false);
		Statics.Reset();
		Statics.Load ();
		Statics.LoadUnlock ();
		CheckUnlock ();
	}
	public void PushStart(){
		CheckUnlock ();
		start.gameObject.SetActive (false);
		ranking.gameObject.SetActive (false);
		normal.gameObject.SetActive (true);
		hard.gameObject.SetActive (true);
		extra.gameObject.SetActive (true);
		back.gameObject.SetActive (true);

	}
	public void PushBack(){
		start.gameObject.SetActive (true);
		ranking.gameObject.SetActive (true);
		normal.gameObject.SetActive (false);
		hard.gameObject.SetActive (false);
		extra.gameObject.SetActive (false);
		back.gameObject.SetActive (false);
	}
	public void PushRanking(){
		//start.gameObject.SetActive (false);
		if (!Application.isShowingSplashScreen) {
			//スプラッシュ表示後
			SceneManager.LoadScene  ("Ranking");
		}
	}
	public void PushNormal(){
		if (!Application.isShowingSplashScreen) {
			//スプラッシュ表示後
			Statics.level = 0;
			if (Statics.isWatchOpening == false) {
				Statics.isWatchOpening = true;
				SceneManager.LoadScene ("Opening");
			} else {
				SceneManager.LoadScene ("Stage01");
						}
		}
	//	start.gameObject.SetActive (false);
	}

	public void PushHard(){
		if (!Application.isShowingSplashScreen) {
			//スプラッシュ表示後

			if (Statics.unlockHard == 1) {
				Statics.level = 2;
				if (Statics.isWatchOpening == false) {
					Statics.isWatchOpening = true;
					SceneManager.LoadScene ("Opening");

				} else {
					SceneManager.LoadScene ("Stage01");
					//	if(Statics.charactor == 1)SceneManager.LoadScene ("Stage02");
				}
			}
			if (Statics.unlockHard == 0) {
				if (Statics.coin >= 70) {
					Statics.coin -= 70;
					Statics.Save ();
					Statics.unlockHard = 1;
					Statics.SaveUnlock ();
					CheckUnlock ();

				}else {
					cointext.text = "コインが足りません";
				}
			}
		}
	//	start.gameObject.SetActive (false);
	}
	public void PushExtra(){
		
		if (Statics.unlockChara == 1) {
			switch (Statics.charactor) {
			case 0:
				Statics.charactor = 1;
				CheckUnlock ();
				break;
			case 1:
				Statics.charactor = 0;
				CheckUnlock ();
				break;

			}
		}
		if (Statics.unlockChara == 0) {
			if (Statics.coin >= 100) {
				Statics.coin -= 100;
				Statics.Save ();
				Statics.unlockChara = 1;
				CheckUnlock ();
				Statics.SaveUnlock ();
			} else {
				cointext.text = "コインが足りません";
			}
				
		}
	//	start.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
