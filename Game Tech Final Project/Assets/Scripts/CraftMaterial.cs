using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CraftMaterial : MonoBehaviour {

	public string Name;
	public Mesh ObjectMesh;
	public float Value = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public Sprite GetThumbnail() {
		#if UNITY_EDITOR
		Texture2D texture = UnityEditor.AssetPreview.GetAssetPreview (ObjectMesh);
		return Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), new Vector2(0.5f,0.5f));
		#else

		return null;
		#endif
	}
}
