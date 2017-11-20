using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	public List<Item> MyItems;
	public Dictionary<GameObject, int> MyMaterials;

	// Use this for initialization
	void Start () {
		MyItems = new List<Item> ();
		MyMaterials = new Dictionary<GameObject, int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetMaterial (GameObject Material) {
		
		if (MyMaterials.ContainsKey (Material)) {
			MyMaterials [Material] = MyMaterials [Material] + 1;
		} else {
			MyMaterials.Add (Material, 1);
		}
	}

	public bool UseMaterial (GameObject Material, int Number = 1) {
		if (MyMaterials.ContainsKey (Material) && MyMaterials[Material] <= Number) {
			MyMaterials [Material] -= Number;
			if (MyMaterials [Material] == 0)
				MyMaterials.Remove (Material);
			return true;
		}
		return false;
	}
}
