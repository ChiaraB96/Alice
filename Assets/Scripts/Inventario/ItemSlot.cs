using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    public Image icono;

    public GameObject objeto;

    public TextMeshProUGUI numero;

    public void Set(InventarioItems item)//Asigna los datos al slot.
    {
        icono.sprite = item.dato.icono;

        if (item.tamañoInv <= 1)
        {
            objeto.SetActive(false);
            return;
        }

        numero.text = item.tamañoInv.ToString();
    }
    public void Reset()//Resetea los datos del slot.
    {
        icono.sprite = null;
        objeto.SetActive(false);
        numero.text = "";
    }
}