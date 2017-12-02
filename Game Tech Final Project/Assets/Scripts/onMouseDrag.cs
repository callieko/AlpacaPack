using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseDrag : MonoBehaviour {

	public GameObject selectedMode = null;
	float distance = 10;

	// On mouse drag (https://www.youtube.com/watch?v=pK1CbnE2VsI)
	void OnMouseDrag() {
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Quaternion mouseRot = new Quaternion (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z, distance);
		Vector3 objectPos = Camera.main.ScreenToWorldPoint (mousePos);

		transform.position = objectPos;
		transform.rotation = mouseRot;
	}

	public void GetCurrentMode (GameObject currentMode) {
		selectedMode = currentMode;
	}
}
