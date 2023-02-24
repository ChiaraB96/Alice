/* PowerUp dentro de las particulas solo del nivel tutorial.

    cuando el jugado entra al trigger se incrementa el contador que se encuentra en el script de la puerta asignada
 */
using UnityEngine;

public class LlaveT : MonoBehaviour
{
    public Puertas puertasScript;// puerta que va a abrir la particula

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puertasScript.contadorLlaves++;
        }
    }
}

