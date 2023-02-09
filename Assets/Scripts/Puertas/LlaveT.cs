using UnityEngine;

public class LlaveT : MonoBehaviour
{
    public BlockeaTeletransporte blockeateletransporteScript; // Asigna el script del bloque en el Inspector de Unity

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que colisiona es el jugador
        {
            blockeateletransporteScript.contadorLlaves++; // aumenta en 1 el contador de llaves
        }
    }
}
