using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class TitleButtonManager : MonoBehaviour {
	public Button start;
	public Button ranking;
	public Button normal;
	public Button hard;
	public Button extra;
	public Button back;
	// Use this for initialization
	void Start () {
		//start.gameObject.SetActive (false);
	//	start.gameObject.SetActive (true);
		normal.gameObject.SetActive (false);
		hard.gameObject.SetActive (false);
		extra.gameObject.SetActive (false);
		back.gameObject.SetActive (false);
		Statics.Reset();
	}
	public void PushStart(){
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
			Statics.level = 2;
			if (Statics.isWatchOpening == false) {
				Statics.isWatchOpening = true;
				SceneManager.LoadScene  ("Opening");

			} else {
			SceneManager.LoadScene ("Stage01");
			//	if(Statics.charactor == 1)SceneManager.LoadScene ("Stage02");
			}
		}
	//	start.gameObject.SetActive (false);
	}
	public void PushExtra(){
		switch (Statics.charactor) {
		case 0:
			Statics.charactor = 1;
			break;
		case 1:
			Statics.charactor = 0;
			break;

		}
	//	start.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
