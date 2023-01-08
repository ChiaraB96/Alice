using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    // Distancia mínima a la que debe estar el jugador para que se abra la puerta
    public float minDistance = 2f;
    // Estado de la puerta (abierta o cerrada)
    public bool isOpen = false;
    // Prefab de la llave
    public GameObject keyPrefab;
    // Referencia al inventario del jugador
    public List<GameObject> Inventory;
    // Referencia al componente Transform del jugador
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        // Calculamos la distancia entre la puerta y el jugador
        float distance = Vector3.Distance(transform.position, player.position);

        // Si el jugador está a menos de la distancia mínima establecida y tiene la llave en su inventario, abrimos la puerta
        if (distance < minDistance && Inventory.Contains(keyPrefab) && !isOpen)
        {
            // Establecemos el estado de la puerta a "abierta"
            isOpen = true;
            Destroy(gameObject);
        }
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject door; // Asigna la puerta en el Inspector de Unity
    public GameObject key; // Asigna la llave en el Inspector de Unity

    private bool hasKey; // Almacena si el jugador tiene la llave o no

    void OnTriggerEnter(Collider other)
    {
        CheckKey(); // Verifica si el jugador tiene la llave
    }

    void CheckKey()
    {
        if (hasKey)
        {
            OpenDoor(); // Abre la puerta
        }
        else
        {
            Debug.Log("No tienes la llave necesaria para abrir esta puerta"); // Muestra un mensaje al jugador
        }
    }

    void OpenDoor()
    {
                door.GetComponent<BoxCollider>().enabled = false; // Desactiva el collider de la puerta
        door.transform.Rotate(0, 90, 0); // Rota la puerta 90 grados en el eje Y
    }
}
*/