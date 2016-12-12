using UnityEngine;
using System.Collections;

public class DestroyEffectManager : MonoBehaviour {
	public int num = 5;
	public GameObject effect;
	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn ());
	}
	IEnumerator Spawn(){
		for (int i = 0; i < num*2; i++) {
			Instantiate (effect,transform.position,Quaternion.identity);
			yield return new WaitForSeconds (0.1f);
		}
		Destroy (this.gameObject);
	}
}
