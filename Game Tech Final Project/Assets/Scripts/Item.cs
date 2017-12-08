using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Item : ScriptableObject {

	//public GameObject Mesh;
	public string Name = "Default Item Name";
	public Sprite Thumbnail;
	public Category category;
	public List<CraftMaterial> Materials = new List<CraftMaterial>();

	private double salePrice;

	// Use this for initialization
	void Start () {
		salePrice = -1;
	}

	public double GetMaterialCost() {
		double materialValue = 0;
		foreach (CraftMaterial material in Materials) {
			materialValue += material.Value;
		}
		return materialValue;
	}
		
	public Sprite GetThumbnail() {
		/*#if UNITY_EDITOR
		Texture2D texture = UnityEditor.AssetPreview.GetAssetPreview (ObjectMesh);
		if (texture == null) {
			//print ("Texture is null!");
			texture = UnityEditor.AssetPreview.GetMiniThumbnail (ObjectMesh);
		}
		return Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), new Vector2(0.5f,0.5f));
		#else

		return null;
		#endif*/
		return Thumbnail;
	}


	public double GetSalePrice() {
		if (salePrice == -1)
			return 0;
		else
			return salePrice;
	}

	public bool IsForSale() {
		return salePrice != -1;
	}

	public void Sell(double price) {
		salePrice = price;
	}
}
