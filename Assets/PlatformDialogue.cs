using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PlatformDialogue : MonoBehaviour
{
    public GameObject dialogueBox; // Es la caja de dialogo
    public Text dialogueText; // Es el texto donde se muestra el dialogo 
    private Dictionary<string, string> platformDialogues; // Diccionario para almacenar los dialogos segun la plataforma
    private Dictionary<string, bool> platformDialoguesShown; // Diccionario para registrar si el dialogo de cada plataforma ya se ha mostrado
    private bool isShowing; // variable para registrar si se esta mostrando el dialogo
    private Coroutine showTextCoroutine; // referencia a la coroutine ShowText

    private void Start()
    {
        platformDialogues = new Dictionary<string, string>();
        platformDialogues.Add("Plataforma1", "¡Puto el que lo lee, desputo si me aprobas!");
        platformDialogues.Add("Plataforma2", "¡Bienvenido a esta plataforma2!");
        platformDialogues.Add("Plataforma3", "¡Bienvenido a esta plataforma3!");
        //agregar mas plataformas y sus dialogos 
        platformDialoguesShown = new Dictionary<string, bool>(); // se crea el diccionario de dialogos mostrados
        foreach (string platform in platformDialogues.Keys)
        {
            platformDialoguesShown.Add(platform, false); // se agrega una entrada para cada plataforma con el valor de falso
        }
        isShowing = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isShowing) // si el objeto con el que colisiona tiene el tag "Player" y no se esta mostrando el dialogo
        {
            if (platformDialogues.ContainsKey(gameObject.name)) // si el diccionario contiene una entrada con el nombre de la plataforma actual
            {
                if (!platformDialoguesShown[gameObject.name]) // si el dialogo de esta plataforma aun no se ha mostrado
                {
                    showTextCoroutine = StartCoroutine(ShowText(platformDialogues[gameObject.name])); // se guarda la referencia a la coroutine y se inicia la corutina y se pasa como parametro el dialogo correspondiente a la plataforma actual
                    platformDialoguesShown[gameObject.name] = true; // se registra que el dialogo de esta plataforma ya se ha mostrado
                    isShowing = true; // se registra que se esta mostrando el dialogo
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // si el objeto con el que colisiona tiene el tag "Player"
        {
            StopCoroutine(showTextCoroutine); // detiene la coroutine ShowText
            dialogueBox.SetActive(false); //se desactiva el cuadro de dialogo
            dialogueText.text = ""; // se limpia el texto
	        isShowing = false; // se registra que ya no se esta mostrando el dialogo
        }
    }
    
    IEnumerator ShowText(string text) // se define la corutina
    {
        dialogueText.text = ""; //se limpia el texto
        dialogueBox.SetActive(true); // se activa el cuadro de dialogo 
        foreach (char c in text) // se recorre cada letra del dialogo
        {
            dialogueText.text += c; // se añade la letra actual al texto
            yield return new WaitForSeconds(0.05f); // espera 0.3 segundos antes de mostrar la siguiente letra
        }
        isShowing = false; // se registra que ya no se esta mostrando el dialogo
    }
}
