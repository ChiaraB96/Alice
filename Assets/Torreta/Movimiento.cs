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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
