using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveMoneda : MonoBehaviour
{
   PlayerController jugador;

   
void Update(){
   transform.Rotate(0,0,50.0f * Time.deltaTime);
}
   private void OnCollisionEnter(Collision other) {
    if (other.gameObject.tag=="Player"){
    jugador = other.gameObject.GetComponent<PlayerController>();
    Destroy(gameObject);}
   }
}
