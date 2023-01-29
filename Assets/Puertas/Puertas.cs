using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puertas : MonoBehaviour
{
    public GameObject door;
    public int keyCounter = 0;
    public int requiredKeys = 1;
    public GameObject player;
    public InventoryItemData itemData;
    public GameObject messageObject;
    public Text text;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (keyCounter >= requiredKeys)
            {
                OpenDoor();
            }
            else
            {
                ShowMessage();
            }
        }
    }

    void OpenDoor()
    {
        for (int i = 0; i < keyCounter; i++)
        {
            InventorySystem.Instance.Remove(itemData, keyCounter);
        }
        Destroy(door);
    }

    void ShowMessage()
    {
        messageObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = "No tienes la cantidad de particulas necesarias para abrir esta puerta.";
        StartCoroutine(HideMessage());
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(5);
        messageObject.SetActive(false);
        text.text = "";
    }
}
