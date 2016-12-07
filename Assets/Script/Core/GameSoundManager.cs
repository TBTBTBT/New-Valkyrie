using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSoundManager : MonoBehaviour {
	AudioSource audioSource; 
	AudioSource audioSourceLoop; 
	//public AudioClip bgm;
	//public AudioClip hitsword;

	public AudioClip bgm;
	public AudioClip up;
	public AudioClip catchax;
	public AudioClip enemyHit;
	public AudioClip jump;
	public AudioClip thr;
	public AudioClip damage;
	public AudioClip charge;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSourceLoop = gameObject.AddComponent<AudioSource>();
		audioSourceLoop.loop = true;
		audioSourceLoop.clip = bgm;

		//audioSource.spatialBlend = 0;
		audioSourceLoop.spatialBlend = 0;
		StartBGM ();
		EventManager.OnUpAbility.AddListener (Up);
		EventManager.OnEnemyHit.AddListener (EnemyHit);
		EventManager.OnPlayerMissed.AddListener (StopBGM);
		EventManager.OnJump.AddListener (Jump);
		EventManager.OnAtkEnd.AddListener (Throw);
		//EventManager.OnAtkBegin.AddListener (ChargeStart);
		EventManager.OnDamaged.AddListener (Damage);
		EventManager.OnCatch.AddListener (Catch);
		audioSource.volume =0.5f;
	}
	
	// Update is called once per frame
	void StartBGM () {
		audioSourceLoop.volume = 0.5f;
		audioSourceLoop.Play();
	}
	void StopBGM () {
		audioSourceLoop.Stop();
	}
	void Damage(){
		audioSource.PlayOneShot(damage);
	}
	void Jump () {
		audioSource.PlayOneShot(jump);
	}
	void Throw(){
//		audioSource.Stop();

		audioSource.PlayOneShot (thr);
	}
	void Up () {

		audioSource.PlayOneShot(up);

	}
	void Catch () {

		audioSource.PlayOneShot(catchax);

	}
	void ChargeStart () {
		
		audioSource.PlayOneShot(charge);

	}
	// void ChargeStop () {



	//}
	void EnemyHit() {
		audioSource.PlayOneShot(enemyHit);
		
	}
}
