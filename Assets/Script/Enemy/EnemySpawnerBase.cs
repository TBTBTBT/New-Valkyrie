using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawnerBase : MonoBehaviour {
	public List<GameObject> enemyList1;
	public List<GameObject> enemyList2;
	public List<GameObject> enemyList3;
	public List<GameObject> bossList;
	public InfoManager im;
	int time =0;
	int timeMax = 600;
	int enemynum = 0;
	int level = 0;
	int spawnNum = 0;
	int stage = 1;
	int stageMax = 3;
	GameObject bossIns;
	public BackGroundManager BGManager;
	bool isBossSpawn= false;
	// Use this for initialization
	void Start () {
		time =590;
		isBossSpawn= false;
		spawnNum = 1;
		stage = 1;
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
	// Update is called once per frame
	void Update () {
		time++;
		if (isBossSpawn == true) {
			if (bossIns == null) {
			//	if (timeMax > 100)
			//		timeMax -= 40;
				spawnNum = 1;
				isBossSpawn = false;
				timeMax =0;
				if (stage < stageMax)
					stage++;
				else {
					stage = 1;
				}

				level += 10;
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
		}
		//Debug.Log (spawnNum);
	}
	void Stage1(){
		switch (spawnNum) {
		case 1:
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
			timeMax = 600;
			break;
		case 4:
			spawnNum++;
			StartCoroutine (Wave1 (0, 5, level + 1, enemyList2));
			StartCoroutine (Wave1 (1, 2, level + 1, enemyList2));
			break;
		case 5:
			spawnNum++;
			StartCoroutine (Wave3 (0, 0, level + 1, enemyList2));
			StartCoroutine (Wave3 (1, 0, level + 1, enemyList2));
			break;
		case 6:
			spawnNum++;
			StartCoroutine (Wave5 (0, 1, level + 1, enemyList2));
			StartCoroutine (Wave3 (1, 1, level + 1, enemyList2));
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
				BossSpawn (1, new Vector3 (1.2f, 2f, 0));
				isBossSpawn = true;
			}
			break;
		}
	}
	void Stage3(){
		switch (spawnNum) {
		case 1:
			spawnNum++;
			BGManager.StartChange (2);
			im.StageText ("Stage "+stage+"\n\"Fire Mountain\"",new Color(0.3f,0.2f,0.1f));
			break;
		case 2:
			if (isBossSpawn == false) {
				BossSpawn (2, new Vector3 (1.2f, 2f, 0));
				isBossSpawn = true;
			}
			break;
		}
	}
	//slime * 3 
	IEnumerator Wave1(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 2; i++) {
			
				Spawn (num, new Vector3 (-2.33f + 4.66f * dir, Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp),enemyList);
			yield return new WaitForSeconds (4f); 
		}
	}
	IEnumerator Wave2(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 2; i++) {

				Spawn (num, new Vector3 (-3.33f + 6.66f * dir, Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp),enemyList);
			yield return new WaitForSeconds (4f); 
		}
	}
	IEnumerator Wave3(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 3; i++) {

				Spawn (num, new Vector3 (-3.33f + 6.66f * dir, (2 - i) * 0.2f - 0.3f, 1 + hp),enemyList);
			yield return new WaitForSeconds (3f); 
		}
	}
	IEnumerator Wave4(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 3; i++) {

				Spawn (num, new Vector3 (-3.33f + 6.66f * dir,Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp),enemyList);
			yield return new WaitForSeconds (1.5f); 
		}
	}
	IEnumerator Wave5(int dir,int num,int hp,List<GameObject> enemyList){
		if(num < enemyList.Count)for (int i = 0; i < 3; i++) {

				Spawn (num, new Vector3 (-3.33f + 6.66f * dir,Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp),enemyList);
				yield return new WaitForSeconds (0.5f); 
			}
	}
	IEnumerator Wave6(int dir,int num,int hp,List<GameObject> enemyList){
		if (num < enemyList.Count)
			for (int j = 0; j < 2; j++) {
				for (int i = 0; i < 3; i++) {

					Spawn (num, new Vector3 (-3.33f + 6.66f * dir, Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp), enemyList);
					yield return new WaitForSeconds (0.5f); 
				}
				yield return new WaitForSeconds (1.5f);
			}
	}
}
