using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class UnityEventIntArg : UnityEvent <int>{}
public class UnityEventGameObjectArg : UnityEvent <GameObject>{}
public class UnityEventVecIntArg : UnityEvent <Vector2,int>{}
public class EventManager : MonoBehaviour {
	static public UnityEventIntArg OnTouchBegin;
	static public UnityEventIntArg OnTouchMove;
	static public UnityEventIntArg OnTouchEnd;
	static public UnityEvent OnJump;
	static public UnityEvent OnAtkBegin;
	static public UnityEvent OnAtkEnd;
	static public UnityEvent OnLand;
	static public UnityEvent OnPlayerMissed;
	static public UnityEvent OnUpPower;
	static public UnityEvent OnUpSpd;
	static public UnityEvent OnUpHp;
	static public UnityEvent OnEndCombo;
	static public UnityEvent OnEnemyHit;
	static public UnityEvent OnCatch;
	static public UnityEvent OnDamaged;
	static public UnityEvent OnUpAbility;
	static public UnityEvent OnUpSize;
	static public UnityEvent OnPlayerAttacked;
	static public UnityEventIntArg OnDestroyEnemy;
	static public UnityEventIntArg OnStartStage;
	static public UnityEventGameObjectArg OnChangeBoss;
	static public UnityEvent OnSpawnBoss;
	static public UnityEvent OnDestroyBoss;
	static public UnityEvent OnDestroyBoss03;
	static public UnityEvent OnDestroyBoss03Break;
	static public UnityEvent OnDestroyBoss04;
	static public UnityEvent OnDestroyBoss04Break;
	static public UnityEvent OnDestroyBoss05;
	static public UnityEvent OnDestroyBoss05Break;
	static public UnityEvent OnShotBoss;
	static public UnityEvent OnLandBoss;
	static public UnityEvent OnFire;
	static public UnityEvent OnLaser;
	// Use this for initialization
	void Awake() {
		SetEventIntArg (ref OnTouchBegin);
		SetEventIntArg  (ref OnTouchMove);
		SetEventIntArg  (ref OnTouchEnd);
		SetEvent (ref OnJump);
		SetEvent (ref OnAtkBegin);
		SetEvent (ref OnAtkEnd);
		SetEvent (ref OnLand);
		SetEvent (ref OnPlayerMissed);
		SetEvent (ref OnUpPower);
		SetEvent (ref OnUpSpd);
		SetEvent (ref OnUpHp);
		SetEvent (ref OnEndCombo);
		SetEvent (ref OnEnemyHit);
		SetEvent (ref OnCatch);
		SetEvent (ref OnDamaged);
		SetEvent (ref OnUpAbility);
		SetEvent (ref OnUpSize);
		SetEvent (ref OnPlayerAttacked);
		SetEvent (ref OnSpawnBoss);
		SetEvent (ref OnDestroyBoss);
		SetEvent (ref OnDestroyBoss03);
		SetEvent (ref OnDestroyBoss04);
		SetEvent (ref OnDestroyBoss05);
		SetEvent (ref OnDestroyBoss03Break);
		SetEvent (ref OnDestroyBoss04Break);
		SetEvent (ref OnDestroyBoss05Break);
		SetEvent (ref OnShotBoss);
		SetEvent (ref OnFire);
		SetEvent (ref OnLaser);
		SetEvent (ref OnLandBoss);
		SetEventIntArg (ref OnDestroyEnemy);
		SetEventIntArg (ref OnStartStage);
		SetEventGameObjectArg (ref OnChangeBoss);
		//SetEvent (ref OnTouchEnd);
		//SetEvent (ref OnTouchEnd);
	}
	void SetEvent(ref UnityEvent u ){
		if (u == null) {
			u = new UnityEvent ();
		}
	}
	void SetEventIntArg(ref UnityEventIntArg u ){
		if (u == null) {
			u = new UnityEventIntArg ();
		}
	}
	void SetEventVecIntArg(ref UnityEventVecIntArg u ){
		if (u == null) {
			u = new UnityEventVecIntArg ();
		}
	}
	void SetEventGameObjectArg(ref UnityEventGameObjectArg u ){
		if (u == null) {
			u = new UnityEventGameObjectArg ();
		}
	}
	static public void Invoke(ref UnityEvent u ){
		if (u != null) {
			u.Invoke();
		}
	}
	static public void InvokeIntArg(ref UnityEventIntArg u ,int a){
		if (u != null) {
			u.Invoke(a);
		}
	}
	static public void InvokeVecIntArg(ref UnityEventVecIntArg u ,Vector2 a,int b){
		if (u != null) {
			u.Invoke(a,b);
		}
	}
	static public void InvokeGameObjectArg(ref UnityEventGameObjectArg u ,GameObject a){
		if (u != null) {
			u.Invoke(a);
		}
	}
	// Update is called once per frame
}
