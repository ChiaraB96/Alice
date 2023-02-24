/* Bloque semi-transparente que envuelve la particula del teletransporte.

    el bloque se destruye si el presonaje tiene la cantidad de particulas necesararias,
    en caso contrario muestra un cartel
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockeaTeletransporte : MonoBehaviour
{
    public GameObject bloque ; // Bloqueateletrasporte
    public int contadorLlaves = 0; //contador de llaves
    public int llaves = 1; // cantidad de llaves necesarias para abrir la puerta
    public GameObject player;  // jugador
    public InventarioItemDatos item; // item que funciona como llave de la partícula
    public GameObject cajaTexto; // imagen de fondo del bloque de texto
    public Text texto; // bloque de texto

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (contadorLlaves >= llaves)
            {
                Destroy(bloque );
            }
            else
            {
                mostrarMensaje();
            }
        }
    }
    void mostrarMensaje()
    {
        cajaTexto.SetActive(true);
        texto.gameObject.SetActive(true);
        texto.text = "No tienes la cantidad de particulas necesarias para desbloquear el Teletransporte.";
        StartCoroutine(esconderMensaje());
    }

    IEnumerator esconderMensaje()
    {
        yield return new WaitForSeconds(5);
        cajaTexto.SetActive(false);
        texto.text = "";
    }
}
