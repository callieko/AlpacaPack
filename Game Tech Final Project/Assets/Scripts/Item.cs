using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	//public GameObject Mesh;
	public string Name = "Default Item Name";
	public List<Category> Categories = new List<Category>();
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
		Texture2D texture = UnityEditor.AssetPreview.GetAssetPreview (gameObject);
		if (texture == null) {
			print ("Texture is null!");
			texture = UnityEditor.AssetPreview.GetMiniThumbnail (gameObject);
		}
			
		return Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), new Vector2(0.5f,0.5f));
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
