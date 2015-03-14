﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount;
	public float volume;

	private int timesHit;
	private LevelManager levelManager;
	private Ball ball;
	private Vector2 ballVelocityVector;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
		ballVelocityVector = new Vector2 (0f, Ball.BALL_VELOCITY);
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D(Collision2D collision){	
		bool isBreakable = (this.tag == "Breakable");
		float collisionPosX = ball.transform.position.x - this.transform.position.x;
		float collisionPosY = ball.transform.position.y - this.transform.position.y;
		ballVelocityVector.x = collisionPosX * 10;
		//if ball hits the buttom part of the brick and the velocity is positive
		if (collisionPosY < 0) {
			ballVelocityVector.y = Ball.BALL_VELOCITY * - 1;
		} else{
			ballVelocityVector.y = Ball.BALL_VELOCITY;
		}
		ball.changeBallBounceAngle (ballVelocityVector);
		//adds a sound indepently if the game object is there or not
		AudioSource.PlayClipAtPoint (crack, transform.position,volume);
		if (isBreakable) {
			handleHits ();
		}
	}

	void loadSprites(){
		int indexSprites = timesHit - 1;
		Sprite spriteToLoad = hitSprites [indexSprites];
		if (spriteToLoad != null) {
			this.GetComponent<SpriteRenderer> ().sprite = spriteToLoad;
		} else {
			Debug.Log("Error while trying to load sprite");
			throw new UnityException();
		}
	}

	void handleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			Destroy (gameObject);
			levelManager.brickDestroyedMessage();
		} else {
			loadSprites();
		}
	}
}
