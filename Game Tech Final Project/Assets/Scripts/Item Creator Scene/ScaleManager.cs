using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager : MonoBehaviour {

	// Variables for scale
	private float starting = 0f;
	private float shrinkScale = 0.5f;
	private float enlargeScale = 2f;

	void Start () {
		starting = Input.mousePosition.x;
	}

	void OnMouseDrag() {
		print ("ScaleManager");

		if (starting > Input.mousePosition.x) {
			Vector3 v3Scale = new Vector3 (shrinkScale, shrinkScale, shrinkScale);
			transform.localScale = Vector3.Lerp (transform.localScale, v3Scale, Time.deltaTime);
		} else if (starting < Input.mousePosition.x) {
			Vector3 v3Scale = new Vector3 (enlargeScale, enlargeScale, enlargeScale);
			transform.localScale = Vector3.Lerp (transform.localScale, v3Scale, Time.deltaTime);
		}
		starting = Input.mousePosition.x;
	}

}
