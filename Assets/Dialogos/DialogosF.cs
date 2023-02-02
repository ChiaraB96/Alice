using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;


public class DialogosF : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public float duracion = 5f;
    private Dictionary<string, string> DialogosFijos;
    private bool isShowing;
    private Coroutine showTextCoroutine;


    private void Start()
    {
        DialogosFijos = new Dictionary<string, string>();
        //conciencia
        DialogosFijos.Add("Dialogo4", "Este es el entrenamiento de Wall Running \n avanza a la pared, presiona saltar y luego mantén precionada la tecla D_");
        DialogosFijos.Add("Dialogo5", "Bien! Ahora prueba hacia la izquierda, avanza, saltar y luego manten la tecla A_");
        DialogosFijos.Add("Dialogo6", "Ya casi lo tienes! Prueba intercambiar de muros, comienza manteniendo precionada la A y luego cambia a la D para cambiar de muro_");
        DialogosFijos.Add("Dialogo7", "Genial! Completaste el entrenamiento de Wall Running!_ \n Recuerda que puedes practicar cuantas veces quieras.\n Puedes acercarte a la particula para teletrasportarte devuelta a la zona inicial_");
        DialogosFijos.Add("Dialogo8", "Aqui puedes practicar el uso del Lazo, toma un poco de distancia de la plataforma, apunta al gancho rosa con la mira y haz click para lanzar el Lazo_");
        DialogosFijos.Add("Dialogo9", "Muy bien! Si tienes problemas para alcanzar el siguiente gancho prueba acercandote un poco_");
        DialogosFijos.Add("Dialogo10", "Genial! Completaste el entrenamiento de Lazo!_ \n Recuerda que puedes practicar cuantas veces quieras.\n Puedes acercarte a la particula para teletrasportarte devuelta a la zona inicial_");
        DialogosFijos.Add("", "");
        //IA
        DialogosFijos.Add("DialogoFijo1", "Jajajaja. Nunca me canso de verte caer.");
        DialogosFijos.Add("DialogoFijo2", "Huy! Casi lo logras... Quee peeena...");
        DialogosFijos.Add("DialogoFijo3", "¿De verdad lo estas intentando?");
        DialogosFijos.Add("DialogoFijo4", "No creiste que te dejaría pasar por ahí ¿verdad?");
        DialogosFijos.Add("DialogoFijo5", "Ups! Parece que volviste a caeer.");
        DialogosFijos.Add("DialogoFijo6", "Te daré una pista, por aquí no era.");
        DialogosFijos.Add("DialogoFijo7", "¿No te cansas de caer? Jajaja");
        DialogosFijos.Add("DialogoFijo8", "Si quieres puedo conseguirte una cita con el suelo, veo que te gusta mucho. Jajaja");
        DialogosFijos.Add("DialogoFijo9", "Te noto algo nerviosa, ¿Que pasa? ¿No puedes?");
        DialogosFijos.Add("DialogoFijo10", "¿A eso le llamas saltar? Jajaja");
        DialogosFijos.Add("DialogoIAn1", "Parece que comenzaste con el pie izquierdo. Jajaja.");
        DialogosFijos.Add("Dialogo2IAn1", "Veo que correr por las paredes no es lo tuyo. Lo tendre en cuenta para más adeltante. Jajaja");
        DialogosFijos.Add("Dialogo8IAn1", "Ups! Creo que no fue una muy buena desición despues de todo. Parece que tus habilidades no funcionan aquí, que peena..");
        
    

        //tareas
        DialogosFijos.Add("Tareasn1", "Secuencia de puertas: \n Amarillo Azul Rojo. \n Partículas: \n3 Amarillas \n1 Azul \n4 Rojas ");
        DialogosFijos.Add("ZonaCompleta", "¡Completaste la Zona! ¡Vamos a la siguiente!_");
        DialogosFijos.Add("ZonaCompletaUltima", "¡Completaste la Zona! Rápido, vámonos de aquí_");
        DialogosFijos.Add("Tareasn2", "Secuencia de puertas: \n Azul Rojo Amarillo. \n Partículas: \n6 Azul \n2 Rojas \n3 Amarillas");

        isShowing = false;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isShowing)
        {
            if (DialogosFijos.ContainsKey(gameObject.name))
            {
                dialogueText.text = DialogosFijos[gameObject.name];
                dialogueBox.SetActive(true);
                isShowing = true;
                StartCoroutine(HideMessage());
            }
        }
    }


    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(duracion);
        dialogueBox.SetActive(false);
        dialogueText.text = "";
        isShowing = false;
    }
}
