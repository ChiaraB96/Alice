/* En algunas plataformas de las zonas rojas.

Cuando el un gameObject con tag "Player" colisiona contra una plataforma que contiene este Script la plataforma
que se asignó en el public GameObject es destruida
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalsa : MonoBehaviour
{
    public GameObject plataforma; //plataforma que se va a destruir
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(plataforma);
        }
    }

}
