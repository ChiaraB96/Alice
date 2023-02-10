using UnityEngine;

public class Llave : MonoBehaviour
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
