// Prefab de la bala.

using UnityEngine;

public class Bala : MonoBehaviour
{
    public float vida = 1f;
    private float temporizador;

    void Update()
    {
        temporizador += Time.deltaTime;
        if(temporizador >= vida)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
