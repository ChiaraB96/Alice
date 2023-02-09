using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class ItemObject : MonoBehaviour
{
    public InventarioItemDatos itemDatos;
    public UnityEvent OnPickUp; 

    public AudioClip sonido;
    public float volumen;

    private AudioSource particula;

    private void Start()
    {
        particula = Camera.main.GetComponent<AudioSource>();
    }

    public void Recoger() //Recoge los items, los agrega al inventario y elimina de la escena.
    {
        SistemaInventario.Instancia.Add(itemDatos);
        OnPickUp.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            particula.PlayOneShot(sonido,volumen);
            Recoger();
        }
    }
}