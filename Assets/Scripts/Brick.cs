using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		timesHit++;
		if (timesHit >= maxHits) {
			Destroy (gameObject);
		} else {
			loadSprites();
		}
	}

	void loadSprites(){
		int indexSprites = timesHit - 1;
		this.GetComponent<SpriteRenderer> ().sprite = hitSprites [indexSprites];
	}
	//TODO remove this method once we can win
	void simulateWin(){
		levelManager.loadNextLevel ();

	}
}
