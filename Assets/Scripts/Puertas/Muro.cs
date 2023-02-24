/* Paredes blancas transparentes. 

    cuando el jugador sale del trigger el mismo de desactiva
*/

using UnityEngine;

public class Muro : MonoBehaviour
{
    private BoxCollider muroCollider;//collider del gameObject que tiene el script

    private void Start()
    {
        muroCollider = GetComponent<BoxCollider>();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            muroCollider.isTrigger = false;
        }
    }
}