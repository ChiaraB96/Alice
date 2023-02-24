/* PowerUp dentro de las particulas.

    cuando el jugado entra al trigger se incrementan los contadores que se encuentran 
    en los scripts de la puerta y blockeatelatrasporte asignados
 */
using UnityEngine;

public class Llave : MonoBehaviour
{
    public Puertas puertasScript; // puerta que va a abrir la partícula
    public BlockeaTeletransporte blockeateletransporteScript; // blockeatelatrasporte que va a abrir la partícula

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            puertasScript.contadorLlaves++;
            blockeateletransporteScript.contadorLlaves++;

        }
    }
}

