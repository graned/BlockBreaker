using UnityEngine;
using System.Collections;
using System;

public class LevelManager : MonoBehaviour {
	/*
	private event LevelLoadedEventHandler levelLoadedEventHandler;

	private delegate void LevelLoadedEventHandler(object sender, LevelLoadedEventArgs levelLoadedEventArgs);

	private class LevelLoadedEventArgs : EventArgs{
		private String levelName;

		public String LevelName{
			set{
				this.levelName= value;
			}
			get{
				return levelName;
			}
		}

	};

	private LevelLoadedEventArgs levelEventArgs;
	*/
	void Start(){
		Brick.breakableCount = GameObject.FindGameObjectsWithTag ("Breakable").Length;
		//levelEventArgs = new LevelLoadedEventArgs ();
	}
	public void LoadLevel(string name){
		/*
		levelEventArgs.LevelName = name;
		levelLoadedEventHandler (this, levelEventArgs);
		*/

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
		//UPDATE!
		Debug.Log (Application.loadedLevelName);
		if ("Instruction Screen".Equals (Application.loadedLevelName)) {
			//Debug.Log("PSSSSSSSSSSSSSSS!");
			automaticLevelLoad(2000);
		}
		/*if (Application.loadedLevel == 4) {
			Screen.showCursor = true;
		}*/
	}
	public void brickDestroyedMessage(){
		if(Brick.breakableCount <= 0){
			loadNextLevel();
		}
	}

	public void automaticLevelLoad(int seconds){
		loadNextLevel ();
		System.Threading.Thread.Sleep (seconds);
	}
}
