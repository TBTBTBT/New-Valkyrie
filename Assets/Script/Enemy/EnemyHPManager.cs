using UnityEngine;
using System.Collections;

public class EnemyHPManager : MonoBehaviour {
	EnemyBase enemy;
	// Use this for initialization
	void Start () {
		enemy = transform.parent.parent.GetComponent<EnemyBase> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector2 (14 * (float)enemy.RetHP() / (float)enemy.RetMaxHP(),transform.localScale.y);
		if(enemy.RetHP()<0)transform.localScale = new Vector2 (0,transform.localScale.y);
	}
}
