using UnityEngine;
using System.Collections;

public class BackTitle : MonoBehaviour {


	public void Back () {
		Application.LoadLevel ("Title");
		Statics.combo = 0;
		Statics.score = 0;
		Statics.objectId = "";
	}
}
