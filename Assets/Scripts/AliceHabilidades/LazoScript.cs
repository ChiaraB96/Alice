/*  Prefab del personaje.

    Lanza el lazo y si este colisiona contra un objeto con el tag "Enlazable" mueve
    la posicion del personaje en dirección a dicho objeto 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazoScript : MonoBehaviour
{
    public GameObject lazo;
    public GameObject holder;
    
    public float lazoTravelSpeed = 15.0f;// velocidad de movimiento del lazo
    public float jugadorTravelSpeed = 10.0f;//velocidad de movimiento del personaje
    
    public static bool disparado;
    public bool enlazado;
    public GameObject objetoEnlazable; //objeto con el tag Enlazable al cual el lazo colisionó
    
    public float maxDist = 20.0f;// distancia máxima que alcanza el lazo
    private float distActual; //distancia entre el jugador y el lazo

    public LayerMask objEnlazable; // capa que detecta el raycast
    bool rycast;
    public Transform direccion; //trasform del holder
    public GameObject miraActiva; //mira cuando el lazo puede ser lanzado

    void Update()
    {
        miraActiva.SetActive(false);
        rycast= Physics.Raycast(direccion.position, direccion.forward, (maxDist-1.7f), objEnlazable);
        Debug.DrawRay (direccion.position, direccion.forward* (maxDist-1.7f), Color.magenta );


        if(rycast){
            miraActiva.SetActive(true);
        
            //disparar lazo
            if(Input.GetMouseButtonDown(0) && disparado == false){
            disparado = true;
            }
        }
        if (disparado) { //si el lazo es disparado se genera un line render con inicio en el holder y fin en el lazo
            LineRenderer soga = lazo.GetComponent<LineRenderer>();
            soga.positionCount = 2;
            soga.SetPosition(0, holder.transform.position);
            soga.SetPosition(1, lazo.transform.position);
        }
        if (disparado == true && enlazado == false){
            lazo.transform.Translate(Vector3.forward * Time.deltaTime * lazoTravelSpeed);
            distActual = Vector3.Distance(transform.position, lazo.transform.position);

            if(distActual >= maxDist){
                DevolverLazo();
            }
        }

        if(enlazado == true && disparado == true){
            lazo.transform.parent = objetoEnlazable.transform;
            transform.position = Vector3.MoveTowards(transform.position, lazo.transform.position, jugadorTravelSpeed*Time.deltaTime);
            float distanceToLazo = Vector3.Distance(transform.position, lazo.transform.position);
            this.GetComponent<Rigidbody>().useGravity = false;

            if(distanceToLazo < 3){
                DevolverLazo();
            }
        } else {
            lazo.transform.parent = holder.transform;
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
