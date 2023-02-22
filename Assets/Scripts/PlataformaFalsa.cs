// En algunas plataformas de las zonas rojas.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalsa : MonoBehaviour
{
    public GameObject plataforma; 
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(plataforma);
        }
    }

}
