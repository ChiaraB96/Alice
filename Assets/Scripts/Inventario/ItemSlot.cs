/* Prefab Slot.

    asigna parametros al slot y muestra u oculta el numero que marca la cantidad de datos del inventario
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    public Image icono;
    public GameObject objeto;//fondo numero slot
    public TextMeshProUGUI numero;

    public void Set(InventarioItems item)//Asigna los datos al slot.
    {
        icono.sprite = item.dato.icono;

        if (item.tamañoInv <= 1)
        {
            objeto.SetActive(false);

        }
        else {
            objeto.SetActive(true);

        }

        numero.text = item.tamañoInv.ToString();
    }
}