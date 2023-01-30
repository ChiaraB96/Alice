using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class VozDialogoT : MonoBehaviour
{
    public GameObject dialogueBox; // Es la caja de dialogo
    public Text dialogueText; // Es el texto donde se muestra el dialogo
    private Dictionary<string, string> aliceConcienciaDialogos; // Diccionario para almacenar los dialogos segun la plataforma
    private Dictionary<string, bool> aliceConcienciaDialogosShown; // Diccionario para registrar si el dialogo de cada plataforma ya se ha mostrado
    private bool isShowing; // variable para registrar si se esta mostrando el dialogo
    private Coroutine showTextCoroutine; // referencia a la coroutine ShowText

    private void Start()
    {
        aliceConcienciaDialogos = new Dictionary<string, string>();
        aliceConcienciaDialogos.Add("DialogoInicial", "Bienvenido/a, aquí aprenderas todo lo que necesitas para comenzar tu aventura.");
        aliceConcienciaDialogos.Add("Dialogo2", "Empecemos... \n Como habrás notado puedes moverte utilizando las teclas A, D, S y W. Presiona shift para correr y espacio para saltar.");
        aliceConcienciaDialogos.Add("Dialogo3", "Aquí aprenderás y practicarás las habilidades de Alice. \n Tambien encontrarás una simulación que al finalizarla te llevará al primer nivel.");
        aliceConcienciaDialogos.Add("Dialogo4", "Este es el entrenamiento de Wall Running \n avanza a la pared, presiona saltar y luego mantén precionada la tecla D.");
        aliceConcienciaDialogos.Add("Dialogo5", "Bien! Ahora prueba hacia la izquierda, avanza, saltar y luego manten la tecla A.");
        aliceConcienciaDialogos.Add("Dialogo6", "Ya casi lo tienes! Prueba intercambiar de muros, comienza manteniendo precionada la D y luego cambia a la A para cambiar de muro.");
        aliceConcienciaDialogos.Add("Dialogo7", "Genial! Completaste el entrenamiento de Wall Running! \n Recuerda que puedes practicar cuantas veces quieras.\n Puedes acercarte a la particula para teletrasportarte devuelta a la zona inicial.");
        aliceConcienciaDialogos.Add("Dialogo8", "Aqui puedes practicar el uso del Lazo, toma un poco de distancia de la plataforma, apunta al gancho rosa con la mira y haz click para lanzar el Lazo");
        aliceConcienciaDialogos.Add("Dialogo9", "Muy bien! Si tienes problemas para alcanzar el siguiente gancho prueba acercandote un poco");
        aliceConcienciaDialogos.Add("Dialogo10", "Genial! Completaste el entrenamiento de Lazo! \n Recuerda que puedes practicar cuantas veces quieras.\n Puedes acercarte a la particula para teletrasportarte devuelta a la zona inicial.");
        //agregar mas plataformas y sus dialogos 
        aliceConcienciaDialogosShown = new Dictionary<string, bool>(); // se crea el diccionario de dialogos mostrados
        foreach (string platform in aliceConcienciaDialogos.Keys)
        {
            aliceConcienciaDialogosShown.Add(platform, false); // se agrega una entrada para cada plataforma con el valor de falso
        }
        isShowing = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isShowing) // si el objeto con el que colisiona tiene el tag "Player" y no se esta mostrando el dialogo
        {
            if (aliceConcienciaDialogos.ContainsKey(gameObject.name)) // si el diccionario contiene una entrada con el nombre de la plataforma actual
            {
                if (!aliceConcienciaDialogosShown[gameObject.name]) // si el dialogo de esta plataforma aun no se ha mostrado
                {
                    showTextCoroutine = StartCoroutine(ShowText(aliceConcienciaDialogos[gameObject.name])); // se guarda la referencia a la coroutine y se inicia la corutina y se pasa como parametro el dialogo correspondiente a la plataforma actual
                    aliceConcienciaDialogosShown[gameObject.name] = true; // se registra que el dialogo de esta plataforma ya se ha mostrado
                    isShowing = true; // se registra que se esta mostrando el dialogo
                }
            }
        }
    }

    IEnumerator ShowText(string text) // se define la corutina
    {
        dialogueText.text = ""; //se limpia el texto
        dialogueBox.SetActive(true); // se activa el cuadro de dialogo 
        foreach (char c in text) // se recorre cada letra del dialogo
        {
            dialogueText.text += c; // se añade la letra actual al texto
            yield return new WaitForSeconds(0.01f); // espera 0.3 segundos antes de mostrar la siguiente letra
        }
        isShowing = false; // se registra que ya no se esta mostrando el dialogo
        StartCoroutine(HideMessage());
    }
    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(7);
        dialogueBox.SetActive(false);
        dialogueText.text = "";
    }
}
