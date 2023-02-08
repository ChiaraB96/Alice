using UnityEngine;

public class Muro : MonoBehaviour
{
    private BoxCollider muroCollider;

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