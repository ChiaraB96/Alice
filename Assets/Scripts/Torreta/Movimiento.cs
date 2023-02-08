using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float detectionRadius = 10f;
    public float addforce = 2500f;

    private float fireTimer;

    void Update()
    {
        // Buscar jugadores en el radio de detección
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider player in hitColliders)
        {
            if (player.CompareTag("Player"))
            {
                // Apuntar hacia el jugador
                transform.LookAt(player.transform);

                // Disparar
                fireTimer += Time.deltaTime;
                if (fireTimer >= fireRate)
                {
                    fireTimer = 0;
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * addforce);
                }
            }
        }
    }
}



/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Transform objetivo;
    public Transform torreta;
    public Transform bala;
    public Transform spawnBala;
    private float temp = 0f;

    private void OnTriggerStay (Collider other)
    {
        temp += Time.deltaTime;
        if(other.transform == objetivo)
        {
            torreta.transform.LookAt(objetivo);

            if(temp>4f)
            {Instantiate(bala, spawnBala.position, spawnBala.rotation);
            temp = 0.0f;
            }
         }
    }
}
*/