using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bala;
    public float tiempo = 2f;
    private int contador;
    public int maxCont = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Disparar(){
        Debug.Log("Iniciar corrutina");
        for(int i=0; i<maxCont; i++) {
            contador++;
            Instantiate(bala, transform.position, transform.rotation);
            yield return new WaitForSeconds (tiempo);
        }
        Debug.Log("Fin corutina");
    }
}

