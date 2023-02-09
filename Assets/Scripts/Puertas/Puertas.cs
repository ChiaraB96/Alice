using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puertas : MonoBehaviour
{
    public GameObject puerta;
    public int contadorLlaves = 0;
    public int llaves = 1;
    public GameObject player;
    public InventarioItemDatos item;
    public GameObject cajaTexto;
    public Text texto;

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
