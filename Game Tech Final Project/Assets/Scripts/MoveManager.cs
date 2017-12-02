using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {

	public GameObject sphere;
	float distance = 10;

	// On mouse drag (https://www.youtube.com/watch?v=pK1CbnE2VsI)
	void OnMouseDrag() {
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objectPos = Camera.main.ScreenToWorldPoint (mousePos);

		sphere.transform.position = objectPos;
	}

}
