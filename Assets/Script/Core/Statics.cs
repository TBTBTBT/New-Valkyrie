using UnityEngine;
using System.Collections;

public static class Statics{
	static public ulong score = 0;
	static public int combo = 0;
	static public int coin = 0;
	static public bool isWatchOpening = false;
	//static public Rankers myRecord=new Rankers("",0,0,"");
	static public string objectId;
	static public void Reset(){
		coin = 0;
		score = 0;
		combo = 0;
		
	}

		
}
