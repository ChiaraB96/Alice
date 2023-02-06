using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData itemData;
    public UnityEvent OnPickUp; 

    public AudioSource particula;
    public AudioClip sonido;
    public float volumen;

    public void HandlePickUp()
    {
        InventorySystem.Instance.Add(itemData);
        OnPickUp.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            particula.PlayOneShot(sonido,volumen);
            HandlePickUp();
        }
    }
}