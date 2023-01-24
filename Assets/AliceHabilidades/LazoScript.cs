using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazoScript : MonoBehaviour
{
    public GameObject lazo;
    public GameObject holder;
    
    public float lazoTravelSpeed = 15.0f;
    public float jugadorTravelSpeed = 10.0f;
    
    public static bool disparado;
    public bool enlazado;
    public GameObject objetoEnlazable;
    
    public float maxDist = 20.0f;
    private float distActual;

    // Update is called once per frame
    void Update()
    {
        //check if player's forward direction is colliding with an "Enlazable" object
        if (Input.GetKeyDown(KeyCode.Space) && disparado == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDist))
            {
                if (hit.collider.CompareTag("Enlazable"))
                {
                    objetoEnlazable = hit.collider.gameObject;
                    disparado = true;
                    lazo.transform.Translate(Vector3.forward * Time.deltaTime * lazoTravelSpeed);

                }
            }
        }

        if (disparado) {
            LineRenderer soga = lazo.GetComponent<LineRenderer>();
            soga.positionCount = 2;
            soga.SetPosition(0, holder.transform.position);
            soga.SetPosition(1, lazo.transform.position);
        }
        if (disparado == true && enlazado == false)
        {
            lazo.transform.Translate(Vector3.forward * Time.deltaTime * lazoTravelSpeed);
            distActual = Vector3.Distance(transform.position, lazo.transform.position);

            if(distActual >= maxDist)
            DevolverLazo();
        }

        if(enlazado == true && disparado == true){
            lazo.transform.parent = objetoEnlazable.transform;
            transform.position = Vector3.MoveTowards(transform.position, lazo.transform.position, jugadorTravelSpeed*Time.deltaTime);
            float distanceToLazo = Vector3.Distance(transform.position, lazo.transform.position);
                    this.GetComponent<Rigidbody>().useGravity = false;

        if(distanceToLazo < 3)
        {
            DevolverLazo();
        }
        else 
        {
        lazo.transform.parent = holder.transform;
        this.GetComponent<Rigidbody>().useGravity = true;
        }

    }

    void DevolverLazo()
    {
        lazo.transform.rotation = holder.transform.rotation;
        lazo.transform.position = holder.transform.position;
        disparado = false;
        enlazado = false;

        LineRenderer soga = lazo.GetComponent<LineRenderer>();
            soga.positionCount = 0;

    
    }
    }
}
