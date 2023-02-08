using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Dialogos1Vez : MonoBehaviour
{
    public GameObject cajaTexto;
    public Text texto; 
    public float duracion = 5f;
    private Dictionary<string, string> dialogos;
    private Dictionary<string, bool> dialogosMostrados; 
    private bool mostrando;
    private Coroutine mostrarTextoCorrutina; 
    
    private void Start()
    {
        dialogos = new Dictionary<string, string>();//Diccionario de diálogos
        //dialogos conciencia
        dialogos.Add("DialogoInicial", "Hola Alice, aquí aprenderás todo lo que necesitas para comenzar tu aventura_");
        dialogos.Add("Dialogo2", "Empecemos, como habrás notado puedes moverte utilizando las teclas A, D, S y W. Mantén shift para correr y presiona espacio para saltar_");
        dialogos.Add("Dialogo3", "Aquí aprenderás y practicarás tus habilidades \n También encontrarás una simulación que al finalizarla te llevará al primer nivel_");
        dialogos.Add("Dialogo11", "Esta es la simulación, una vez completa podrás avanzar al siguiente nivel\n No te preocupes, volveré más adelante para ayudarte \nBuena Suerte! Ve con cuidado!_");
        dialogos.Add("Dialogo12", "Camina sobre las partículas para recojerlas. Una vez que juntes todas podrás desbloquear la puerta \n Cuando llegues a la plataforma amarilla se guardará el progreso de la Zona_");
        dialogos.Add("Dialogo14", "¿Tienes todas las partículas de la zona? \n Acercate a la puerta para desbloquearla_");
        dialogos.Add("Dialogo18", "¡Bien!¡Sabía que lo lograrias!\n Acercate al portal para avanzar al siguiente nivel_");
        dialogos.Add("Dialogon1", "¡Llegamos al primer nivel! Acércate a la zona marcada más adelante para ver las misiones \n Consejo: Puedes volver siempre que quieras para recordarlas_");
        dialogos.Add("Dialogo2n1", "Parece que hay algo extraño con estas plataformas, deberiamos elegir una con cuidado_");
        dialogos.Add("Dialogo3n1", "¡Si, esta era la correcta! Deberíamos recordarlo por si acaso_");
        dialogos.Add("Dialogo4n1", "Parece que esta es la primera zona, apúrate antes de que nos descubran_");
        dialogos.Add("Dialogo5n1", "Esta zona no parece tan difícil, ¿No te parece extraño?_");
        dialogos.Add("Dialogo6n1", "Mmm... Algo no se ve bien en este nivel, deberíamos avanzar con cuidado_");
        dialogos.Add("Dialogo7n1", "Rápido, juntemos las partículas y vámonos de aquí _");
        dialogos.Add("Dialogo8n1", "¡Sabía que podrías! ¡Vamos! _");
        dialogos.Add("Dialogon2", "¡Estamos cada vez más cerca! Puedo sentir como la IA se debilita, tengamos cuidado seguro está furiosa. \n Adelante, veamos las tareas_");
        dialogos.Add("Dialogo2n2", "Esta Zona es bastante extensa. Apunta bien y no te caigas o tendremos que volver a empezar_");
        dialogos.Add("Dialogo3n2", "Parece que aqui estamos a salvo de los disparos. Podemos usar esta plataforma para descansar un poco_");
        dialogos.Add("Dialogo4n2", "Ya casi lo logras, no pierdas la calma_");
        dialogos.Add("Dialogo5n2", "¡Vamos, se que puedes hacerlo!_");
        dialogos.Add("DialogoFinal", "¡Lo hiciste!¡Jamás dudé de ti! ¿Será que esta vez al fin seremos libres? _");
        //dialogos IA
        dialogos.Add("Dialogo13", "Oh, Alice... parece que tenemos un sujeto de prueba. Puedes considerarme como una 'Compañera' o algo así, como sea, completa los desafíos si puedes.\n Consejo: Ten cuidado donde saltas...");
        dialogos.Add("Dialogo15", "¿No creíste que sería tan fácil verdad? \n Veamos si puedes con la siguiente etapa.");
        dialogos.Add("Dialogo16", "¡Ya era hora! Me aburri taaanto de verte caer una y otra vez...");
        dialogos.Add("Dialogo17", "Parece que lo lograste... \n No me alegraría tanto si fuera tu, esto es solo el comienzo. Jajaja...");
        dialogos.Add("Dialogo3IAn1", "Quizás este nivel sea de tu talla.");
        dialogos.Add("Dialogo4IAn1", "Seguro llegaste hasta aquí de pura suerte. Como sea, elige un camíno...");
        dialogos.Add("Dialogo5IAn1", "¡Buena elección! O quizás no... \n Todavía puedes arrepentirte...");
        dialogos.Add("Dialogo6IAn1", "Espero que tengas buena memoria... \n  Déjame ayudarte, empieza por la derecha... O era la izquierda? Parece que no lo recuerdo muy bien después de todo");
        dialogos.Add("Dialogo7IAn1", "Adelante... Inténtalo...");
        dialogos.Add("DialogoIAn2", "Esta bien, si quieres sigue intentándolo... \n Pero no creas que te lo dejaré tan fácil.");
        dialogos.Add("Dialogo2IAn2", "Noté que esta prueba no te resultó tan dificil la última vez. Veamos que tal te va con los nuevos regalos que te preparé.");
        dialogos.Add("Dialogo3IAn2", "Creo que no fue una buena decisión venir hasta aquí después de todo. Espero que no te haya costado mucho. Jajajaja");
        dialogos.Add("Dialogo4IAn2", "Ya puedes dejar de intentarlo. Jamás te dejaré escapar.");
        dialogos.Add("Dialogo5IAn2", "Yo no estaría tan seguro de mi misma si fuera tú. Sería una lástima que vuelvas a caer");
        dialogos.Add("Dialogo6IAn2", "Parece que al final te subestime. Nunca imaginé que llegarías tan lejos. No volveré a cometer el mismo error.");

        dialogosMostrados = new Dictionary<string, bool>(); // Diccionario de dialogos mostrados
        foreach (string platform in dialogos.Keys)
        {
            dialogosMostrados.Add(platform, false); // se agrega una entrada para cada plataforma con el valor de falso
        }
        mostrando = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !mostrando)
        {
            if (dialogos.ContainsKey(gameObject.name)) 
            {
                if (!dialogosMostrados[gameObject.name])
                {
                    mostrarTextoCorrutina = StartCoroutine(MostrarTexto(dialogos[gameObject.name])); 
                    dialogosMostrados[gameObject.name] = true; 
                    mostrando = true;
                }
            }
        }
    }

    IEnumerator MostrarTexto(string text)
    {
            if (mostrando== true)
            {
                StopCoroutine(mostrarTextoCorrutina);
            }
        texto.text = ""; 
        cajaTexto.SetActive(true); 
        foreach (char c in text) 
        {
            texto.text += c; 
            yield return new WaitForSeconds(0.01f); 
        }
        mostrando = false;
        StartCoroutine(EsconderTexto());
 
    }

    IEnumerator EsconderTexto()
    {
        yield return new WaitForSeconds(duracion);
        cajaTexto.SetActive(false);
        texto.text = "";
    }
}
