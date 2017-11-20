using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public float AssignedValue = 0;
	//public GameObject Mesh;
	public string Name = "Default Item Name";
	public List<Category> Categories = new List<Category>();
	public List<CraftMaterial> Materials = new List<CraftMaterial>();

	private float materialValue;
	private int salePrice;

	// Use this for initialization
	void Start () {
		foreach (CraftMaterial material in Materials) {
			materialValue += material.Value;
		}

		salePrice = -1;
	}

	public float GetMaterialCost() {
		return materialValue;
	}

	public Sprite GetThumbnail() {
		Texture2D texture = UnityEditor.AssetPreview.GetAssetPreview (gameObject);
		return Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), new Vector2(0.5f,0.5f));
	}

	public float GetSalePrice() {
		if (salePrice == -1)
			return 0;
		else
			return salePrice;
	}

	public bool IsForSale() {
		return salePrice != -1;
	}

	public void Sell(int price) {
		salePrice = price;
	}
}
