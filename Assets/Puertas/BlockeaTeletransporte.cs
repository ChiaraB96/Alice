using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockeaTeletransporte : MonoBehaviour
{
    public GameObject bloque ; // Asigna la puerta en el Inspector de Unity
    public int keyCounter = 0; // Almacena la cantidad de particulas que el jugador tiene
    public int requiredKeys = 1; // Almacena la cantidad de particulas necesarias para abrir la puerta
    public GameObject player; // Asigna la referencia al jugador en el inspector
    public InventoryItemData itemData; // Asigna el item en el inspector

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
                Debug.Log("No tienes la cantidad de particulas necesarias para desbloquear el Teletransporte");
            }
        }
    }
}
