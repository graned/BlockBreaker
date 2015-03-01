using UnityEngine;
using System.Collections;

public class LooseColider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log("Trigger");
	}

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log("Collision");
	}
}
