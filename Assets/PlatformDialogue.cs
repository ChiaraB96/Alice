﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PlatformDialogue : MonoBehaviour
{
    public GameObject dialogueBox; // Es la caja de dialogo
    public Text dialogueText; // Es el texto donde se muestra el dialogo 
    private Dictionary<string, string> platformDialogues; // Diccionario para almacenar los dialogos segun la plataforma
    private Dictionary<string, bool> platformDialoguesShown; // Diccionario para registrar si el dialogo de cada plataforma ya se ha mostrado
    private Coroutine currentCoroutine; // variable para guardar la corutina actual

    private void Start()
    {
        platformDialogues = new Dictionary<string, string>();
        platformDialogues.Add("Platform1", "¡Bienvenido a esta plataforma!");
        platformDialogues.Add("Platform2", "¡Bienvenido a esta plataforma2!");
        platformDialogues.Add("Platform3", "¡Bienvenido a esta plataforma3!");
        //agregar mas plataformas y sus dialogos 
        platformDialoguesShown = new Dictionary<string, bool>(); // se crea el diccionario de dialogos mostrados
        foreach (string platform in platformDialogues.Keys)
        {
            platformDialoguesShown.Add(platform, false); // se agrega una entrada para cada plataforma con el valor de falso
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // si el objeto con el que colisiona tiene el tag "Player"
        {
            if (platformDialogues.ContainsKey(gameObject.name)) // si el diccionario contiene una entrada con el nombre de la plataforma actual
            {
                if (!platformDialoguesShown[gameObject.name]) // si el dialogo de esta plataforma aun no se ha mostrado
                {
                    currentCoroutine = StartCoroutine(ShowText(platformDialogues[gameObject.name])); // se inicia la corutina y se pasa como parametro el dialogo correspondiente a la plataforma actual
                    platformDialoguesShown[gameObject.name] = true; // se registra que el dialogo de esta plataforma ya se ha mostrado
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // si el objeto con el que colisiona tiene el tag "Player"
        {
            if(currentCoroutine != null)
                StopCoroutine(currentCoroutine); // detiene la corutina actual en ejecucion 
            dialogueBox.SetActive(false); //se desactiva el cuadro de dialogo
            dialogueText.text = ""; // se limpia el texto
        }
    }
    IEnumerator ShowText(string text) // se define la corutina
    {
        dialogueBox.SetActive(true); // se activa el cuadro de dialogo
        dialogueText.text = ""; // se limpia el texto 
        foreach (char c in text) // se recorre cada letra del dialogo
        {
            dialogueText.text += c; // se añade la letra actual al texto
            yield return new WaitForSeconds(0.05f); // espera 0.05 segundos antes de mostrar la siguiente letra
        }
    }
}
