using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseDrag : MonoBehaviour {

	float distance = 10;
	private float rotationSpeed = 20;
	private float yaw = 0.0f;
	private float pitch = 0.0f;
	float sizingFactor = 2f;
	KeyCode currentKey = KeyCode.M;
	float starting = 0;

	// Move object: (https://www.youtube.com/watch?v=pK1CbnE2VsI)
	// Rotate object: (https://www.youtube.com/watch?v=S3pjBQObC90)
	//                (https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera)
	// Scaling object: (https://stackoverflow.com/questions/19034528/game-in-unity3d-scaling-objects-with-mouse-in-c-sharp)
	void OnMouseDrag() {
		if (starting == 0) {
			starting = Input.mousePosition.x;
		}
		// CODE FOR MOVEMENT
		if (Input.GetKeyDown (KeyCode.M)) {
			currentKey = KeyCode.M;
		} else if (Input.GetKeyDown (KeyCode.R)) {
			currentKey = KeyCode.R;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			currentKey = KeyCode.S;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			currentKey = KeyCode.D;
		}

		print ("Current key is: " + currentKey);

		if (currentKey == KeyCode.M) {
			Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
			Vector3 objectPos = Camera.main.ScreenToWorldPoint (mousePos);
			transform.position = objectPos;
		} else if (currentKey == KeyCode.R) {
			currentKey = KeyCode.R;
			yaw += Input.GetAxis("Mouse X") * rotationSpeed;
			pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
			transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		} else if (currentKey == KeyCode.S) {
			currentKey = KeyCode.S;

			if (starting > Input.mousePosition.x) {
				Vector3 v3Scale = new Vector3 (0.5f, 0.5f, 0.5f);
				transform.localScale = Vector3.Lerp (transform.localScale, v3Scale, Time.deltaTime);
			} else {
				Vector3 v3Scale = new Vector3 (sizingFactor, sizingFactor, sizingFactor);
				transform.localScale = Vector3.Lerp (transform.localScale, v3Scale, Time.deltaTime);
			}
			starting = Input.mousePosition.x;
		}
	}





}
