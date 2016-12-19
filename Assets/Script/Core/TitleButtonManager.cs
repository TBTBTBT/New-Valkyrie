using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
			Application.LoadLevel ("Ranking");
		}
	}
	public void PushNormal(){
		if (!Application.isShowingSplashScreen) {
			//スプラッシュ表示後
			if (Statics.isWatchOpening == false) {
				Statics.isWatchOpening = true;
				Application.LoadLevel ("Opening");
			} else {
				Application.LoadLevel ("Stage01");
			}
		}
	//	start.gameObject.SetActive (false);
	}
	public void PushHard(){
		if (!Application.isShowingSplashScreen) {
			//スプラッシュ表示後
			if (Statics.isWatchOpening == false) {
				Statics.isWatchOpening = true;
				Application.LoadLevel ("Opening");
			} else {
				Application.LoadLevel ("Stage01");
			}
		}
	//	start.gameObject.SetActive (false);
	}
	public void PushExtra(){
	//	start.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
