using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftMaterial : MonoBehaviour {

	public float Value = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Sprite GetThumbnail() {
		Texture2D texture = UnityEditor.AssetPreview.GetAssetPreview (gameObject);
		return Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), new Vector2(0.5f,0.5f));
	}
}
