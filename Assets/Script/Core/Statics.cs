using UnityEngine;
using System.Collections;

public static class Statics{
	static public ulong score = 0;
	static public int combo = 0;
	static public int comboMax = 0;
	static public int coin = 0;
	static public int level = 0;
	static public int isCleard = 0;
	static public int  charactor= 0;
	static public int unlockHard = 0;
	static public int unlockChara = 0;
	static public bool isWatchOpening = false;
	//static public Rankers myRecord=new Rankers("",0,0,"");
	static public string objectId;
	static public void Reset(){
		coin = 0;
		score = 0;
		combo = 0;
		level = 0;
		comboMax = 0;
		charactor= 0;
		unlockHard = 0;
		unlockChara = 0;
		isCleard = 0;
	}
	static public void SaveUnlock(){
		PlayerPrefs.SetInt ("hard",unlockHard);
		PlayerPrefs.SetInt ("chara",unlockChara);
	}
	static public void LoadUnlock(){
		if (PlayerPrefs.HasKey ("hard"))unlockHard = PlayerPrefs.GetInt ("hard");
		if (PlayerPrefs.HasKey ("chara"))unlockChara = PlayerPrefs.GetInt ("chara");
	}
	static public void Save(){
		PlayerPrefs.SetInt ("coin",coin);
		Debug.Log ("coinsave");
	}
	static public void Load(){
		if (PlayerPrefs.HasKey ("coin")) {
			coin = PlayerPrefs.GetInt ("coin");
		} else
			Debug.Log ("nocoin");
	}
}
