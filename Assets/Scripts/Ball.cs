using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleTOBallVactor;
	private bool gameStarted = false;
	public static float BALL_VELOCITY = 10f;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleTOBallVactor = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			this.transform.position = paddle.transform.position + paddleTOBallVactor;
			if (Input.GetMouseButtonDown (0)) {
				this.changeBallBounceAngle(new Vector2 (0f, BALL_VELOCITY));
				gameStarted = true;
			}
		}
	}
	/*
	 * THIS METHOD CHANGES THE VELOCITY OF THE BALL, AS WELL AS THE ANGLE OF REACTION.  
	 */
	public void changeBallBounceAngle(Vector2 vector){
		this.rigidbody2D.velocity = vector;
	}

	public void OnCollisionEnter2D(Collision2D collision){
		if (gameStarted) {
			audio.Play ();
		}
	}

	public static void resetBallVelocity(){
		BALL_VELOCITY = 10f;
	}
}
