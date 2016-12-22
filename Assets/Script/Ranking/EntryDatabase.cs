using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NCMB;
public class EntryDatabase : MonoBehaviour {
	public Text name;
	public Text comment;
	bool isSaveing = false;
	public void Send(){
		if(Statics.coin > 10&&isSaveing == false){
			isSaveing = true;
			Statics.coin -= 10;
			Statics.Save ();
		NCMBObject testRank = new NCMBObject("Ranking");


		// オブジェクトに値を設定

		testRank["name"] = name.text;
		if(name.text == "")testRank["name"] ="No name";
			testRank["character"] = Statics.charactor;
		testRank["score"] =Statics.score;
		testRank["combo"] =Statics.comboMax;
		testRank["level"] =Statics.level;
		testRank["isCleard"] =Statics.isCleard;
		//testRank["score"] =Statics.score;
		testRank["comment"] = comment.text;
		// データストアへの登録
		testRank.SaveAsync(new NCMBCallback ((NCMBException e)=>{Application.LoadLevel ("Ranking"); Statics.objectId = testRank.ObjectId;}));
	}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
