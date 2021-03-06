﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;

	}
	
	void Update () {
		if (!hasStarted) {
				this.transform.position = paddle.transform.position + paddleToBallVector;
			
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			if (Input.GetMouseButtonDown(0)) {
				print("mouse clicked, launch ball");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
	
		Vector2 tweak = new Vector2(Random.Range(0f, 0.4f), Random.Range(0f,0.4f));
		if (hasStarted) {
				audio.Play();
				rigidbody2D.velocity += tweak;
		}
		
	}
}
