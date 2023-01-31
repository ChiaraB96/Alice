using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;


public class DialogosFijosT : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    private Dictionary<string, string> aliceConcienciaDialogos;
    private bool isShowing;
    private Coroutine showTextCoroutine;


    private void Start()
    {
        //IA
        aliceConcienciaDialogos = new Dictionary<string, string>();
        aliceConcienciaDialogos.Add("DialogoFijo1", "Jajajaja Nunca me canso de verte caer.");
        aliceConcienciaDialogos.Add("DialogoFijo2", "Huy! Casi lo logras... Quee peeena...");
        aliceConcienciaDialogos.Add("DialogoFijo3", "¿De verdad lo estas intentando?");
        aliceConcienciaDialogos.Add("DialogoFijo4", "¿No creiste que te dejaría pasar por ahí verdad?");
        aliceConcienciaDialogos.Add("DialogoFijo5", "Ups! Parece que volviste a caeer.");
        isShowing = false;
    }


    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !isShowing)
        {
            if (aliceConcienciaDialogos.ContainsKey(gameObject.name))
            {
                dialogueText.text = aliceConcienciaDialogos[gameObject.name];
                dialogueBox.SetActive(true);
                StartCoroutine(HideMessage());
                isShowing = true;
            }
        }
    }


    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(7);
        dialogueBox.SetActive(false);
        dialogueText.text = "";
    }
}
