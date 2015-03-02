using UnityEngine;
using System.Collections;

public class LooseColider : MonoBehaviour {

	/*
	 * ESTE METODO CAPTURA EL EVENTO TRIGGER CUANDO SUCEDE UNA COLISION DE LA BOLA CON EL GAME OBJECT LLAMADO LOOSE COLIDER, 
	 * Y MANDA LLAMAR LA PANTALLA DE WIN SCREEN.
	 */
	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log("Trigger");

		new LevelManager ().LoadLevel ("Win Screen");

	}

	/*
	 * ESTE METODO CAPTURA EL EVENTO COLLISION CUANDO SUCEDE UNA COLISION DE LA BOLA CON EL GAME OBJECT LLAMADO LOOSE COLIDER, 
	 * Y MANDA LLAMAR LA PANTALLA DE WIN SCREEN.
	 */
	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log("Collision");
	}
}
