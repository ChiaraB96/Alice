using UnityEngine;

public class Llave : MonoBehaviour
{
    public Puertas puertasScript; // Asigna el script de la puerta en el Inspector de Unity

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que colisiona es el jugador
        {
            puertasScript.contadorLlaves++; // aumenta en 1 el contador de llaves

        }
    }
}
