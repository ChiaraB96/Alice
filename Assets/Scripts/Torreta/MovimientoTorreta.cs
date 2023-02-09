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