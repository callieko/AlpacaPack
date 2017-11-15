using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public float AssignedValue = 0;
	//public GameObject Mesh;
	public string Name = "Default Item Name";
	public List<Category> Tags = new List<Category>();
	public List<CraftMaterial> Materials = new List<CraftMaterial>();

	// Use this for initialization
	void Start () {
		
	}
}
