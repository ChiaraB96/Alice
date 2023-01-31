using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class DialogosT : MonoBehaviour
{
    public GameObject dialogueBox; // Es la caja de dialogo
    public Text dialogueText; // Es el texto donde se muestra el dialogo
    public float duracion = 5f;
    private Dictionary<string, string> dialogos; // Diccionario para almacenar los dialogos segun la plataforma
    private Dictionary<string, bool> dialogosShown; // Diccionario para registrar si el dialogo de cada plataforma ya se ha mostrado
    private bool isShowing; // variable para registrar si se esta mostrando el dialogo
    private Coroutine showTextCoroutine; // referencia a la coroutine ShowText

    private void Start()
    {
        dialogos = new Dictionary<string, string>();
        //dialogos conciencia
        dialogos.Add("DialogoInicial", "Hola Alice, aquí aprenderas todo lo que necesitas para comenzar tu aventura_");
        dialogos.Add("Dialogo2", "Empecemos... \n Como habrás notado puedes moverte utilizando las teclas A, D, S y W. Presiona shift para correr y espacio para saltar_");
        dialogos.Add("Dialogo3", "Aquí aprenderás y practicarás tus habilidades \n Tambien encontrarás una simulación que al finalizarla te llevará al primer nivel_");
        dialogos.Add("Dialogo11", "Esta es la simulación, una vez completa podras avanzar al siguiente nivel\n No te preocupes, volveré más adelante para ayudarte \nBuena Suerte! Ve con cuidado!_");
        dialogos.Add("Dialogo12", "Junta todas las partículas para desbloquear la puerta \n Cuando llegues a la plataforma amarilla se guardara el progreso de la Zona_");
        dialogos.Add("Dialogo14", "¿Tienes todas las particulas de la zona? \n Acercate a la puerta para desbloquearla_");
        dialogos.Add("Dialogo18", "¡Bien!¡Sabía que lo lograrias!\n Acercate al portal para avanzar al siguiente nivel_");
     
        //dialogos IA
        dialogos.Add("Dialogo13", "Oh, Alice... parece que tenemos un sujeto de prueba. Puedes considerarme como una 'Compañera' o algo así, como sea, completa los desafios si puedes.\n Consejo: Ten cuidado donde saltas...");
        dialogos.Add("Dialogo15", "¿No creiste que sería tan facil verdad? \n Veamos si puedes con la siguiente etapa.");
        dialogos.Add("Dialogo16", "¡Ya era hora! Me aburri taaanto de verte caer una y otra vez...");
        dialogos.Add("Dialogo17", "Parece que lo lograste... \n No me alegraría tanto si fuera tu, esto es solo el comienzo. Jajaja...");

        dialogosShown = new Dictionary<string, bool>(); // se crea el diccionario de dialogos mostrados
        foreach (string platform in dialogos.Keys)
        {
            dialogosShown.Add(platform, false); // se agrega una entrada para cada plataforma con el valor de falso
        }
        isShowing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isShowing) // si el objeto con el que colisiona tiene el tag "Player" y no se esta mostrando el dialogo
        {
            if (dialogos.ContainsKey(gameObject.name)) // si el diccionario contiene una entrada con el nombre de la plataforma actual
            {
                if (!dialogosShown[gameObject.name]) // si el dialogo de esta plataforma aun no se ha mostrado
                {
                    showTextCoroutine = StartCoroutine(ShowText(dialogos[gameObject.name])); // se guarda la referencia a la coroutine y se inicia la corutina y se pasa como parametro el dialogo correspondiente a la plataforma actual
                    dialogosShown[gameObject.name] = true; // se registra que el dialogo de esta plataforma ya se ha mostrado
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
            yield return new WaitForSeconds(0.01f); // espera 0.01 segundos antes de mostrar la siguiente letra
        }
        isShowing = false; // se registra que ya no se esta mostrando el dialogo
        StartCoroutine(HideMessage());
    }
    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(duracion);
        dialogueBox.SetActive(false);
        dialogueText.text = "";
    }
}
