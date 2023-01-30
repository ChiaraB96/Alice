using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PlatformDialogue : MonoBehaviour
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
        aliceConcienciaDialogos.Add("Plataforma1", "Aprobame puto Aprobame puto Aprobame puto Aprobame puto Aprobame puto");
        aliceConcienciaDialogos.Add("Plataforma2", "con cariño <3");
        aliceConcienciaDialogos.Add("Plataforma3", "");
        aliceConcienciaDialogos.Add("Plataforma4", "");
        aliceConcienciaDialogos.Add("Plataforma5", "");
        aliceConcienciaDialogos.Add("Plataforma6", "");
        aliceConcienciaDialogos.Add("Plataforma7", "");
        aliceConcienciaDialogos.Add("Plataforma8", "");
        aliceConcienciaDialogos.Add("Plataforma9", "");
        aliceConcienciaDialogos.Add("Plataforma10", "");
        //agregar mas plataformas y sus dialogos 
        aliceConcienciaDialogosShown = new Dictionary<string, bool>(); // se crea el diccionario de dialogos mostrados
        foreach (string platform in aliceConcienciaDialogos.Keys)
        {
            aliceConcienciaDialogosShown.Add(platform, false); // se agrega una entrada para cada plataforma con el valor de falso
        }
        isShowing = false;
    }

    private void OnCollisionStay(Collision other)
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
            yield return new WaitForSeconds(0.03f); // espera 0.3 segundos antes de mostrar la siguiente letra
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
