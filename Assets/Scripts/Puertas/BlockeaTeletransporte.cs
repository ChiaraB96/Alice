using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockeaTeletransporte : MonoBehaviour
{
    public GameObject bloque ; // Asigna la puerta en el Inspector de Unity
    public int keyCounter = 0; // Almacena la cantidad de particulas que el jugador tiene
    public int requiredKeys = 1; // Almacena la cantidad de particulas necesarias para abrir la puerta
    public GameObject player; // Asigna la referencia al jugador en el inspector
    public InventoryItemData itemData; // Asigna el item en el inspector
    public GameObject messageObject;
    public Text text;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (keyCounter >= requiredKeys)
            {
                Destroy(bloque );
            }
            else
            {
                ShowMessage();
            }
        }
    }
    void ShowMessage()
    {
        messageObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = "No tienes la cantidad de particulas necesarias para desbloquear el Teletransporte.";
        StartCoroutine(HideMessage());
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(5);
        messageObject.SetActive(false);
        text.text = "";
    }
}
