﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeX;
	public float smoothTimeY;

	public GameObject player;

	public bool bounds;

	public Vector3 minCameraPos;
	public Vector3 maxcameraPos;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	
	}

	void FixedUpdate()
	{
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);

		if (bounds) {
			transform.position = new Vector3(Mathf.Clamp(transform.position.x,minCameraPos.x,maxcameraPos.x),Mathf.Clamp (transform.position.y,minCameraPos.y,maxcameraPos.y),
			                                 Mathf.Clamp (transform.position.z,minCameraPos.z,maxcameraPos.z));
		}

	}
}