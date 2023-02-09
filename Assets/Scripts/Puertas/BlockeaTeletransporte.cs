using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockeaTeletransporte : MonoBehaviour
{
    public GameObject bloque ; 
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
