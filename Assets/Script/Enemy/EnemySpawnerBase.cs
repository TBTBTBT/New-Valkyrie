using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawnerBase : MonoBehaviour {
	public List<GameObject> enemyList;
	public List<GameObject> bossList;
	int time =0;
	int timeMax = 600;
	int enemynum = 0;
	int level = 0;
	int spawnNum = 0;
	GameObject bossIns;
	public BackGroundManager BGManager;
	bool isBossSpawn= false;
	// Use this for initialization
	void Start () {
		time =590;
		isBossSpawn= false;
		spawnNum = 1;
		//enemynum = 3;
	}
	void Spawn(int i,Vector3 pos){
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
				//spawnNum = 0;
				spawnNum++;
				isBossSpawn = false;
				timeMax =0;
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

			switch (spawnNum) {
			case 1:
				spawnNum++;
				StartCoroutine (Wave1 (1, 3, level + 1));
				timeMax = 300;
				break;
			case 2:
				spawnNum++;
				StartCoroutine (Wave1 (0, 1, level + 1));
				timeMax = 300;
				break;
			case 3:
				spawnNum++;
				StartCoroutine (Wave1 (1, 3, level + 1));
				StartCoroutine (Wave1 (0, 2, level + 1));
				timeMax = 600;
				break;
			case 4:
				spawnNum++;
				StartCoroutine (Wave2 (1, 4, level + 2));
				StartCoroutine (Wave1 (0, Random.Range (0, 3), level + 2));
				//StartCoroutine(Wave(0,0));
				break;
			case 5:
				spawnNum++;
				StartCoroutine (Wave3 (0, 4, level + 3));
				StartCoroutine (Wave1 (0, 3, level + 3));
				//StartCoroutine(Wave(0,0));
				break;
			case 6:
				spawnNum++;
				StartCoroutine (Wave3 (1, 5, level + 3));
				StartCoroutine (Wave3 (0, 5, level + 3));
				break;
			case 7:
				spawnNum++;
				StartCoroutine (Wave3 (1, 6, level + 3));
				StartCoroutine (Wave3 (0, 7, level + 3));
				StartCoroutine (Wave1 (1, Random.Range (0, 4), level + 3));
				break;
			case 8:
				spawnNum++;
				//StartCoroutine(Wave4(1,6,level));
				StartCoroutine (Wave5 (1, 9, level + 3));
				break;
			case 9:
				spawnNum++;
				//StartCoroutine(Wave4(1,6,level));
				StartCoroutine (Wave1 (0, Random.Range (2, 4), level + 4));
				StartCoroutine (Wave5 (1, 9, level + 4));
				StartCoroutine (Wave5 (0, 9, level + 4));
				break;
			case 10:
				spawnNum++;
				//StartCoroutine(Wave4(1,6,level));
				StartCoroutine (Wave3 (0, Random.Range (4, 7), level + 4));
				StartCoroutine (Wave4 (1, 8, level + 4));
				break;
			case 11:
				if (isBossSpawn == false) {
					BossSpawn (0, new Vector3 (1.2f, 2f, 0));
					isBossSpawn = true;
				}
				break;
			case 12:
				BGManager.StartChange ();
				spawnNum++;
				spawnNum = 1;
				timeMax = 10;
				break;
			}
		}
		//Debug.Log (spawnNum);
	}
	//slime * 3 
	IEnumerator Wave1(int dir,int num,int hp){
		if(num < enemyList.Count)for (int i = 0; i < 2; i++) {
			
			Spawn (num, new Vector3 (-2.33f + 4.66f * dir, Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp));
			yield return new WaitForSeconds (4f); 
		}
	}
	IEnumerator Wave2(int dir,int num,int hp){
		if(num < enemyList.Count)for (int i = 0; i < 2; i++) {

			Spawn (num, new Vector3 (-3.33f + 6.66f * dir, Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp));
			yield return new WaitForSeconds (4f); 
		}
	}
	IEnumerator Wave3(int dir,int num,int hp){
		if(num < enemyList.Count)for (int i = 0; i < 3; i++) {

			Spawn (num, new Vector3 (-3.33f + 6.66f * dir, (2 - i) * 0.2f - 0.3f, 1 + hp));
			yield return new WaitForSeconds (3f); 
		}
	}
	IEnumerator Wave4(int dir,int num,int hp){
		if(num < enemyList.Count)for (int i = 0; i < 3; i++) {

			Spawn (num, new Vector3 (-3.33f + 6.66f * dir,Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp));
			yield return new WaitForSeconds (1.5f); 
		}
	}
	IEnumerator Wave5(int dir,int num,int hp){
		if(num < enemyList.Count)for (int i = 0; i < 3; i++) {

				Spawn (num, new Vector3 (-3.33f + 6.66f * dir,Random.Range (0, 5) * 0.2f - 0.3f, 1 + hp));
				yield return new WaitForSeconds (0.5f); 
			}
	}
}
