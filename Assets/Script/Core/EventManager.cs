using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class UnityEventIntArg : UnityEvent <int>{}
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
		SetEventIntArg (ref OnDestroyEnemy);
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
	// Update is called once per frame
}
