using UnityEngine;

public class LlaveT : MonoBehaviour
{
    public BlockeaTeletransporte blockeateletransporteScript; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            blockeateletransporteScript.contadorLlaves++; 
        }
    }
}
