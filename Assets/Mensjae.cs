using UnityEngine;
using UnityEngine.UI;

public class Mensjae : MonoBehaviour
{
    public string message = "Welcome to the platform!";
    public float displayTime = 3f;
    public Canvas canvas;

    private bool playerIsOnPlatform;
    private Text messageText;

    void Start()
    {
        // Crear un elemento de texto en la parte inferior de la pantalla
        GameObject textObject = new GameObject("MessageText");
        textObject.transform.SetParent(canvas.transform);
        messageText = textObject.AddComponent<Text>();
        messageText.rectTransform.anchoredPosition = new Vector2(0, -30);
        messageText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        messageText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOnPlatform = true;
            messageText.text = message;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOnPlatform = false;
            messageText.text = "";
        }
    }

    void Update()
    {
        if (playerIsOnPlatform)
        {
            displayTime -= Time.deltaTime;
            if (displayTime <= 0)
            {
                messageText.text = "";
                playerIsOnPlatform = false;
            }
        }
    }
}