using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 2f;
    public float tiempoVida = 5f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
