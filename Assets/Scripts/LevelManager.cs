using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	private static int currentLevel = 1;
	public Text levelTextValue;
	public Text levelTextCounter;
	private int seconds;
	private bool needWait = true;

	public void resetLevel(){
		currentLevel = 1;
	}

	private class TimerThread{
		private LevelManager levelManager;
		private string levelToLoad;

		public TimerThread(LevelManager levelManager, string levelToLoad){
			this.levelManager = levelManager;
			this.levelToLoad = levelToLoad;
		}

		public void DoWork(){
			Debug.Log ("wait starts!");
			while (levelManager.seconds > 0) {
				Debug.Log ("seconds: "+levelManager.seconds);
				System.Threading.Thread.Sleep(1000);
				levelManager.seconds--;
			}
			Debug.Log ("wait finished!");
			//callOtherLevel ();
		}
		public void callOtherLevel(){
			Debug.Log ("callOtherLevel method!");
			//Application.LoadLevel (levelToLoad);
			levelManager.LoadLevel (levelToLoad);
		}
	}

	void Start(){
		Brick.breakableCount = GameObject.FindGameObjectsWithTag ("Breakable").Length;
	}
	public void LoadLevel(string name){
		Debug.Log ("Trying to load: " + name);
		Application.LoadLevel (name);
	}

	public void Update(){
		//Debug.Log ("Is loading Level?: " + Application.isLoadingLevel);
		//levelPresets (Application.loadedLevelName);
		if (Application.loadedLevel == 1) {
			levelTextCounter.text = seconds.ToString();
			if(seconds == 0){
				LoadLevel("Level_"+currentLevel);
			}
		}
	}

	public void OnLevelWasLoaded(int level){

		Debug.Log (level + " level loaded");
		if (level == 1) {
			Debug.Log ("introcution level loaded");
			needWait = true;
			levelTextValue.text = currentLevel.ToString ();
			seconds = 5;
			TimerThread tt = new TimerThread(this,"Level_"+currentLevel);
			System.Threading.Thread timerThread = new System.Threading.Thread(tt.DoWork);
			timerThread.Start();
			//System.Threading.Thread.Sleep(3000);
			//CALL THREAD THAT WILL CALL THE LOAD LEVEL METHOD
			//LoadLevel ("Level_" + currentLevel);
		}
	}

	private void levelPresets(string levelName){
		Debug.Log ("Level_" + currentLevel + " = " + levelName);
		if(("Level_"+currentLevel).Equals(levelName)){
			if(needWait){
				System.Threading.Thread.Sleep(1000);
				needWait = false;
			}
		}
	}

	/*//SINTAX EQUALS IN JAVA TO  <T EXTENDS GAMEOBJECT>
	private T getComponentByName<T>(string componentName) where T:Component{
		Debug.Log("IN METHOD");
		Debug.Log("COMPONENT_NAME: "+componentName);
		T[] componentList = GameObject.FindObjectsOfType<T>();
		Debug.Log("NUMBER OF ELEMENTS RETRIEVED: "+componentList.Length);
		foreach (T item in componentList) {
			Debug.Log("INSIDE FOR LOOP");
			Debug.Log("ITEM VALUE: "+item.name.ToLower());
			if(componentName.ToLower().Equals(item.name.ToLower())){
				return item;
			}
		}
		//ITEM NOT FOUND
		return null;
	}
	*/
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void loadNextLevel(int levelIndex){
		//LOADS A LEVEL BASED ON AN INDEX
		Application.LoadLevel (levelIndex);
		//OLD
		//Application.LoadLevel (Application.loadedLevel + 1);
	}
	public void brickDestroyedMessage(){
		if(Brick.breakableCount <= 0){
			Debug.Log("current level(before): "+currentLevel);
			currentLevel += 1;
			Debug.Log("current level(after): "+currentLevel);

			LoadLevel("Level Introduction");
			//loadNextLevel();
		}
	}

}
