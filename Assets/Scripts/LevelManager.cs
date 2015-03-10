using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	void Start(){
		Brick.breakableCount = GameObject.FindGameObjectsWithTag ("Breakable").Length;
	}

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void loadNextLevel(){
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	public void brickDestroyedMessage(){
		if(Brick.breakableCount <= 0){
			loadNextLevel();
		}
	}
}
