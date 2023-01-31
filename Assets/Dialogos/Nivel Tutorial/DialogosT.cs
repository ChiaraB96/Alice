using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class DialogosT : MonoBehaviour
{
    public GameObject dialogueBox; // Es la caja de dialogo
    public Text dialogueText; // Es el texto donde se muestra el dialogo
    private Dictionary<string, string> Dialogos; // Diccionario para almacenar los dialogos segun la plataforma
    private Dictionary<string, bool> DialogosShown; // Diccionario para registrar si el dialogo de cada plataforma ya se ha mostrado
    private bool isShowing; // variable para registrar si se esta mostrando el dialogo
    private Coroutine showTextCoroutine; // referencia a la coroutine ShowText

    private void Start()
    {
        Dialogos = new Dictionary<string, string>();
        //dialogos conciencia
        Dialogos.Add("DialogoInicial", "Hola Alice, aquí aprenderas todo lo que necesitas para comenzar tu aventura_");
        Dialogos.Add("Dialogo2", "Empecemos..._ \n Como habrás notado puedes moverte utilizando las teclas A, D, S y W. Presiona shift para correr y espacio para saltar_");
        Dialogos.Add("Dialogo3", "Aquí aprenderás y practicarás tus habilidades_ \n Tambien encontrarás una simulación que al finalizarla te llevará al primer nivel_");
        Dialogos.Add("Dialogo4", "Este es el entrenamiento de Wall Running \n avanza a la pared, presiona saltar y luego mantén precionada la tecla D_");
        Dialogos.Add("Dialogo5", "Bien! Ahora prueba hacia la izquierda, avanza, saltar y luego manten la tecla A_");
        Dialogos.Add("Dialogo6", "Ya casi lo tienes! Prueba intercambiar de muros, comienza manteniendo precionada la D y luego cambia a la A para cambiar de muro_");
        Dialogos.Add("Dialogo7", "Genial! Completaste el entrenamiento de Wall Running!_ \n Recuerda que puedes practicar cuantas veces quieras.\n Puedes acercarte a la particula para teletrasportarte devuelta a la zona inicial_");
        Dialogos.Add("Dialogo8", "Aqui puedes practicar el uso del Lazo, toma un poco de distancia de la plataforma, apunta al gancho rosa con la mira y haz click para lanzar el Lazo_");
        Dialogos.Add("Dialogo9", "Muy bien! Si tienes problemas para alcanzar el siguiente gancho prueba acercandote un poco_");
        Dialogos.Add("Dialogo10", "Genial! Completaste el entrenamiento de Lazo!_ \n Recuerda que puedes practicar cuantas veces quieras.\n Puedes acercarte a la particula para teletrasportarte devuelta a la zona inicial_");
        Dialogos.Add("Dialogo11", "Esta es la simulación, una vez completa podras avanzar al siguiente nivel_\n No te preocupes, volveré más adelante para ayudarte_\nBuena Suerte! Ve con cuidado!_");
        Dialogos.Add("Dialogo12", "Junta todas las partículas para desbloquear la puerta_ \n Cuando llegues a la plataforma amarilla se guardara el progreso de la Zona_");
        Dialogos.Add("Dialogo14", "¿Tienes todas las particulas de la zona? \n Acercate a la puerta para desbloquearla_");
        Dialogos.Add("Dialogo18", "¡Bien!¡Sabía que lo lograrias!\n Acercate al portal para avanzar al siguiente nivel_");
     
        //dialogos IA
        Dialogos.Add("Dialogo13", "Oh, Alice... parece que tenemos un sujeto de prueba. Puedes considerarme como una 'Compañera' o algo así, como sea, completa los desafios si puedes.\n Consejo: Ten cuidado donde saltas...");
        Dialogos.Add("Dialogo15", "¿No creiste que sería tan facil verdad? \n Veamos si puedes con la siguiente etapa.");
        Dialogos.Add("Dialogo16", "¡Ya era hora! Me aburri taaanto de verte caer una y otra vez...");
        Dialogos.Add("Dialogo17", "Parece que lo lograste... \n No me alegraría tanto si fuera tu, esto es solo el comienzo. Jajaja...");

        DialogosShown = new Dictionary<string, bool>(); // se crea el diccionario de dialogos mostrados
        foreach (string platform in Dialogos.Keys)
        {
            DialogosShown.Add(platform, false); // se agrega una entrada para cada plataforma con el valor de falso
        }
        isShowing = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isShowing) // si el objeto con el que colisiona tiene el tag "Player" y no se esta mostrando el dialogo
        {
            if (Dialogos.ContainsKey(gameObject.name)) // si el diccionario contiene una entrada con el nombre de la plataforma actual
            {
                if (!DialogosShown[gameObject.name]) // si el dialogo de esta plataforma aun no se ha mostrado
                {
                    showTextCoroutine = StartCoroutine(ShowText(Dialogos[gameObject.name])); // se guarda la referencia a la coroutine y se inicia la corutina y se pasa como parametro el dialogo correspondiente a la plataforma actual
                    DialogosShown[gameObject.name] = true; // se registra que el dialogo de esta plataforma ya se ha mostrado
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
        yield return new WaitForSeconds(5);
        dialogueBox.SetActive(false);
        dialogueText.text = "";
    }
}
