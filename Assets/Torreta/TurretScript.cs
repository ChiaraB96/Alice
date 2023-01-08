using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    // Velocidad de disparo de la torreta
    public float fireRate = 1f;
    // Fuerza de empuje de la torreta
    public float pushForce = 1000f;
    // Posición de la torreta
    public Transform turretPosition;
    // Prefab del proyectil que disparará la torreta
    public GameObject projectilePrefab;

    // Tiempo transcurrido desde el último disparo
    private float elapsedTime = 0f;

    // Dispara el proyectil
    void FireProjectile()
    {
        // Instanciamos el prefab del proyectil
        GameObject projectile = Instantiate(projectilePrefab, turretPosition.position, Quaternion.identity);

        // Aplicamos una fuerza al proyectil para que salga disparado en la dirección en la que está apuntando la torreta
        projectile.GetComponent<Rigidbody>().AddForce(turretPosition.forward * 1000f);
    }

    // Aplica una fuerza de empuje a los objetos que entran en contacto con la torreta
    void OnCollisionEnter(Collision collision)
    {
        // Aplicamos una fuerza en la dirección en la que está apuntando la torreta al objeto que entra en contacto con ella
        collision.rigidbody.AddForce(turretPosition.forward * pushForce);
    }

    // Update is called once per frame
    void Update()
    {
        // Actualizamos la posición de la torreta
        UpdateTurretPosition();
    }

    // Actualiza la posición de la torreta
    void UpdateTurretPosition()
    {
        // Incrementamos el tiempo transcurrido desde el último disparo
        elapsedTime += Time.deltaTime;

        // Si ha pasado el tiempo necesario para disparar de nuevo, disparamos
        if (elapsedTime >= fireRate)
        {
            FireProjectile();
            elapsedTime = 0f;
        }

    }
}