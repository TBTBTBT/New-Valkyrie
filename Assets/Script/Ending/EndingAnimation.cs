using UnityEngine;
using System.Collections;

public class EndingAnimation : MonoBehaviour {
	public GameObject pl;
	public GameObject pl2;
	public GameObject exc;
	public WhiteFade wf;
	AudioSource audioSource; 
	public AudioClip end;
	int actTime = 0;
	bool isFadeIn = false;
	bool isFadeOut = false;
	bool isPlay = false;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = end;
		audioSource.volume = 0.5f;
		audioSource.loop = false;
		exc.transform.position = new Vector2 (-3, 0);
	}

	// Update is called once per frame
	void Update () {
		if (wf.color > 0 && isFadeIn==false)
			wf.FadeIn (0.5f);
		else {
			isFadeIn = true;
			actTime++;
			if (actTime > 10) {
				if (audioSource.isPlaying == false && isPlay == false) {
					audioSource.Play ();
					isPlay = true;
				}
			}
			if (actTime > 250) {
				if (pl2.transform.localScale.x > 0)
					pl2.transform.localScale = new Vector2 (-2, 2);
			}
			if (actTime > 330) {
				exc.transform.position = new Vector2 (0.65f, 0.05f);
			}
			if (actTime > 410) {
				if (exc.transform.position.x > 0)
					exc.transform.position = new Vector2 (-3, 0);
			}
			if (actTime > 480) {
				if (pl.transform.localScale.x > 0)
					pl.transform.localScale = new Vector2 (-2, 2);
			}
			if (actTime > 530) {
			
				pl.transform.position = new Vector2 (pl.transform.position.x - 0.01f, pl.transform.position.y);
				if (pl.GetComponent<OpAnimator> ().animationNum == 0)
					pl.GetComponent<OpAnimator> ().Action ();
			}
			if (actTime > 545) {
				pl2.transform.position = new Vector2 (pl2.transform.position.x - 0.01f, pl2.transform.position.y);
				if (pl2.GetComponent<OpAnimator> ().animationNum == 0)
					pl2.GetComponent<OpAnimator> ().Action ();
			}
			if (actTime > 580) {
				if (isFadeOut == false) {
					isFadeOut = true;
					wf.FadeOutCoroutine(()=>{Application.LoadLevel ("EndingRoll");});
				}
			}
		}
	}
}
