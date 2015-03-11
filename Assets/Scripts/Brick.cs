using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D(Collision2D collision){
		bool isBreakable = (this.tag == "Breakable");

		//adds a sound indepently if the game object is there or not
		AudioSource.PlayClipAtPoint (crack, transform.position);
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
