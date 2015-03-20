using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	private Ball ball;
	private Vector3 vector;
	private Vector2 ballVelocityVector;

	public bool autoPlay = false;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
		ballVelocityVector = new Vector2 (0f, Ball.BALL_VELOCITY);
		vector = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			moveWithMouse ();
		} else {
			autoPlayMethod();
		}
	}
	void autoPlayMethod(){
		vector.x = Mathf.Clamp(ball.transform.position.x,0.5f,15.5f);
		this.transform.position = vector;
	}

	void moveWithMouse(){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		vector.x = Mathf.Clamp(mousePosInBlocks,0.5f,15.5f);
		this.transform.position = vector;
	}
	/*
	 * I CAPTURE THE COLLISION EVENT IN ORDER TO DETERMINE THE BOUNCE ANGLE
	 * BY SUBTRACTING THE X POSITION OF THE PADDLE - THE X POSITION OF THE BALL
	 * AS RESULT THIS WILL GIVE A RANGE OF VALUES OF -0.5 TO 0.5, FROM LEFT TO RIGHT
	 * 
	 * FINALLY I MULTIPLY THE RESULT BY 10 AND PASS THE RESULT TO THE METHOD CHANGE BALL BOUNCE ANGLE
	 */
	void OnCollisionEnter2D(Collision2D collision){
		float collisionPosX = ball.transform.position.x - this.transform.position.x;
		ballVelocityVector.x = collisionPosX * 10;

		if (autoPlay) {
			if(collisionPosX >=0){
				ballVelocityVector.x = Random.Range(0,10f);
			}else{
				ballVelocityVector.x = Random.Range(0,-10f);
			}
		}
		ball.changeBallBounceAngle (ballVelocityVector);	
	}
}
