using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class FloorCreater : MonoBehaviour {
	public Texture2D Normaltexture;
	//public Texture2D Sidetexture;
	public Texture2D edgeTexture;
	public Texture2D midTexture;
	public int widthNum;
	public int heightNum;
	public int unitPerPixel = 100;
	public Vector2 pos;
	Vector2 fixpos = new Vector2(0,0);
	Texture2D createTexture;
	Sprite sprite;
	// Use this for initialization
	public void SetPos () {
	//	transform.position = pos + fixpos;
	}
	public void SetSprite () {
		if (Normaltexture.width == edgeTexture.width && Normaltexture.width == midTexture.width && Normaltexture.width == Normaltexture.height) {
			if (Normaltexture) {
				int width = Normaltexture.width;
				int height = Normaltexture.height;
				Color[] edgePix = edgeTexture.GetPixels (0, 0, width, height);
				Color[] midPix = midTexture.GetPixels (0, 0, width, height);
				Color[] normalPix = Normaltexture.GetPixels (0, 0, width, height);
				createTexture = new Texture2D (width * widthNum, height * heightNum);
				for (int h = 0; h < heightNum; h++) {
					for (int w = 0; w < widthNum; w++) {
						for (int y = 0; y < Normaltexture.height; y++) {
							for (int x = 0; x < Normaltexture.width; x++) {
								Color color  = midPix [y * width + x];
								if(h == heightNum - 1) { 
									color  = normalPix [y * width + x];
									if(w == 0)color = edgePix [y * width + width - x - 1];
									if(w == widthNum - 1)color = edgePix [y * width + x];
								}else if(h == 0){
									color  = normalPix [normalPix.Length - 1 - (y * width + x)];
									if(w == 0) color  = edgePix [edgePix.Length - 1 - (y * width + x)];
									if(w == widthNum - 1) color = edgePix [edgePix.Length - 1 - (y * width + width - x - 1)];
								}else {
									if(w == 0) color  = normalPix [normalPix.Length - 1 - (x * height + y)];
									if(w == widthNum - 1) color = normalPix [x * width + y];
								}

								//else if(w == 0)color = normalPix [y * Normaltexture.width + x];
								createTexture.SetPixel (x + Normaltexture.width * w, y + Normaltexture.height * h, color);
							}
						}
					}
				}
				createTexture.Apply ();
				createTexture.filterMode = FilterMode.Point;
				//sprite = Sprite.Create(createTexture, new Rect(0,0,width * widthNum,height * heightNum), new Vector2(0.5f,0.5f));

				sprite = Sprite.Create (createTexture, new Rect (0, 0, width * widthNum, height * heightNum), Vector2.zero);
				GetComponent<SpriteRenderer> ().sprite = sprite;
			}
		}
		BoxCollider2D collider = GetComponent<BoxCollider2D> ();
		collider.size = new Vector2 (((float)createTexture.width/(float)unitPerPixel),(float)createTexture.height/(float)unitPerPixel);
		collider.offset = new Vector2 ((float)createTexture.width/(float)unitPerPixel,(float)createTexture.height/(float)unitPerPixel) * 0.5f;
		//fixpos = new Vector2 ((float)createTexture.width/(float)unitPerPixel,(float)createTexture.height/(float)unitPerPixel);
		//transform.position = pos + fixpos;
	}

}
