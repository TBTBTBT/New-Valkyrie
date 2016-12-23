using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawnerBase : MonoBehaviour {
	public List<GameObject> player;
	public List<GameObject> enemyList1;
	public List<GameObject> enemyList2;
	public List<GameObject> enemyList3;
	public List<GameObject> bossList;
	public InfoManager im;
	int time =0;
	int timeMax = 600;
	int enemynum = 0;
	int level = 0;
	int newLevel = 0;
	public int spawnNum = 1;
	public int stage = 1;
	int stageMax = 4;
	GameObject bossIns;
	public BackGroundManager BGManager;
	public WhiteFade wf;
	bool isBossSpawn= false;
	void Awake(){
		if (Statics.charactor < player.Count) {
			Instantiate (player [Statics.charactor], new Vector3 (0, 0, 0), Quaternion.identity);
		}
		else {
			Instantiate (player [0], new Vector3 (0, 0, 0), Quaternion.identity);
		}
	}
	// Use this for initialization
	void Start () {
		time =590;
		isBossSpawn= false;
		EventManager.OnChangeBoss.AddListener (ChangeBoss);
		newLevel = Statics.level;
		//level = 10;
		//enemynum = 3;
	}
	void Spawn(int i,Vector3 pos,List<GameObject> enemyList){
		if (i < enemyList.Count) {
			Instantiate (enemyList [i], pos, Quaternion.identity);
		}
	}
	void BossSpawn(int i,Vector3 pos){
		if (i < bossList.Count) {
			bossIns = (GameObject)Instantiate (bossList [i], pos, Quaternion.identity);
		}
	}
	void ChangeBoss(GameObject o){
		bossIns = o;
	}
	// Update is called once per frame
	void FixedUpdate () {
		time++;
		if (isBossSpawn == true) {
			if (bossIns == null) {
			//	if (timeMax > 100)
			//		timeMax -= 40;
				spawnNum = 1;
				isBossSpawn = false;
				time = 0;
				timeMax =300;

				if (stage < stageMax) {
					im.StageText ("Stage "+stage+"\nClear!!",new Color(0.2f,0.2f,0.2f));
					stage++;
				}
				else {
					wf.FadeOutCoroutine (()=>{Application.LoadLevel("EndingMovie");});
					spawnNum++;
					Statics.isCleard = 1;
					//stage = 1;
				}

				//level += 10;
			}
		}
		if (time > timeMax) {
			
			/*
			enpc++;
			if (enpc > 5) {
				enpc = 0;
				if (enemynum < enemyList.Count) {
					enemynum++;
					if (enemynum > enemyList.Count)
						enemynum = enemyList.Count;
				}

			}*/
			//if(timeMax > 30)timeMax--;
			time = 0;
			//int hp = (240 - timeMax) / 3;
			////Spawn (Random.Range (0, enemynum), new Vector3 (-3.33f + 6.66f * Random.Range (0, 2), Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp));
			if (spawnNum > 12)
				spawnNum = 12;
			if (stage == 1) {
				Stage1 ();
			}
			if (stage == 2) {
				Stage2 ();
			}
			if (stage == 3) {
				Stage3 ();
			}
			if (stage == 4) {
				Stage4 ();
			}
		}
		//Debug.Log (spawnNum);
	}
	void Stage1(){
		switch (spawnNum) {
		case 1:
			EventManager.InvokeIntArg (ref EventManager.OnStartStage, 1);
			BGManager.StartChange (0);
			im.StageText ("Stage "+stage+"\n\"Green Field\"",new Color(0.1f,0.3f,0.2f));
			spawnNum++;
			StartCoroutine (Wave1 (1, 0, level + 1, enemyList1));
			timeMax = 300;
			break;
		case 2:
			spawnNum++;
			StartCoroutine (Wave1 (0, 1, level + 1, enemyList1));
			timeMax = 300;
			break;
		case 3:
			spawnNum++;
			StartCoroutine (Wave1 (1, 0, level + 1, enemyList1));
			StartCoroutine (Wave1 (0, 2, level + 1, enemyList1));
			timeMax = 600;
			break;
		case 4:
			spawnNum++;
			StartCoroutine (Wave2 (1, 3, level + 2, enemyList1));
			StartCoroutine (Wave1 (0, Random.Range (0, 3), level + 2, enemyList1));
			//StartCoroutine(Wave(0,0));
			break;
		case 5:
			spawnNum++;
			StartCoroutine (Wave3 (0, 3, level + 3, enemyList1));
			StartCoroutine (Wave1 (0, 4, level + 3, enemyList1));
			//StartCoroutine(Wave(0,0));
			break;
		case 6:
			spawnNum++;
			StartCoroutine (Wave3 (1, 4, level + 3, enemyList1));
			StartCoroutine (Wave3 (0, 4, level + 3, enemyList1));
			break;
		case 7:
			spawnNum++;
			StartCoroutine (Wave3 (1, 5, level + 3, enemyList1));
			StartCoroutine (Wave3 (0, 3, level + 3, enemyList1));
			StartCoroutine (Wave1 (1, Random.Range (0, 3), level + 3, enemyList1));
			break;
		case 8:
			spawnNum++;
			//StartCoroutine(Wave4(1,6,level));
			StartCoroutine (Wave5 (1, 7, level + 3, enemyList1));
			break;
		case 9:
			spawnNum++;
			//StartCoroutine(Wave4(1,6,level));
			StartCoroutine (Wave1 (0, 2, level + 4, enemyList1));
			StartCoroutine (Wave5 (1, 7, level + 4, enemyList1));
			StartCoroutine (Wave5 (0, 7, level + 4, enemyList1));
			break;
		case 10:
			spawnNum++;
			//StartCoroutine(Wave4(1,6,level));
			StartCoroutine (Wave3 (0, Random.Range (3, 6), level + 4, enemyList1));
			StartCoroutine (Wave4 (1, 6, level + 4, enemyList1));
			break;
		case 11:
			if (isBossSpawn == false) {
				EventManager.Invoke (ref EventManager.OnSpawnBoss);
				BossSpawn (0, new Vector3 (1.2f, 2f, 0));
				isBossSpawn = true;
			}
			break;
		case 12:
			
			///spawnNum++;
			//spawnNum = 1;
			//timeMax = 10;
			break;
		}
	}
	void Stage2(){
		switch (spawnNum) {
		case 1:
			EventManager.InvokeIntArg (ref EventManager.OnStartStage, 2);
			im.StageText ("Stage "+stage+"\n\"Ice Cave\"",new Color(0.1f,0.2f,0.3f));
			BGManager.StartChange (1);
			spawnNum++;
			StartCoroutine (Wave1 (1, 2, level + 1, enemyList2));
			timeMax = 300;
			break;
		case 2:
			spawnNum++;
			StartCoroutine (Wave1 (0, 3, level + 1, enemyList2));
			timeMax = 300;
			break;
		case 3:
			spawnNum++;
			StartCoroutine (Wave1 (0, 4, level + 1, enemyList2));
			StartCoroutine (Wave1 (1, 4, level + 1, enemyList2));
			timeMax = 400;
			break;
		case 4:
			spawnNum++;
			StartCoroutine (Wave1 (0, 5, level + 1, enemyList2));
			StartCoroutine (Wave1 (1, 2, level + 1, enemyList2));
			timeMax = 500;
			break;
		case 5:
			spawnNum++;
			StartCoroutine (Wave3_2 (0, 0, level + 1, enemyList2));
			StartCoroutine (Wave3_2 (1, 0, level + 1, enemyList2));
			timeMax = 600;
			break;
		case 6:
			spawnNum++;
			StartCoroutine (Wave5 (0, 1, level + 1, enemyList2));
			StartCoroutine (Wave3 (1, 1, level + 1, enemyList2));
			timeMax = 500;
			break;
		case 7:
			spawnNum++;
			StartCoroutine (Wave1 (0, 4, level + 1, enemyList2));
			StartCoroutine (Wave1 (1, 4, level + 1, enemyList2));
			timeMax = 300;
			break;
		case 8:
			spawnNum++;
			StartCoroutine (Wave4 (0, 6, level + 1, enemyList2));
			StartCoroutine (Wave4 (1, 6, level + 1, enemyList2));
			timeMax = 600;

			break;
		case 9:
			spawnNum++;
			StartCoroutine (Wave6 (0, 4, level + 5, enemyList1));
			StartCoroutine (Wave4 (1, 4, level + 1, enemyList2));
			timeMax = 600;

			break;
		case 10:
			spawnNum++;
			StartCoroutine (Wave6 (1, 5, level + 5, enemyList1));
			StartCoroutine (Wave4 (0, 1, level + 1, enemyList2));
			timeMax = 600;

			break;
		case 11:
			if (isBossSpawn == false) {
				EventManager.Invoke (ref EventManager.OnSpawnBoss);
				BossSpawn (1, new Vector3 (1.2f, 2f, 0));
				isBossSpawn = true;
			}
			break;
		}
	}
	void Stage3(){
		switch (spawnNum) {
		case 1:
			EventManager.InvokeIntArg (ref EventManager.OnStartStage, 3);
			spawnNum++;
			BGManager.StartChange (2);
			im.StageText ("Stage "+stage+"\n\"Fire Mountain\"",new Color(0.3f,0.2f,0.1f));
			StartCoroutine (Wave3 (1, 0, level + 5, enemyList3));
			timeMax = 500;
			break;
		case 2:
			spawnNum++;
				StartCoroutine (Wave3 (0, 1, level + 5, enemyList3));
			
			break;
		case 3:
			spawnNum++;
			StartCoroutine (Wave6 (1, 0, level + 5, enemyList3));
			StartCoroutine (Wave6 (0, 2, level + 5, enemyList3));

			break;
		case 4:
			spawnNum++;
			StartCoroutine (Wave7 (1, 3, level + 5, enemyList3));
			StartCoroutine (Wave7 (0, 3, level + 5, enemyList3));

			break;
		case 5:
			spawnNum++;
			StartCoroutine (Wave1 (1, 4, level + 7, enemyList3));
			StartCoroutine (Wave1 (0, 4, level + 7, enemyList3));
			StartCoroutine (Wave3 (1, 0, level + 7, enemyList3));

			break;
		case 6:
			spawnNum++;
			StartCoroutine (Wave1 (0, 3, level + 7, enemyList3));
			StartCoroutine (Wave3 (1, 7, level + 7, enemyList3));
			break;
		case 7:
			spawnNum++;
			StartCoroutine (Wave8 (0, 5, level + 7, enemyList3));
			StartCoroutine (Wave3 (0, 7, level + 7, enemyList3));
			StartCoroutine (Wave3 (1, 7, level + 7, enemyList3));
			break;
		case 8:
			spawnNum++;
			StartCoroutine (Wave6 (1, 0, level + 7, enemyList3));
			StartCoroutine (Wave6 (0, 1, level + 7, enemyList2));
			break;
		case 9:
			spawnNum++;
			StartCoroutine (Wave7 (0, 6, level + 7, enemyList3));
			StartCoroutine (Wave7 (1, 6, level + 7, enemyList3));
			StartCoroutine (Wave3_2 (0,3, level + 7, enemyList3));
			StartCoroutine (Wave3_2 (1, 3, level + 7, enemyList3));
			break;
		case 10:
			spawnNum++;
			StartCoroutine (Wave3_2 (1, 4, level + 8, enemyList3));

			StartCoroutine (Wave6 (0, 2, level + 8, enemyList3));
			break;
		case 11:
			if (isBossSpawn == false) {
				EventManager.Invoke (ref EventManager.OnSpawnBoss);
				BossSpawn (2, new Vector3 (1.2f, 2f, 0));
				isBossSpawn = true;
			}
			break;
		}
	}
	void Stage4(){
		switch (spawnNum) {
		case 1:
			StartCoroutine (Wave3_2 (0, 7, level + 8, enemyList1));
			StartCoroutine (Wave3_2 (1, 7, level + 8, enemyList1));
			spawnNum++;
			BGManager.StartChange (3);
			timeMax = 600;
			im.StageText ("Final Stage \n\"Ruins\"",new Color(0.3f,0.2f,0.3f));
			break;
		case 2:
			StartCoroutine (Wave3_2 (0, 7, level + 8, enemyList1));
			StartCoroutine (Wave3_2 (1, 7, level + 8, enemyList1));
			StartCoroutine (Shot (8, enemyList3));
			spawnNum++;
			timeMax = 600;
			break;
		case 3:
			if (isBossSpawn == false) {
				EventManager.Invoke (ref EventManager.OnSpawnBoss);
				BossSpawn (3, new Vector3 (1.2f, 0, 0));
				isBossSpawn = true;
			}
			break;
		case 4:
			
			break;
		}
	}
	//slime * 3 
	IEnumerator Wave1(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 2+newLevel; i++) {
			
				Spawn (num, new Vector3 (-2.33f + 4.66f * dir, Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp),enemyList);
				yield return new WaitForSeconds (4f-newLevel*0.7f); 
		}
	}
	IEnumerator Wave2(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 2+newLevel; i++) {

				Spawn (num, new Vector3 (-3.33f + 6.66f * dir, Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp),enemyList);
				yield return new WaitForSeconds (4f-newLevel*0.7f); 
		}
	}
	IEnumerator Wave3(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 3+newLevel; i++) {

				Spawn (num, new Vector3 (-3.33f + 6.66f * dir, ((2+newLevel) - i) * 0.2f - 0.3f, 1 + hp),enemyList);
				yield return new WaitForSeconds (3f-newLevel*0.6f); 
		}
	}
	IEnumerator Wave3_2(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 3+newLevel; i++) {

				Spawn (num, new Vector3 (-2.1f + 4.2f * dir, (3 - i) * 0.2f - 0.3f, 1 + hp),enemyList);
				yield return new WaitForSeconds (2f-newLevel*0.4f); 
			}
	}
	IEnumerator Wave4(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 3+newLevel; i++) {

				Spawn (num, new Vector3 (-3.33f + 6.66f * dir,Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp),enemyList);
				yield return new WaitForSeconds (1.5f-newLevel*0.2f); 
		}
	}
	IEnumerator Wave5(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 3+newLevel; i++) {

				Spawn (num, new Vector3 (-3.33f + 6.66f * dir,Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp),enemyList);
				yield return new WaitForSeconds (0.5f-newLevel*0.08f); 
			}
	}
	IEnumerator Wave6(int dir,int num,int hp,List<GameObject> enemyList){
		if (num < enemyList.Count)
			for (int j = 0; j < 2; j++) {
				for (int i = 0; i < 3+newLevel; i++) {

					Spawn (num, new Vector3 (-3.33f + 6.66f * dir, Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp), enemyList);
					yield return new WaitForSeconds (0.5f-newLevel*0.08f); 
				}
				yield return new WaitForSeconds (1.5f-newLevel*0.2f);
			}
	}
	IEnumerator Wave7(int dir,int num,int hp,List<GameObject> enemyList){
		if (num < enemyList.Count)
			for (int j = 0; j < 2+newLevel; j++) {

					Spawn (num, new Vector3 (-1.8f + 3.6f * dir, 1.2f, 1 + hp), enemyList);

				yield return new WaitForSeconds (2.5f-newLevel*0.4f);
			}
	}
	IEnumerator Wave8(int dir,int num,int hp,List<GameObject> enemyList){
		if (num < enemyList.Count)
			for (int j = 0; j < 4+newLevel; j++) {

				Spawn (num, new Vector3 (Random.Range(-1.8f,1.8f), 1.2f, 1 + hp), enemyList);

				yield return new WaitForSeconds (0.5f-newLevel*0.08f);
			}
	}
	IEnumerator Shot(int num,List<GameObject> enemyList){
		for(int j=0;j<3;j++){
		for(int i=0;i<4;i++){
			EventManager.Invoke(ref EventManager.OnShotBoss);
			//anm.Attack ();
			Spawn (num, new Vector3 (Random.Range(-1.2f,1.2f),-1f + Random.Range (0, 2)*2f,0),enemyList);
			yield return new WaitForSeconds (0.15f);
		}
			yield return new WaitForSeconds (1f);
		}
	}
}

