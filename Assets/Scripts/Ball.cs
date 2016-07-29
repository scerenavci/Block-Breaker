using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	void Start () {
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
}
