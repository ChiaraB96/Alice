/* Sobre el nivel del suelo en plataformas con nombre "respawn" o similar.

    al colisionar contra la plataforma que tiene el script
    la posicion del jugador se modifica a la posicion del checkpoint asignado
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public Transform checkpoint; // lugar de respown
    GameObject player; //jugador

	void Start ()
    {
        player = GameObject.FindWithTag("Player");
	}
	
	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Player")
        {
            player.transform.position = checkpoint.position;
            player.transform.rotation = checkpoint.rotation;

        }
	}
}
