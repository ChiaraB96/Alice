﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    bool estaWR;
    bool muroIzquierda;
    bool muroDerecha;

    public Rigidbody rb;

    public Transform orientacion;
    public LayerMask WallRunLayer; 

    public float wallRunVelocidad = 1250f;
    public float fuerzaAgarre = 500f;
    public float alcance = 2f;
    public float fuerzaCambiarMuro = 2500f;
    public float fuerzaSaltoMuro = 100f;

    public Camera cam;
    public float RotationCam1;
    public float RotationCam2;
    public float RotationCam3;

    void Update()
    {
        muroDerecha = Physics.Raycast(transform.position, orientacion.right, alcance,WallRunLayer);
        muroIzquierda = Physics.Raycast(transform.position, -orientacion.right, alcance,WallRunLayer);
        CheckearSiWR();

        if(estaWR != true)
        {
            PararWR();
        }

    }

    private void CheckearSiWR()
    {
        if(Input.GetKey("a") && muroIzquierda)
        {
            EmpezarWR();
          
        }

        if (Input.GetKey("d") && muroDerecha)
        {     
            EmpezarWR();
           
        }
        


        if (Input.GetKey("d") && muroIzquierda && estaWR)
        {
             PararWR();
            rb.AddForce(orientacion.right * fuerzaCambiarMuro * Time.deltaTime);
            rb.AddForce(orientacion.up * fuerzaSaltoMuro * Time.deltaTime);
            
        }

        if (Input.GetKey("a") && muroDerecha && estaWR)
        {
             PararWR();
            rb.AddForce(-orientacion.right * fuerzaCambiarMuro * Time.deltaTime);
            rb.AddForce(orientacion.up * fuerzaSaltoMuro * Time.deltaTime);
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

        
       rb.AddForce(orientacion.forward * wallRunVelocidad * Time.deltaTime);
       
       if (muroDerecha){
            rb.AddForce(orientacion.right * fuerzaAgarre * Time.deltaTime);

            cam.transform.Rotate(Vector3.down, RotationCam1 * Time.deltaTime);
            cam.transform.Rotate(Vector3.forward, RotationCam2 * Time.deltaTime);
            cam.transform.Rotate(Vector3.left, RotationCam3 * Time.deltaTime);
        }

        if (muroIzquierda){
            rb.AddForce(-orientacion.right * fuerzaAgarre * Time.deltaTime);

            cam.transform.Rotate(Vector3.up, RotationCam1 * Time.deltaTime);
            cam.transform.Rotate(Vector3.forward, RotationCam2 * Time.deltaTime);
            cam.transform.Rotate(Vector3.right, RotationCam3 * Time.deltaTime);
        }
             
    }
    private void PararWR()
    {
        rb.useGravity = true;
        estaWR = false;
        
    }


}