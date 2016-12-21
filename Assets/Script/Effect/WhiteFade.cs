using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class WhiteFade :MonoBehaviour {

//	#region Fields
	public SpriteRenderer fade;
	[SerializeField]
	[Range(0, 100)]
	public float color;

//	#endregion

//	#region Properties
	//public override string ShaderName
	//{
	//	get { return "Hidden/Fade"; }
	//}

//	#endregion

//	#region Methods
	public void FadeOutCoroutine(UnityAction callback){
		StartCoroutine(FOC(callback));
	}
	public void FadeOutCoroutineFast(UnityAction callback){
		StartCoroutine(FOCF(callback));
	}
	public void FadeIn(float i){
		if (color > 0)
			color-=i;
		if (color <= 0)
			color = 0;
		fade.color = new Color (1,1,1,color/100);
	}
	public void FadeOut(float i){
		if (color < 100)
			color+=i;
		if (color >= 100)
			color = 100;
		fade.color = new Color (1,1,1,color/100);
	}
	//	protected override void UpdateMaterial()
//	{
		
	//	Material.SetFloat("_color",color);
	//}
	IEnumerator FOC(UnityAction callback){
		while (color < 100) {
			FadeOut (0.5f);
			yield return new WaitForEndOfFrame();
		}
		callback();
	}
	IEnumerator FOCF(UnityAction callback){
		while (color < 100) {
			FadeOut (3f);
			yield return new WaitForEndOfFrame();
		}
		callback();
	}
//	#endregion

}