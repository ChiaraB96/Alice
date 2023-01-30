using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PlatformDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    private Dictionary<string, string> aliceConcienciaDialogos;
    private bool isShowing;
    private Coroutine showTextCoroutine;

    private void Start()
    {
        aliceConcienciaDialogos = new Dictionary<string, string>();
        aliceConcienciaDialogos.Add("Plataforma1", "Hola mundo");
        aliceConcienciaDialogos.Add("Plataforma2", "Odio haskell");
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
