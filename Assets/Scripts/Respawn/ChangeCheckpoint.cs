/* CheckPoint dentro de algunas plataformas de color amarillo.

    cuando el jugador toca el gameObject que contiene el scipt se destruye el checkpoint asignado
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCheckpoint : MonoBehaviour
{
    public GameObject checkpoint;// plataforma del checkpoint anterior
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(checkpoint);
    }
}
