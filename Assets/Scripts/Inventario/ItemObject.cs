/*  Particula -> PowerUp.

    recoje la particula cuando el personaje colisiona con la misma
    agregando el nuevo item al inventario y destruyendo la partícula
 */
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class ItemObject : MonoBehaviour
{
    public InventarioItemDatos itemDatos;//toma los datos del item guardados la clase creada a partir del script InventarioItemDatos


    public AudioClip sonido; //sonido que emite la partícula
    public float volumen; // volúmen del sonido de la partícula

    private AudioSource particula; //fuente de audio que se encuentra en la partícula

    private void Start()
    {
        particula = Camera.main.GetComponent<AudioSource>();
    }

    public void Recoger() //Recoge los items, los agrega al inventario y elimina de la escena.
    {
        SistemaInventario.Instancia.Add(itemDatos);
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