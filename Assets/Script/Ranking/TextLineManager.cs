using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextLineManager : MonoBehaviour {

	public void Start()
	{
		GetComponent<InputField>().onValueChange.AddListener (delegate {ValueChangeCheck ();});
	}

	// Invoked when the value of the text field changes.
	public void ValueChangeCheck()
	{
		string[] b = GetComponent<InputField>().text.Split("\n"[0]);
		GetComponent<InputField> ().text = b [0];
		//Debug.Log (b[0]);
	}
}
