/*  Prefab de la bala. 

    establece el tiempo de vida de la bala
     que se destruye pasado el tiempo de vida o al colisionar contra un jugador
*/

using UnityEngine;

public class Bala : MonoBehaviour
{
    public float vida = 1f;//tiempo de vida de la bala
    private float temporizador;//termporizador

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
