// PowerUp dentro de las particulas.

using UnityEngine;

public class Llave : MonoBehaviour
{
    public Puertas puertasScript; 
    public BlockeaTeletransporte blockeateletransporteScript; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            puertasScript.contadorLlaves++;
            blockeateletransporteScript.contadorLlaves++;

        }
    }
}

