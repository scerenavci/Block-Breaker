using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	private Vector3 paddleToBallVector;
	
	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;

	}
	
	void Update () {
		this.transform.position = paddle.transform.position + paddleToBallVector;
	}
}
