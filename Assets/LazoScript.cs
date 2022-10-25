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
    
    private bool pisando;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //disparar lazo
        if(Input.GetMouseButtonDown(0) && disparado == false)
            disparado = true;

        if (disparado) {
            LineRenderer soga = lazo.GetComponent<LineRenderer>();
            soga.SetVertexCount(2);
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
            transform.position = Vector3.MoveTowards(transform.position, lazo.transform.position, Time.deltaTime *jugadorTravelSpeed);
            float distanceToLazo = Vector3.Distance(transform.position, lazo.transform.position);

            this.GetComponent<Rigidbody>().useGravity = false;

            if(distanceToLazo < 1){
                if(pisando == false){
                    this.transform.Translate(Vector3.forward * Time.deltaTime * 13f);
                    this.transform.Translate(Vector3.up * Time.deltaTime * 18f);
                }
                StartCoroutine("Subir");
            }
        } else {
            lazo.transform.parent = holder.transform;
            this.GetComponent<Rigidbody>().useGravity = true;
        }

    }

    IEnumerator Subir(){
        yield return new WaitForSeconds(0.1f);
        DevolverLazo();
    }

    void DevolverLazo()
    {
        lazo.transform.rotation = holder.transform.rotation;
        lazo.transform.position = holder.transform.position;
        disparado = false;
        enlazado = false;

         LineRenderer soga = lazo.GetComponent<LineRenderer>();
            soga.SetVertexCount(0);

    }

    void CheckearPiso(){
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if(Physics.Raycast(transform.position, dir, out hit, distance)){
            pisando = true;
        } else {
            pisando = false;
        }
    }
}
