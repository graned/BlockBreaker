using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	void Start(){
		Brick.breakableCount = GameObject.FindGameObjectsWithTag ("Breakable").Length;
	}

	public void LoadLevel(string name){
		Application.LoadLevel (name);
		if ("Level_01".Equals (name)) {
			Screen.showCursor = false;
		} else {
			Screen.showCursor = true;
		}
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void loadNextLevel(){
		Application.LoadLevel (Application.loadedLevel + 1);
		if (Application.loadedLevel == 4) {
			Screen.showCursor = true;
		}
	}
	public void brickDestroyedMessage(){
		if(Brick.breakableCount <= 0){
			loadNextLevel();
		}
	}
}
