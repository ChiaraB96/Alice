/* Puertas de colores.

    la puerta se destruye si el presonaje tiene la cantidad de particulas necesararias,
    en caso contrario muestra un cartel
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puertas : MonoBehaviour
{
    public GameObject puerta ; // Puerta
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
                abrirPuerta();
            }
            else
            {
                mostrarMensaje();
            }
        }
    }

    void abrirPuerta()
    {
        for (int i = 0; i < contadorLlaves; i++)
        {
            SistemaInventario.Instancia.Remove(item, contadorLlaves);
        }
        Destroy(puerta);
    }

    void mostrarMensaje()
    {
        cajaTexto.SetActive(true);
        texto.gameObject.SetActive(true);
        texto.text = "No tienes la cantidad de particulas necesarias para abrir esta puerta.";
        StartCoroutine(esconderMensaje());
    }

    IEnumerator esconderMensaje()
    {
        yield return new WaitForSeconds(5);
        cajaTexto.SetActive(false);
        texto.text = "";
    }
}
