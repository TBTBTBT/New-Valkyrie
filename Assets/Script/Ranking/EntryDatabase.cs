using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NCMB;
public class EntryDatabase : MonoBehaviour {
	public Text name;
	public Text comment;
	public void Send(){
		NCMBObject testRank = new NCMBObject("TestRank");


		// オブジェクトに値を設定

		testRank["name"] = name.text;
		if(name.text == "")testRank["name"] ="No name";
		testRank["character"] = 0;
		testRank["score"] =Statics.score;
		testRank["comment"] = comment.text;
		// データストアへの登録
		testRank.SaveAsync(new NCMBCallback ((NCMBException e)=>{Application.LoadLevel ("Ranking"); Statics.objectId = testRank.ObjectId;}));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
