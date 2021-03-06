﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSoundManager : MonoBehaviour {
	AudioSource audioSource; 
	AudioSource audioSourceLoop; 
	//public AudioClip bgm;
	//public AudioClip hitsword;

	public List<AudioClip> bgm;
	public AudioClip up;
	public AudioClip catchax;
	public AudioClip enemyHit;
	public AudioClip jump;
	public AudioClip thr;
	public AudioClip damage;
	public AudioClip charge;
	public AudioClip clear;
	public AudioClip bossDestroy;
	public AudioClip bossbullet;
	public AudioClip bosslaser;
	public AudioClip fire;
	public AudioClip bossland;
	//public AudioClip ;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSourceLoop = gameObject.AddComponent<AudioSource>();
		audioSourceLoop.loop = true;
		audioSourceLoop.clip = bgm[0];

		//audioSource.spatialBlend = 0;
		audioSourceLoop.spatialBlend = 0;
		StartBGM (0);
		EventManager.OnUpAbility.AddListener (Up);
		EventManager.OnEnemyHit.AddListener (EnemyHit);
		EventManager.OnPlayerMissed.AddListener (StopBGM);
		EventManager.OnJump.AddListener (Jump);
		EventManager.OnAtkEnd.AddListener (Throw);
		//EventManager.OnAtkBegin.AddListener (ChargeStart);
		EventManager.OnDamaged.AddListener (Damage);
		EventManager.OnDestroyBoss.AddListener (BossDestroy);
		EventManager.OnCatch.AddListener (Catch);
		EventManager.OnSpawnBoss.AddListener (()=>{FadeBGM(1);});
		EventManager.OnDestroyBoss.AddListener (StopBGM);
		EventManager.OnStartStage.AddListener (StartStageBGM);
		EventManager.OnDestroyBoss03.AddListener (()=>{StopBGM();audioSource.PlayOneShot(bossDestroy);});
		EventManager.OnDestroyBoss03Break.AddListener (()=>{audioSource.PlayOneShot(clear);});
		EventManager.OnDestroyBoss04.AddListener (()=>{StopBGM();audioSource.PlayOneShot(bossDestroy);});
		EventManager.OnDestroyBoss04Break.AddListener (()=>{StartBGM (1);});
		EventManager.OnDestroyBoss05.AddListener (()=>{StopBGM();audioSource.PlayOneShot(bossDestroy);});
		EventManager.OnDestroyBoss05Break.AddListener (FinalBossDestroy);
		EventManager.OnShotBoss.AddListener (BossBullet);
		EventManager.OnLaser.AddListener (BossLaser);
		EventManager.OnFire.AddListener (Fire);
		audioSource.volume =0.5f;
		//FadeBGM (1);
	}
	void StartStageBGM (int n) {
		if (n == 1)
		if(audioSourceLoop.isPlaying == false)StartBGM (0);
		if (n == 2)
		if(audioSourceLoop.isPlaying == false)StartBGM (2);
		if (n == 3)
		if(audioSourceLoop.isPlaying == false)StartBGM (3);
		
		
	}
	// Update is called once per frame
	void StartBGM (int n) {
		audioSourceLoop.volume = 0.5f;
		audioSourceLoop.clip = bgm[n];
		audioSourceLoop.Play();
	}
	void StopBGM () {
		audioSourceLoop.Stop();
	}
	void FadeBGM (int n) {
		StartCoroutine (Fade (n));
	}
	void Damage(){
		audioSource.PlayOneShot(damage);
	}
	void BossDestroy(){
		//audioSource.PlayOneShot(bossDestroy);
		StartCoroutine (Clear ());

	}

	void FinalBossDestroy(){
		//audioSource.PlayOneShot(bossDestroy);
		audioSource.PlayOneShot(bossDestroy);

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
	void Fire() {

		audioSource.PlayOneShot(fire);

	}
	void BossBullet () {

		audioSource.PlayOneShot(bossbullet);

	}
	void BossLaser () {

		audioSource.PlayOneShot(bosslaser);

	}
	void BossLand () {

		audioSource.PlayOneShot(bossland);

	}
	void ChargeStart () {
		
		audioSource.PlayOneShot(charge);

	}
	// void ChargeStop () {



	//}
	void EnemyHit() {
		audioSource.PlayOneShot(enemyHit);
		
	}
	IEnumerator Fade(int n){
		while(audioSourceLoop.isPlaying == true){
			if (audioSourceLoop.volume > 0)
				audioSourceLoop.volume -= 0.05f;
			if (audioSourceLoop.volume <= 0)
				audioSourceLoop.Stop ();
			yield return new WaitForSeconds (0.1f);
			}
		StartBGM (n);


	}
	IEnumerator Clear(){
		audioSource.PlayOneShot(bossDestroy);
			yield return new WaitForSeconds (1.2f);

		audioSource.PlayOneShot(clear);

	}
}
