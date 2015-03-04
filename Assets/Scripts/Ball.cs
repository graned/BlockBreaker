using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	private Vector3 paddleTOBallVactor;
	private bool gameStarted = false;

	// Use this for initialization
	void Start () {
		paddleTOBallVactor = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			this.transform.position = paddle.transform.position + paddleTOBallVactor;
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("left mouse button clicked");
				this.rigidbody2D.velocity = new Vector2 (0f, 10f);
				gameStarted = true;
			}
		}
	}
}
