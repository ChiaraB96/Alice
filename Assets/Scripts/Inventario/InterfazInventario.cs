// Personaje -> HudBar -> Imagen.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazInventario : MonoBehaviour
{
    public GameObject prefabSlot;

    private void Start()
    {
        SistemaInventario.Instancia.cambioInventarioLlamada += actualizarInventario;
    }

    public void actualizarInventario()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.transform.gameObject);            
        }

        crearInventario();
    }

    public void crearInventario()
    {
        foreach(InventarioItems item in SistemaInventario.Instancia.inventario)
        {
            agregarSlot(item);
        }
    }
    
   public void agregarSlot(InventarioItems item)
   {
    GameObject obj = Instantiate(prefabSlot);
    obj.transform.SetParent(transform, false);

    ItemSlot slot = obj.GetComponent<ItemSlot>();
    slot.Set(item);
   }
}
