using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NCMB;
public class Rankers{
	string name;
	int charactor;
	string comment;
	int score;
	public Rankers(string n,int s,int cc, string cm){
		this.name = n;
		this.score = s;
		this.charactor = cc;
		this.comment = cm;
	}
}
public class Ranking : MonoBehaviour {
	public GameObject template;
	public List<Texture> texture;
	//List<GameObject>rankingList;
	//List<Rankers> list = new List<Rankers>();
	Camera cam;
	float limitY = 0;
	float accY = 0;
	// Use this for initialization
	void Send(int i){
		NCMBObject testRank = new NCMBObject("Ranking");

		// オブジェクトに値を設定
		testRank["name"] = "てすたろう";
		testRank["character"] = 0;
		testRank["score"] = 1000+i*500;
		testRank["combo"] = i+1;
		testRank["isCleard"] = 1000;
		testRank["level"] = 0;
		testRank["comment"] = "おたま";
		// データストアへの登録
		testRank.SaveAsync(new NCMBCallback ((NCMBException e)=>{Debug.Log("succeed");}));
	}
	void Get(){
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("Ranking");
		query.OrderByDescending ("score");
		query.Limit = 20;
		query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {

			if (e != null) {
				//検索失敗時の処理
				Debug.Log("error");
			} else {
				Debug.Log (Statics.objectId);
				//検索成功時の処理
				int rank = 1;
				// 取得したレコードをscoreクラスとして保存
				foreach (NCMBObject obj in objList) {
					int    s = System.Convert.ToInt32(obj["score"]);
					int    combo = System.Convert.ToInt32(obj["combo"]);
					string n = System.Convert.ToString(obj["name"]);
					int cc = System.Convert.ToInt32(obj["character"]);
					int lv = System.Convert.ToInt32(obj["level"]);
					int cl = System.Convert.ToInt32(obj["isCleard"]);
					string cm = System.Convert.ToString(obj["comment"]);
					//list.Add( new Rankers( n, s , cc, cm)  );
					GameObject co = (GameObject)Instantiate(template,new Vector3(0,0,0),Quaternion.identity);
					co.transform.parent = this.transform;
					co.transform.GetComponent<RectTransform>().localPosition = new Vector3(0,-(rank-1)*100,0);
					co.transform.FindChild("Rank").GetComponent<Text>().text = rank+".";
					if(rank == 1)co.transform.FindChild("Rank").GetComponent<Text>().color = new Color(0.4f,0.3f,0f);
					if(rank == 1)co.transform.FindChild("Score").GetComponent<Text>().color = new Color(0.4f,0.3f,0f);
					if(rank == 1)co.transform.FindChild("Combo").GetComponent<Text>().color = new Color(0.6f,0.3f,0f);
					if(rank == 1)co.transform.FindChild("RawImage").GetComponent<RawImage>().color = new Color(0.9f,0.7f,0f);
					if(rank == 3)co.transform.FindChild("RawImage").GetComponent<RawImage>().color = new Color(0.8f,0.4f,0.3f);
					if(rank == 2)co.transform.FindChild("RawImage").GetComponent<RawImage>().color = new Color(0.6f,0.6f,0.7f);
					if(cl == 1)co.transform.FindChild("Clear").GetComponent<RawImage>().enabled=true;
					else co.transform.FindChild("Clear").GetComponent<RawImage>().enabled=false;
					if(lv == 2)co.transform.FindChild("Hard").GetComponent<RawImage>().enabled=true;
					else co.transform.FindChild("Hard").GetComponent<RawImage>().enabled=false;
					co.transform.FindChild("Character").GetComponent<RawImage>().texture = texture[cc];
					co.transform.FindChild("Name").GetComponent<Text>().text = n;
					co.transform.FindChild("Combo").GetComponent<Text>().text = "<color=#333311>max:</color>"+combo+"<color=#333311>combo</color>";
					//co.transform.FindChild("Character").GetComponent<RawImage>().img = cc;
					co.transform.FindChild("Score").GetComponent<Text>().text = ""+s;
					co.transform.FindChild("Comment").GetComponent<Text>().text = cm;
					co.transform.localScale = new Vector3(1,1,1);
					if(obj.ObjectId == Statics.objectId){
						co.transform.FindChild("Rank").GetComponent<Text>().color =Color.yellow;
						co.transform.FindChild("Name").GetComponent<Text>().color =Color.yellow;

					}
					//Debug.Log(""+s+","+n);
					rank++;
					limitY+=100;

				}
				//topRankers = list;
				accY=15;
				dir = false;
				GetComponent<RectTransform> ().localPosition = new Vector3 (0, limitY, 0);
				Statics.objectId = "";
				Statics.score=0;
				Statics.combo=0;
			}
		});


	}
	void Start () {
		//for(int i=0;i<15;i++)Send (i);

		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		Get ();

		EventManager.OnTouchBegin.AddListener (Move);
		EventManager.OnTouchMove.AddListener (Move);
		EventManager.OnTouchEnd.AddListener (EndMove);
	}
	void AddRank(int rank){
	}
	// Update is called once per frame
	void Update () {
		if (accY > 0) {
			accY -= 0.05f;
			if (dir == true) {
				GetComponent<RectTransform> ().localPosition += new Vector3 (0, accY, 0);
			}
			if (dir == false) {
				GetComponent<RectTransform> ().localPosition += new Vector3 (0, -accY, 0);
			}
			if(GetComponent<RectTransform> ().localPosition.y<0)GetComponent<RectTransform> ().localPosition = new Vector3 (0, 0, 0);
			if(GetComponent<RectTransform> ().localPosition.y>limitY)GetComponent<RectTransform> ().localPosition = new Vector3 (0, limitY, 0);

		}
		
	}
	float? beforeY = null;
	float d=0;
	bool dir = false;
	void Move(int num){
		if (num == 0) {
			accY = 0;
		if (beforeY != null) {
			    d = TouchInput.GetTouchWorldPosition (cam, num).y - (float)beforeY;
				GetComponent<RectTransform> ().localPosition += new Vector3 (0, d*100, 0);
				if(GetComponent<RectTransform> ().localPosition.y<0)GetComponent<RectTransform> ().localPosition = new Vector3 (0, 0, 0);
				if(GetComponent<RectTransform> ().localPosition.y>limitY)GetComponent<RectTransform> ().localPosition = new Vector3 (0, limitY, 0);

		}
			beforeY = TouchInput.GetTouchWorldPosition (cam, num).y;
		//	Debug.Log (d + "");
		}
	}
	void EndMove(int num){
		if (num == 0) {
		//	Debug.Log (d + "aa");
		//	float d = (TouchInput.GetTouchWorldPosition (cam, num).y - (float)beforeY)*100;
			if (d < 0) {
				accY = -d*100;
				dir = false;
			} else {
				accY = d*100;
				dir = true;
			}
			beforeY = null;
		}
	}
}
