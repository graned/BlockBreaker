using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	private int currentLevel = 1;
	public Text levelTextValue;
	private bool needWait = true;

	void Start(){
		Brick.breakableCount = GameObject.FindGameObjectsWithTag ("Breakable").Length;
	}
	public void LoadLevel(string name){
		Application.LoadLevel (name);

	}

	public void Update(){
		//Debug.Log ("Is loading Level?: " + Application.isLoadingLevel);
		levelPresets (Application.loadedLevelName);

	}
	private void levelPresets(string levelName){
		Debug.Log(levelName + " : "+Application.loadedLevel);

		if(Application.loadedLevel == 1){
			needWait = true;
			levelTextValue.text = currentLevel.ToString();
			LoadLevel("Level_"+currentLevel);
		}else if(("Level_"+currentLevel).Equals(levelName)){
			if(needWait){
				//Debug.Log("ENTERED!");
				System.Threading.Thread.Sleep(3000);
				needWait = false;
			}
		}
		Debug.Log ("Level_" + currentLevel +" = "+levelName);
	}
	//SINTAX EQUALS IN JAVA TO  <T EXTENDS GAMEOBJECT>
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
			++currentLevel;
			Debug.Log("current level(after): "+currentLevel);

			LoadLevel("Level Introduction");
			//loadNextLevel();
		}
	}

}
