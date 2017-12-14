﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {

	private Vector3 center;
	private bool movingCamera;
	private Vector3 lastMousePosition;
	private float rotationSpeed = 10.0f;
	private float pitch = 0.0f;
	private float yaw = 0.0f;

	void Start () {
		center = new Vector3(0,0,0);
		transform.LookAt(center);
	}

	void updateCamera() {
		// If right mouse button is pressed start movement
		if (Input.GetMouseButtonDown (1)) {
			movingCamera = true;
			lastMousePosition = Input.mousePosition;
		}

		if (movingCamera) {
			// The movement based on the x-position
			if (lastMousePosition.x > (Screen.width / 2 - 80) && lastMousePosition.x < (Screen.width / 2 + 80))
				yaw = 0.0f;
			else if (lastMousePosition.x > (Screen.width / 2 + 80))
				yaw = -1.0f;
			else
				yaw = 1.0f;

			// The movement based on the y-position
			if (lastMousePosition.y > (Screen.height / 2 - 80) && lastMousePosition.y < (Screen.height / 2 + 80))
				pitch = 0.0f;
			else if (lastMousePosition.y > (Screen.height / 2 + 80))
				pitch = 1.0f;
			else
				pitch = -1.0f;

			// Rotate camera around the center by 10 degrees in the direction of the new Vector3.
			transform.RotateAround (center, new Vector3 (pitch, yaw, 0.0f), 10 * Time.deltaTime * rotationSpeed);
		}

		// If right mouse button is unpressed end movement
		if (!Input.GetMouseButton (1)) {
			movingCamera = false;
		}
	}

	void Update () {
		updateCamera();
	}











//		print ("updating......................");
//		if (Input.GetMouseButtonDown (1)) 
//		{
//			//right click was pressed
//			//			if (mouseOrigin.x == 0 && mouseOrigin.y == 0 && mouseOrigin.z == 0) {
//			//				mouseOrigin = Input.mousePosition;
//			//			}
//			isPanning = true;
//			lastPosition = Input.mousePosition;
////			print ("THIS IS POSITIONAL DATA HERE: " + lastPosition.x + " " + lastPosition.y);
//			print ("YAW IS " + yaw);
//			print ("screen half size " + );
//		}
//
//
//
//		if (isPanning) 
//		{
//			if (point.x < (Screen.width / 2 + 10))
//				yaw = 1.0f;
//			else if (point.x > (Screen.width / 2 - 10))
//				yaw = -1.0f;
//			else
//				yaw = 0.0f;
////			float pitch = 1.0f;
////			if (yPos  lastPosition.y)
////				pitch = -1.0f;
//
//
//
//			transform.RotateAround (point, new Vector3 (0.0f, yaw, 0.0f), 10 * Time.deltaTime * rotationSpeed);
//
////			xPos -= Input.GetAxis("Mouse X") * rotationSpeed;
////			yPos += Input.GetAxis("Mouse Y") * rotationSpeed;
////
////			float yaw = -1.0f;
////			if (xPos < lastPosition.x)
////				yaw = 1.0f;
////			float pitch = 1.0f;
////			if (yPos > lastPosition.y)
////				pitch = -1.0f;
////			
////			transform.RotateAround (point, new Vector3 (pitch, yaw, 0.0f), 10 * Time.deltaTime * rotationSpeed);
//
//			//new Vector3(0.0f,1.0f,0.0f)
//		}
//
//		// cancel on button release
//		if (!Input.GetMouseButton (1)) 
//		{
//			isPanning = false;
//		}
//	}









//	// VARIABLES
//	public float panSpeed = 4.0f;
//
//	private Vector3 mouseOrigin;
//	private bool isPanning;
//
//
//	private float rotationSpeed = 10f;
//	private float xPos = 0.0f;
//	private float yPos = 0.0f;
//	private float zPos = 0.0f;
//
//	void Start() {
//		mouseOrigin = new Vector3 (0, 0, 0);
//	}
//
//	void Update() {
//		print ("UPDATE for CAMERA");
//
////		var fwd = transform.TransformDirection(Vector3.forward);
////		float aimFarthestPoint = 100000f;
////
////		if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), aimFarthestPoint))
//////		if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.forward), aimFarthestPoint, RaycastHit)) 
////		{
////			print ("you hit an object!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
////			//			if ((hit.collider.gameObject.tag =="Player")  (hit.distance >= aimNearestPoint))
////		}
////		else
////		{
////			transform.LookAt(new Vector3 (0, 0, 0));
////			transform.Translate(Vector3.right * Time.deltaTime);
////		}      
//
//
//
//
//
////		if(Physics.Raycast(shootingRay, out hit, attackDistance))
////		{
////			// executes if hits a collider
////		}
////		else
////		{
////			transform.LookAt(new Vector3 (0, 0, 0));
////			transform.Translate(Vector3.right * Time.deltaTime);
////			// executes if it doesnt hit any collider
////		}
//
//
//
//
//
//
//		if (Input.GetMouseButtonDown (1)) 
//		{
//			//right click was pressed
//			if (mouseOrigin.x == 0 && mouseOrigin.y == 0 && mouseOrigin.z == 0) {
//				mouseOrigin = Input.mousePosition;
//			}
//			isPanning = true;
//		}
//
//		// cancel on button release
//		if (!Input.GetMouseButton (1)) 
//		{
//			isPanning = false;
//		}
//
//		if (isPanning) 
//		{
////			transform.LookAt(new Vector3 (0, 0, 0));
////			transform.Translate(Vector3.right * Time.deltaTime);
//
//			transform.LookAt(new Vector3 (0, 0, 0));
//			xPos -= Input.GetAxis("Mouse X") * rotationSpeed;
//			yPos += Input.GetAxis("Mouse Y") * rotationSpeed;
////			Vector3 newMousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f);
//			Vector3 newMousePos = new Vector3 (xPos, yPos, Input.mousePosition.z);
//			transform.Translate(newMousePos * Time.deltaTime);
//
////			Vector3 pos     = Camera.main.ScreenToViewportPoint (Input.mousePosition - mouseOrigin);
////
////			// update x and y but not z
////			Vector3 move     = new Vector3 (pos.x * panSpeed, pos.y * panSpeed, 0);
////
////			Camera.main.transform.Translate (move, Space.Self);
//		}
//
//
//
//
//
//
//
//	} //Update end






}
