using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftMaterial : MonoBehaviour {

	public string Name = "Default Material Name";
	public float Value = 0;
	public Mesh ObjectMesh;
	public Image Thumbnail;

	public GameObject MaterialListing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject GetListing() {
		GameObject listing = Instantiate (MaterialListing);
		return listing;
	}
}
