using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	int gameOverTime = 0;
	// Use this for initialization
	void Start () {
		gameOverTime = 0;
		EventManager.OnPlayerMissed.AddListener(Over);
	}
	//SceneManager.LoadScene(SceneManager.GetActiveScene ().name);
	// Update is called once per frame
	void Update () {
		if (gameOverTime > 0) {
			gameOverTime++;
			if(gameOverTime > 150)SceneManager.LoadScene("RankingEntry");
		}
	}
	void Over(){
		gameOverTime = 1;
	}
}
