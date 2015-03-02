using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	Vector3 vector;
	// Use this for initialization
	void Start () {
		vector = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		vector.x = Mathf.Clamp(mousePosInBlocks,0.5f,15.5f);
		this.transform.position = vector;
	}
}
