using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer musicPlayer;

	void Awake(){
		Debug.Log ("Awake: " + GetInstanceID ());
		if (musicPlayer != null) {
			Destroy (gameObject);
		} else {
			musicPlayer = this;
		}
		GameObject.DontDestroyOnLoad (gameObject);
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("Start: " + GetInstanceID ());
		//gameObject.GetComponent ("Audio Source");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}