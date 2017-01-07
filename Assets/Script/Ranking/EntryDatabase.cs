using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;
using NCMB;
public class EntryDatabase : MonoBehaviour {
	[DllImport ("__Internal")]
	private static extern int ViewFkinPolicy();
	public Text name;
	public Text comment;
	bool isSaveing = false;
	/*void Start(){
		#if !UNITY_EDITOR && UNITY_IOS
		ViewFkinPolicy();
		#endif
	}*/
	public void Send(){
		bool policy = true;


		if(Statics.coin > 10&&isSaveing == false){
			#if !UNITY_EDITOR && UNITY_IOS
			policy = false;
			int vfp = ViewFkinPolicy();
			if(vfp == 1)policy = true;
			#endif
			if (policy == true) {
				isSaveing = true;
				Statics.coin -= 10;
				Statics.Save ();
				NCMBObject testRank = new NCMBObject ("Ranking");
				// オブジェクトに値を設定

				testRank ["name"] = name.text;
				if (name.text == "")
					testRank ["name"] = "No name";
				testRank ["character"] = Statics.charactor;
				testRank ["score"] = Statics.score;
				testRank ["combo"] = Statics.comboMax;
				testRank ["level"] = Statics.level;
				testRank ["isCleard"] = Statics.isCleard;
				//testRank["score"] =Statics.score;
				testRank ["comment"] = comment.text;
				// データストアへの登録
				testRank.SaveAsync (new NCMBCallback ((NCMBException e) => {
					Application.LoadLevel ("Ranking");
					Statics.objectId = testRank.ObjectId;
				}));
			}
	}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
