/* Prefab del personaje. 

    Permite al personaje desplazarce por las paredes 
    aplicando una fuerza en dirección al muro que detecte el Raycast
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    bool estaWR; 
    bool muroIzquierda;
    bool muroDerecha;

    public Rigidbody rb;//rigidbody del personaje

    //public Transform orientacion; // trasnform dentro del personaje
    public LayerMask WallRunLayer; //capa de wallRunning

    public float wallRunVelocidad = 1250f; //velocidad de WR
    public float fuerzaAgarre = 500f; // fuerza de agarre contra el muro
    public float alcance = 2f; // largo del raycast
    public float fuerzaCambiarMuro = 2500f; // fuerza de cambio de muro
    public float fuerzaSaltoMuro = 100f; // fuerza de salto entre muros

    void Update()
    {
        CheckearSiWR();
        muroDerecha = Physics.Raycast(transform.position, transform.right, alcance, WallRunLayer);
        Debug.DrawRay (transform.position, transform.right * alcance, Color.green );
        muroIzquierda = Physics.Raycast(transform.position, -transform.right, alcance, WallRunLayer);
        Debug.DrawRay (transform.position, -transform.right * alcance, Color.green );

    }

    private void CheckearSiWR()
    {
        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
        PararWR();
        }

        if(Input.GetKey("a") && muroIzquierda)
        {

            EmpezarWR(); 
        }

        if (Input.GetKey("d") && muroDerecha)
        {     

            EmpezarWR(); 
        }

        if (Input.GetKey("d") && muroIzquierda && estaWR)//cambio de muro
        {

            EmpezarWR();
            rb.AddForce(transform.right * fuerzaCambiarMuro * Time.deltaTime);
            rb.AddForce(transform.up * fuerzaSaltoMuro * Time.deltaTime);
        }

        if (Input.GetKey("a") && muroDerecha && estaWR)//cambio de muro
        {

            EmpezarWR();
            rb.AddForce(-transform.right * fuerzaCambiarMuro * Time.deltaTime);
            rb.AddForce(transform.up * fuerzaSaltoMuro * Time.deltaTime);
            
        }

        else if (!muroIzquierda && !muroDerecha )
        {
            PararWR();
        }
    }

    private void EmpezarWR()
    {
       rb.useGravity = false;
       estaWR = true;
       rb.AddForce(transform.forward * wallRunVelocidad * Time.deltaTime);
       
       if (muroDerecha){
            rb.AddForce(transform.right * fuerzaAgarre * Time.deltaTime);
        }

        if (muroIzquierda){
            rb.AddForce(-transform.right * fuerzaAgarre * Time.deltaTime);
        }
             
    }
    private void PararWR()
    {
        rb.useGravity = true;
        estaWR = false;
        
    }


}