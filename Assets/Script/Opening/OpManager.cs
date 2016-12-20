using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class OpManager : MonoBehaviour {
	public AudioClip op;
	AudioSource audioSource; 
	int actTime = 0;
	public  GameObject p;
	public  GameObject p2;
	public  GameObject e;
	public  GameObject f;
	public  GameObject f2;
	OpAnimator pa;
	EnemyNormalAnimation p2a;
	Vector2 player;
	Vector2 player2;
	Vector2 enemy;
	bool isPlay = false;
	bool p2j = false;
	float p2ja = 0;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = op;
		audioSource.volume = 0.5f;
		pa = p.GetComponent<OpAnimator> ();
		p2a = p2.GetComponent<EnemyNormalAnimation> ();
		player = new Vector2 (-2.2f, -0.32f);
		player2 = new Vector2 (-1.8f, -0.31f);
		enemy = new Vector2 (3, 0.8f);
		p.transform.position = player;
		p2.transform.position = player2;
		f.transform.position = new Vector2 (-4,0);
		f2.transform.position = new Vector2 (-4,0);
		e.transform.position = enemy;
	}
	public void Skip (){
		SceneManager.LoadScene ("Stage01");

	}
	// Update is called once per frame
	void FixedUpdate () {
		if (isPlay == false) {
			audioSource.Play ();
			isPlay = true;
		}
		//Debug.Log (audioSource.timeSamples);
		actTime++;
		f.transform.position = new Vector2 (-4, 0);
		f2.transform.position = new Vector2 (-4, 0);
		if (actTime < 280) {
			if (player.x < -0.4)
				player += new Vector2 (0.008f, 0);
			if (player2.x < 0)
				player2 += new Vector2 (0.008f, 0);
			if (actTime > 100 && actTime < 230)
				f.transform.position = new Vector2 (player.x, player.y + 0.4f);
			if (actTime > 200) {
				if (enemy.x > 1.3f)
					enemy.x -= 0.02f;
			}
		} else if (actTime < 400) {
			if (player2.y > -0.325f) {
				f2.transform.position = new Vector2 (player2.x, player2.y + 0.4f);
				if (p2j == false) {
					p2j = true;
					p2ja = 0.015f;
				}
				player2 += new Vector2 (0, p2ja);
				p2ja -= 0.001f;
			} else {
				player2.y = -0.325f;
				p2j = false;
			}
		} else if (actTime < 600) {
			if (enemy.x > -0.25f)
				enemy.x -= 0.03f;
			if (enemy.y > -0.2f)
				enemy.y -= 0.01f;
			else
				p2a.timeMax = 6;
			if (actTime > 450) {
				if (player2.x < -0.25f && player.x > -0.75f) {
					player -= new Vector2 (0.02f, 0);
					f2.transform.position = new Vector2 (player.x, player.y + 0.4f);
				}
				if (player2.x > -0.5f)
					player2 -= new Vector2 (0.015f, 0);
				else {
					if (p2j == false) {
						p2j = true;
						p2ja = 0.015f;
					}
					if (player2.y > -0.31f) {
					
						player2 += new Vector2 (0, p2ja);
						p2ja -= 0.001f;
					}
				}
			}
		} else if (actTime < 730) {
			if (enemy.x < 3f)
				enemy.x += 0.02f;
			if (enemy.y < 2f)
				enemy.y += 0.02f;
			if (player2.x < 3f)
				player2.x += 0.02f;
			if (player2.y < 2f)
				player2.y += 0.02f;
			if (actTime > 610 && actTime < 730)
				f2.transform.position = new Vector2 (player.x, player.y + 0.4f);

		} else if (actTime < 830) {
			p.transform.localScale = new Vector2 (-2,2);
			pa.timeMax = 6;
			if (player.x > -2f)
				player.x -= 0.03f;
		}else if (actTime < 980) {
			p.transform.localScale = new Vector2 (2,2);
			if(pa.animationNum!=1)pa.Action ();
			if (player.x < 0f)
				player.x += 0.03f;
		}
		else if (actTime < 1050) {
			
			if (player.x < 3f)
				player.x += 0.03f;
		}
		else {
			SceneManager.LoadScene ("Stage01");

		}
		p.transform.position = player;
		p2.transform.position = player2;
		e.transform.position = enemy;
	}
}
