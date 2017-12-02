using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseDrag : MonoBehaviour {

	float distance = 10;
	private float rotationSpeed = 20;
	private float yaw = 0.0f;
	private float pitch = 0.0f;
	float sizingFactor = 1.2f;

	// Move object: (https://www.youtube.com/watch?v=pK1CbnE2VsI)
	// Rotate object: (https://www.youtube.com/watch?v=S3pjBQObC90)
	//                (https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera)
	// Scaling object: (https://stackoverflow.com/questions/19034528/game-in-unity3d-scaling-objects-with-mouse-in-c-sharp)
	void OnMouseDrag() {
		// CODE FOR MOVEMENT
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objectPos = Camera.main.ScreenToWorldPoint (mousePos);
		transform.position = objectPos;

		// CODE FOR ROTATION
//		yaw += Input.GetAxis("Mouse X") * rotationSpeed;
//		pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
//		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
//		-----
//		transform.RotateAround(Vector3.up, -rotationX);
//		transform.RotateAround(Vector3.right, rotationY);

		// CODE FOR SCALING
//		Vector3 v3Scale = new Vector3(sizingFactor, sizingFactor, sizingFactor);
//		transform.localScale = Vector3.Lerp(transform.localScale, v3Scale, Time.deltaTime);
	}





}
