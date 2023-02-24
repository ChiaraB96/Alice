/* Dentro del primer Cube de la torreta.

     cuando el jugador entra en el radio de disparo la torreta lo sigue y dispara 
     cada 1.15segundos
 */

using UnityEngine;

public class MovimientoTorreta : MonoBehaviour
{
public GameObject balaPrefab; //prefab de la bala
public Transform puntoDisparo; // punto desde el que saldrá la bala
public float velocidadDisparo = 1.15f; // tiempo de espera entre disparos
public GameObject objetivo; // objetivo de la torreta (player)
public float radioDisparo = 8f; // distancia maxima que alcanza la torreta
public float agregarFuerza = 2500f; //fuerza que se transfiere al objetivo al ser alcanzado por la bala

private float temporizador;// temporizador

void Update()
{
    if (objetivo != null)
    {
        float distancia = Vector3.Distance(transform.position, objetivo.transform.position);
        if (distancia <= radioDisparo)
        {
            transform.LookAt(objetivo.transform);

            // Disparar
            temporizador += Time.deltaTime;
            if (temporizador >= velocidadDisparo)
            {
                temporizador = 0;
                GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
                bala.GetComponent<Rigidbody>().AddForce(puntoDisparo.forward * agregarFuerza);
            }
        }
    }
}
}