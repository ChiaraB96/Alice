// PowerUp dentro de las particulas solo del nivel tutorial.

using UnityEngine;

public class LlaveT : MonoBehaviour
{
    public Puertas puertasScript;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puertasScript.contadorLlaves++;
        }
    }
}

