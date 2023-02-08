using UnityEngine;

public class MovimientoTorreta : MonoBehaviour
{
public GameObject balaPrefab;
public Transform puntoDisparo;
public float velocidadDisparo = 1.15f;
public GameObject objetivo;
public float radioDisparo = 8f;
public float agregarFuerza = 2500f;


private float temporizador;

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











/*
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float velocidadDisparo = 1.15f;
    public float detectionRadius = 8f;
    public float agregarFuerza = 2500f;

    private float temporizador;

    void Update()
    {
        // Buscar jugadores en el radio de detección
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider player in hitColliders)
        {
            if (player.CompareTag("Player"))
            {
                transform.LookAt(player.transform);

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
}*/

