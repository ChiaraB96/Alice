using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData itemData;
    public UnityEvent OnPickUp; 

    public AudioClip sonido;
    public float volumen;

    private AudioSource particula;

    private void Start()
    {
        particula = Camera.main.GetComponent<AudioSource>();
    }

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